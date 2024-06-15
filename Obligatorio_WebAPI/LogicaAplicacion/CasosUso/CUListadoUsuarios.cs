using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUListadoUsuarios : ICUListado<Usuario> {
        public IRepositorioUsuarios Repo { get; set; }

        public CUListadoUsuarios(IRepositorioUsuarios repo)
        {
            Repo = repo;
        }
        public List<Usuario> ObtenerListado() {
            return Repo.GetAll();
        }
    }
}
