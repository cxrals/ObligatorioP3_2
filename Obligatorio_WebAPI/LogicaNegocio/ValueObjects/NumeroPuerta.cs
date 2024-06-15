using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects {
    public class NumeroPuerta {
        public int DireccionId { get; set; }
        public string Valor { get; init; }
        private NumeroPuerta() {

        }

        public NumeroPuerta(string valor, int direccionId) {
            Valor = valor;
            Validar();
            DireccionId = direccionId;
        }

        private void Validar() {
            if (string.IsNullOrEmpty(Valor))
                throw new Exception("El numero de puerta es obligatorio");
        }
    }
}
