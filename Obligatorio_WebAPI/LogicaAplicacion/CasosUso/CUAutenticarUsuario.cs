using LogicaNegocio.Dominio;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using LogicaNegocio.Excepciones;

namespace LogicaAplicacion.CasosUso {
    public class CUAutenticarUsuario : ICUAutenticarUsuario {
        public IRepositorioUsuarios Repo { get; set; }

        public CUAutenticarUsuario(IRepositorioUsuarios repo) {
            Repo = repo;
        }

        public UsuarioDTO Autenticar(string email, string contraseña) {

            try {
                Usuario u = Repo.BuscarPorEmail(email, contraseña);
                return MapperUsuarios.CrearDTO(u);
            } catch (Exception e) {
                throw new DatosInvalidosException("Las credenciales son incorrectas");
            }
        }
    }
}
