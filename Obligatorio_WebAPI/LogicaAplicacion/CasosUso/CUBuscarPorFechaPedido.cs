using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAplicacion.CasosUso {
    public class CUBuscarPorFechaPedido : ICUBuscarPorFechaPedido {
        public IRepositorioPedidos Repo { get; set; }
        public CUBuscarPorFechaPedido(IRepositorioPedidos repo) {
            Repo = repo;
        }
        public List<PedidoNoEntregadoDTO> BuscarPorFechaPedido(DateOnly fecha) {
            List<PedidoNoEntregadoDTO> dtos = new List<PedidoNoEntregadoDTO>();
            List<Pedido> pedidosEncontrados = Repo.BuscarPorFechaDeEmision(fecha);
            if (pedidosEncontrados.Count > 0) {
                dtos = MapperPedidos.ToListDto(pedidosEncontrados);
            } 
            //else {
            //    throw new RegistroNoExisteException("No existen pedidos para la fecha solicitada");
            //}
            return dtos;
        }
    }
}
