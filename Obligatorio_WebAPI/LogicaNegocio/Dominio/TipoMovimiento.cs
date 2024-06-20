using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    [Index(nameof(Nombre), IsUnique = true)]
    public class TipoMovimiento : IValidar {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public Tipo TipoAccion { get; set; }

        public void EsValido() {
            if (string.IsNullOrEmpty(Nombre)) {
                throw new DatosInvalidosException("El nombre es requerido");
            }
        }
    }

    public enum Tipo {
        Reduccion,
        Aumento
    }
}
