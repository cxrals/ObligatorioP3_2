using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioParametros : IRepositorioParametros {
        public ObligatorioContext Contexto { get; set; }
        public RepositorioParametros(ObligatorioContext ctx) {
            Contexto = ctx;
        }

        public decimal ObtenerIva() {
            return Contexto.Parametros.Where(p => p.Nombre == "IVA").OrderByDescending(p => p.Id).First().Valor;
        }
    }
}
