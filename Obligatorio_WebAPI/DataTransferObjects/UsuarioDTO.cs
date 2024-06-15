using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class UsuarioDTO {

        public string Email { get; set; }
        public string Password { get; set; }
        public string? Tipo { get; set; }
    }
}
