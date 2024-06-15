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
    public class CUBuscarClientesPorMontoPedido : ICUBuscarClientesPorMontoPedido {
        public IRepositorioPedidos Repo { get; set; }
        public CUBuscarClientesPorMontoPedido(IRepositorioPedidos repo) {
            Repo = repo;
        }
        public List<ClienteDTO> BuscarPorMontoPedido(decimal monto) {
            List<Cliente> clientesEncontrados = Repo.BuscarClientes(monto);
            if (clientesEncontrados.Count > 0) {
                List<ClienteDTO> clientesDTO = MapperClientes.ToListDto(clientesEncontrados);
                return clientesDTO;
            } else {
                throw new RegistroNoExisteException("No existen clientes que hayan realizado pedidos con un total mayor a ese monto.");
            }
            
        }
    }
}
