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
    public class CUAgregarArticuloEnPedido : ICUModificar<PedidoDTO> {
        public IRepositorioPedidos Repo { get; set; }
        public IRepositorioLineas RepoLineas { get; set; }
        public IRepositorioArticulos RepoArticulos { get; set; }
        public CUAgregarArticuloEnPedido(IRepositorioPedidos repo, IRepositorioArticulos repositorioArticulos, IRepositorioLineas repoLineas) {
            Repo = repo;
            RepoArticulos = repositorioArticulos;
            RepoLineas = repoLineas;
        }
        public void Modificar(PedidoDTO obj) {
            Pedido aModificar = Repo.FindById(obj.Id);
            Articulo articulo = RepoArticulos.FindById(obj.IdArticulo);

            if (articulo != null) {
                // chequear stock
                if (ChequearStock(articulo, obj.Cantidad)) {
                    // crear la Linea
                    Linea nuevaLinea = new Linea();
                    nuevaLinea.Articulo = articulo;
                    nuevaLinea.PreciodUnitario = articulo.Precio;
                    nuevaLinea.UnidadesSolicitadas = obj.Cantidad;
                    RepoLineas.Create(nuevaLinea);

                    // agregarla al pedido
                    aModificar.Lineas.Add(nuevaLinea);
                    aModificar.Total = CalcularTotal(aModificar, aModificar.Lineas);
                } else {
                    throw new NoStockException("No hay suficiente stock del artículo seleccionado");
                }
            } else {
                throw new RegistroNoExisteException("El artículo seleccionado para el pedido no existe");
            }

            Repo.Update(aModificar);
        }

        public static bool ChequearStock(Articulo articulo, int cantidadSolicitada) {
            if (articulo.Stock >= cantidadSolicitada) {
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

            foreach (Linea linea in lineas) {
                montoArticulos += linea.PreciodUnitario * linea.UnidadesSolicitadas;
            }

            resultado = montoArticulos * iva * recargo;

            return resultado;
        }
    }
}
