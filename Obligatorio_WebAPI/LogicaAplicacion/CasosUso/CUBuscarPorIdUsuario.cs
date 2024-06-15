using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUBuscarPorIdUsuario : ICUBuscarPorId<Usuario> {
        public IRepositorioUsuarios Repo { get; set; }
        public CUBuscarPorIdUsuario(IRepositorioUsuarios repo) {
            Repo = repo;
        }
        public Usuario BuscarPorId(int id) {
            return Repo.FindById(id);
        }
    }
}
