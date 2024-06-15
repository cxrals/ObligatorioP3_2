using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones {
    public class NoStockException : Exception {
        public NoStockException() {

        }

        public NoStockException(string mensaje) : base(mensaje) {

        }
    }
}
