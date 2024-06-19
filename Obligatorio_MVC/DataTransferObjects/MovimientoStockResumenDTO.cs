using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class MovimientoStockResumenDTO {
        public List<string> TipoCantidad { get; set; } = new List<string>();
        public int CantidadTotalAnio { get; set; }
        public int Anio { get; set; }
    }
}
