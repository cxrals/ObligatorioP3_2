using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios {
    public interface IRepositorioPedidos : IRepositorio<Pedido>{
        void AnularPedido(int id); 
        List<Pedido> BuscarPorFechaDeEmision(DateOnly fecha);
        List<Pedido> OrdenarPedidosAnuladosPorFechaDesc();
        List<Pedido> ListarPedidosPendientes();
        List<Cliente> BuscarClientes(decimal monto);
    }
}
