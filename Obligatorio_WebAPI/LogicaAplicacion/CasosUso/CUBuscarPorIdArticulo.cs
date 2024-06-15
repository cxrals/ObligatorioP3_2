using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUBuscarPorIdArticulo : ICUBuscarPorId<Articulo> {
        public IRepositorioArticulos Repo { get; set; }
        public CUBuscarPorIdArticulo(IRepositorioArticulos repo) {
            Repo = repo;
        }
        public Articulo BuscarPorId(int id) {
            return Repo.FindById(id);
        }
    }
}
