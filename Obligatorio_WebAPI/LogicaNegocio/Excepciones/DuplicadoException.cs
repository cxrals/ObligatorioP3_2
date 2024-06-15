using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones {
    public class DuplicadoException : Exception {
        public DuplicadoException() {
            
        }

        public DuplicadoException(string mensaje) : base(mensaje) {

        }
    }
}
