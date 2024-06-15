using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUBajaArticulo : ICUBaja<Articulo> {
        public IRepositorioArticulos Repo { get; set; }
        public CUBajaArticulo(IRepositorioArticulos repo) {
            Repo = repo;
        }
        public void Baja(int id) {
            Repo.Delete(id);
        }
    }
}
