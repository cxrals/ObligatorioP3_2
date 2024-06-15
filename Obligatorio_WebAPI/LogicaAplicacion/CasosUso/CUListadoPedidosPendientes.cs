using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUListadoPedidosPendientes : ICUListado<PedidoNoEntregadoDTO> {
        public IRepositorioPedidos Repo { get; set; }

        public CUListadoPedidosPendientes(IRepositorioPedidos repo) {
            Repo = repo;
        }
        public List<PedidoNoEntregadoDTO> ObtenerListado() {
            List<PedidoNoEntregadoDTO> dtos = new List<PedidoNoEntregadoDTO>();
            List<Pedido> pedidosEncontrados = Repo.ListarPedidosPendientes();
            if (pedidosEncontrados.Count > 0) {
                dtos = MapperPedidos.ToListDto(pedidosEncontrados);
            }
            return dtos;
        }
    }
}
