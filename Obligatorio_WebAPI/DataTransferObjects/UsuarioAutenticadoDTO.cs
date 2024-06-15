using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class UsuarioAutenticadoDTO {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Tipo { get; set; }
    }
}
