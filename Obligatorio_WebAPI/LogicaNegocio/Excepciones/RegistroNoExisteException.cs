using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones {
    public class RegistroNoExisteException : Exception {
        public RegistroNoExisteException() {
            
        }

        public RegistroNoExisteException(string mensaje) : base(mensaje) {

        }
    }
}
