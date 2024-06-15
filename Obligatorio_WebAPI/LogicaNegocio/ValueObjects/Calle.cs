using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects {
    //[Owned]
    public class Calle {
        public int DireccionId { get; set; }
        public string Valor { get; init; }
        private Calle() {

        }

        public Calle(string valor, int direccionId) {
            Valor = valor;
            Validar();
            DireccionId = direccionId;
        }

        private void Validar() {
            if (string.IsNullOrEmpty(Valor))
                throw new Exception("El nombre de la calle es obligatorio");
        }
    }
}
