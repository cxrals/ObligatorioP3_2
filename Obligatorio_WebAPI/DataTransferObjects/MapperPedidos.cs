using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class MapperPedidos {
        public static Pedido CrearEntidad(PedidoDTO pedidoDTO) {
            Pedido p;

            if (pedidoDTO.TipoPedido == "PedidoExpress") {
                p = new PedidoExpress();
            } else {
                p = new PedidoComun();
            }

            p.FechaEntrega = pedidoDTO.FechaEntrega;
            p.Estado = pedidoDTO.Estado;

            return p;
        }

        public static PedidoDTO CrearDTO(Pedido pedido) {
            PedidoDTO pedidoDTO = new PedidoDTO();

            pedidoDTO.Id = pedido.Id;
            pedidoDTO.FechaEntrega = pedido.FechaEntrega;
            pedidoDTO.Estado = pedido.Estado;

            return pedidoDTO;
        }

        public static List<PedidoNoEntregadoDTO> ToListDto(List<Pedido> pedidos) {
            return pedidos.Select(p => new PedidoNoEntregadoDTO() {
                Id = p.Id,
                FechaEntrega = p.FechaEntrega,
                RazonSocialCliente = p.Cliente.RazonSocial,
                Recargo = p.Recargo,
                Iva = p.Iva,
                Total = p.Total
            })
            .ToList();
        }
    }
}
