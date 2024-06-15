using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public  class PedidoDTO {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public DateOnly FechaEntrega { get; set; }
        public string TipoPedido { get; set; }
        public string Estado { get; set; }
    }
}
