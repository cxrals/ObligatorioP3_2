using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioLineas : IRepositorioLineas {
        public ObligatorioContext Contexto { get; set; }

        public RepositorioLineas(ObligatorioContext ctx) {
            Contexto = ctx;
        }
        public void Create(Linea obj) {
            //obj.EsValido();
            Contexto.Lineas.Add(obj);
            Contexto.SaveChanges();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public Linea FindById(int id) {
            throw new NotImplementedException();
        }

        public List<Linea> GetAll() {
            throw new NotImplementedException();
        }

        public void Update(Linea obj) {
            throw new NotImplementedException();
        }
    }
}
