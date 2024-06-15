using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.Dominio {
    [Index(nameof(Rut), IsUnique = true)]
    public class Cliente : IValidar {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Razon Social")]
        public string? RazonSocial { get; set; }
        [StringLength(12, MinimumLength = 12)]
        public string? Rut { get; set; } // 12 digitos
        public Direccion Direccion { get; set; } // calle, numero, ciudad
        public int? DistanciaHastaDeposito { get; set; }
        public void EsValido() {
            if (Rut.Length != 12) {
                throw new DatosInvalidosException("El RUT debe tener 12 dígitos.");
            }
        }
    }
}
