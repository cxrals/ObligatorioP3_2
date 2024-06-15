using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class MovimientoStockIndexDTO {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [Display(Name = "Articulo")]
        public string ArticuloNombre { get; set; }
        [Display(Name = "Usuario")]
        public string EmailUsuario { get; set; }
        [Display(Name = "Tipo de Movimiento")]
        public string TipoMovimientoNombre { get; set; }
        public int Cantidad { get; set; }
    }
}
