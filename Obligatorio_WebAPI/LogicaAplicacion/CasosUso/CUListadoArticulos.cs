using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUListadoArticulos : ICUListado<Articulo> {
        public IRepositorioArticulos Repo { get; set; }

        public CUListadoArticulos(IRepositorioArticulos repo) {
            Repo = repo;
        }

        public List<Articulo> ObtenerListado() {
            return Repo.GetAll();
        }
    }
}
