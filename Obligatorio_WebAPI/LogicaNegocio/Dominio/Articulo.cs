using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesDominio;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LogicaNegocio.Dominio {
    [Index(nameof(Nombre), IsUnique = true)]
    [Index(nameof(CodigoProveedor), IsUnique = true)]
    public class Articulo : IValidar {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "El nombre debe tener entre 10 y 200 caracteres")]
        public string Nombre { get; set; } // no vacio y unico. Min 10 char max 200 char
        [MinLength(5, ErrorMessage = "La descripción debe tener un mínimo de 5 caracteres")]
        public string Descripcion { get; set; } // largo minimo de 5 caracteres
        [Display(Name = "Código de Proveedor")]
        [Required(ErrorMessage = "El código de proveedor es requerido")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "El código de proveedor debe tener 13 dígitos")]
        public string CodigoProveedor { get; set; } // 13 digitos, no vacio
        public int Precio {  get; set; }
        public int Stock {  get; set; }

        public void EsValido() {
            if (Nombre.Length < 10 || Nombre.Length > 200 || string.IsNullOrEmpty(Nombre)) {
                throw new DatosInvalidosException("El nombre debe tener entre 10 y 200 caracteres");
            }

            if (CodigoProveedor.Length != 13 || string.IsNullOrEmpty(CodigoProveedor)) {
                throw new DatosInvalidosException("El código de proveedor es requerido y debe tener 13 dígitos.");
            }

            if (Descripcion.Length < 5) {
                throw new DatosInvalidosException("La descripción debe tener un mínimo de 5 caracteres.");
            }

            if (Precio < 0 || Stock < 0) {
                throw new DatosInvalidosException("Precio y Stock no pueden ser negativos.");
            }
        }
    }
}
