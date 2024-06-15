using LogicaNegocio.InterfacesDominio;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.Excepciones;

namespace LogicaNegocio.Dominio {
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario : IValidar {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; } // unico, aplicar formateado
        [RegularExpression(@"^[A-Za-z][A-Za-z' -]*[A-Za-z]$")]
        public string Nombre { get; set; }
        [RegularExpression(@"^[A-Za-z][A-Za-z' -]*[A-Za-z]$")]
        public string Apellido { get; set; }
        [MinLength(6)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[.!;]).{6,}$")]
        public string Contraseña { get; set; } // min 6 char, mayuscula, minuscula, char especial (punto, punto y coma, coma, signo de admiración de cierre)
        public string? ContraseniaEncriptada { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public TipoUsuario Tipo { get; set; }

        public void EsValido() {
            if(!ValidarContraseña(Contraseña)) {
                throw new DatosInvalidosException("La contraseña debe tener un mínimo de 6 caracteres, al menos una mayuscula y una minuscula y un caracter especial (punto, coma, punto y coma o signo de admiración)");
            }
            //TODO: VO para nombre y apellido?
        }

        private bool ValidarContraseña(String contraseña) {
            var tieneNumero = new Regex(@"[0-9]+");
            var tieneMayuscula = new Regex(@"[A-Z]+");
            var tieneMinuscula = new Regex(@"[a-z]+");
            var tieneMinSeisChar = new Regex(@".{6,}");
            var tieneSimbolos = new Regex(@"[!;,.?]");

            return tieneNumero.IsMatch(contraseña) && tieneMayuscula.IsMatch(contraseña) && tieneMinuscula.IsMatch(contraseña) && tieneMinSeisChar.IsMatch(contraseña) && tieneSimbolos.IsMatch(contraseña);
        }
    }

    public enum TipoUsuario {
        Administrador,
        Encargado,
        Estandar
    }
    // https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations#pre-defined-conversions
}
