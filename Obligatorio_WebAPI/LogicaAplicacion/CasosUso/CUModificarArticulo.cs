using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUModificarArticulo : ICUModificar<Articulo> {
        public IRepositorioArticulos Repo { get; set; }

        public CUModificarArticulo(IRepositorioArticulos repo) {
            Repo = repo;
        }
        public void Modificar(Articulo obj) {
            Repo.Update(obj);
        }
    }
}
