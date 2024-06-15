using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class MovimientoStockDTO {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ArticuloId { get; set; }
        public string EmailUsuario { get; set; }
        public int TipoMovimientoId { get; set; }
        public int Cantidad { get; set; }
    }
}
