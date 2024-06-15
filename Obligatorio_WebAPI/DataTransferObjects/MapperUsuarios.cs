using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class MapperUsuarios {
        public static UsuarioDTO CrearDTO(Usuario usuario) {
            UsuarioDTO usuarioDTO = new UsuarioDTO();

            usuarioDTO.Email = usuario.Email;
            usuarioDTO.Password = usuario.Contraseña;
            usuarioDTO.Tipo = usuario.Tipo.ToString();

            return usuarioDTO;
        }
    }
}
