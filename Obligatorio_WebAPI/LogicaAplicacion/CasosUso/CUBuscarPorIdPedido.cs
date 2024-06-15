using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUBuscarPorIdPedido : ICUBuscarPorId<PedidoDTO> {
        public IRepositorioPedidos Repo { get; set; }

        public CUBuscarPorIdPedido(IRepositorioPedidos repo) {
            Repo = repo;
        }

        public PedidoDTO BuscarPorId(int id) {
            PedidoDTO dto = new PedidoDTO();
            Pedido pedidosEncontrados = Repo.FindById(id);
            if (pedidosEncontrados != null) {
                dto = MapperPedidos.CrearDTO(pedidosEncontrados);
            } else {
                throw new RegistroNoExisteException("El pedido no existe");
            }
            return dto;
        }
    }
}
