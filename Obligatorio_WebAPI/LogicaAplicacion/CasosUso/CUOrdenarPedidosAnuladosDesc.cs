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
    public class CUOrdenarPedidosAnuladosDesc : ICUOrdenarPedidosAnuladosDesc {
        public IRepositorioPedidos Repo { get; set; }
        public CUOrdenarPedidosAnuladosDesc(IRepositorioPedidos repo) {
            Repo = repo;
        }
        public List<PedidoNoEntregadoDTO> OrdenarPorFechaDesc() {
            List<PedidoNoEntregadoDTO> dtos = new List<PedidoNoEntregadoDTO>();
            List<Pedido> pedidosOrdenados = Repo.OrdenarPedidosAnuladosPorFechaDesc();
            if (pedidosOrdenados.Count > 0) {
                dtos = MapperPedidos.ToListDto(pedidosOrdenados);
            }
            return dtos;
        }
    }
}
