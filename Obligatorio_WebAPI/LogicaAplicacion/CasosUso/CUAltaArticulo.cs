using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUAltaArticulo : ICUAlta<Articulo> {
        public IRepositorioArticulos Repo { get; set; }
        public CUAltaArticulo(IRepositorioArticulos repo) {
            Repo = repo;
        }
        public void Alta(Articulo obj) {
            Repo.Create(obj);
        }
    }
}
