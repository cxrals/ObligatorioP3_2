using DataTransferObjects;
using LogicaNegocio.Dominio;

namespace Obligatorio.Models {
    public class AltaPedidoViewModel {
        public List<ClienteDTO>? Clientes { get; set; }
        public int IdCliente { get; set; }
        public List<Articulo>? Articulos { get; set; }
        public int IdArticulo { get; set; }
        public DateOnly FechaEntrega { get; set; }
        public string TipoPedido { get; set; }
        public int Cantidad { get; set; }

    }
} 
