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
    public class CUAltaPedido : ICUAlta<PedidoDTO> {
        public IRepositorioPedidos Repo { get; set; }
        public IRepositorioClientes RepoClientes { get; set; }
        public IRepositorioArticulos RepoArticulos { get; set; }
        public IRepositorioLineas RepoLineas { get; set; }
        public IRepositorioParametros RepoParametros { get; set; }
        public CUAltaPedido(IRepositorioPedidos repo, IRepositorioClientes repoClientes, IRepositorioArticulos repoArticulos, IRepositorioLineas repoLineas, IRepositorioParametros repoParametros) {
            Repo = repo;
            RepoClientes = repoClientes;
            RepoArticulos = repoArticulos;
            RepoLineas = repoLineas;
            RepoParametros = repoParametros;
        }
        public void Alta(PedidoDTO obj) {
            Pedido nuevoPedido = MapperPedidos.CrearEntidad(obj);
            // TODO popular al ejecutar la app
            Pedido._iva = RepoParametros.ObtenerIva();
            Cliente cliente = RepoClientes.FindById(obj.IdCliente);
            Articulo articulo = RepoArticulos.FindById(obj.IdArticulo);
            if (cliente != null) {
                nuevoPedido.Cliente = cliente;
                
            } else {
                throw new RegistroNoExisteException("El cliente seleccionado para el pedido no existe");
            }

            // TODO RepoParametros.ObtenerRecargo(obj.TipoPedido);
            if(obj.TipoPedido == "PedidoExpress") {
                nuevoPedido.CalcularRecargo(0.15m,0.1m);
                
            } else {
                nuevoPedido.CalcularRecargo(0.05m, 0);
            }

            if (articulo != null) {
                // chequear stock
                if(ChequearStock(articulo, obj.Cantidad)) {
                    // crear la Linea
                    Linea nuevaLinea = new Linea();
                    nuevaLinea.Articulo = articulo;
                    nuevaLinea.PreciodUnitario = articulo.Precio;
                    nuevaLinea.UnidadesSolicitadas = obj.Cantidad;
                    RepoLineas.Create(nuevaLinea);

                    // agregarla al pedido
                    nuevoPedido.Lineas = new List<Linea> { nuevaLinea };
                    nuevoPedido.Total = CalcularTotal(nuevoPedido, nuevoPedido.Lineas);
                } else {
                    throw new NoStockException("No hay suficiente stock del artículo seleccionado");
                }
            } else {
                throw new RegistroNoExisteException("El artículo seleccionado para el pedido no existe");
            }

            Repo.Create(nuevoPedido);
        }

        public static bool ChequearStock(Articulo articulo, int cantidadSolicitada) {
            if(articulo.Stock >= cantidadSolicitada) {
                return true;
            } else {
                return false;
            }
        }

        public static decimal CalcularTotal(Pedido p, List<Linea> lineas) {
            decimal resultado = 0;
            decimal montoArticulos = 0;
            decimal iva = p.Iva + 1;
            decimal recargo = p.Recargo + 1;

            foreach ( Linea linea in  lineas ) {
                montoArticulos =+ linea.PreciodUnitario * linea.UnidadesSolicitadas;
            }

            resultado = montoArticulos * iva * recargo;

            return resultado;
        }
    }
}
