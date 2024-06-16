using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class MovimientoStockIndexDTO {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string ArticuloNombre { get; set; }
        public string EmailUsuario { get; set; }
        public string TipoMovimientoNombre { get; set; }
        public int Cantidad { get; set; }
        public string? TipoMovimientoAccion {  get; set; } // RF-04-a
    }
}
