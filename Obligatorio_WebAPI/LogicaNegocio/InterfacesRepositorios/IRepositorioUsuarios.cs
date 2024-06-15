using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios {
    public interface IRepositorioUsuarios : IRepositorio<Usuario> {
        Usuario BuscarPorEmail(string email);
        Usuario BuscarPorEmail(string email, string password);
    }
}
