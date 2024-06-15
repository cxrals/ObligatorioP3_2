using DataTransferObjects;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Filters;
using Obligatorio.Models;

namespace Obligatorio.Controllers {
    public class PedidosController : Controller {
        public ICUListado<Articulo> CUListadoArticulos { get; set; }
        public ICUListado<ClienteDTO> CUListadoClientes { get; set; }
        public ICUAlta<PedidoDTO> CUAlta { get; set; }
        public ICUBuscarPorFechaPedido CUBuscarPorFechaPedido { get; set; }
        public ICUAnularPedido CUAnularPedido { get; set; }
        public ICUBuscarPorId<PedidoDTO> CUBuscarPorIdPedido { get; set; }
        public ICUListado<PedidoNoEntregadoDTO> CUListadoPedidosPendientes {  get; set; }
        public ICUModificar<PedidoDTO> CUAgregarArticulo { get; set; }


        public PedidosController(
                ICUListado<Articulo> cuListadoArticulos, 
                ICUListado<ClienteDTO> cuListadoClientes, 
                ICUAlta<PedidoDTO> cuAlta, 
                ICUBuscarPorFechaPedido cuBuscarPorFechaPedido, 
                ICUAnularPedido cuAnularPedido, 
                ICUBuscarPorId<PedidoDTO> cuBuscarPorIdPedido, 
                ICUListado<PedidoNoEntregadoDTO> cuListadoPedidosPendientes, 
                ICUModificar<PedidoDTO> cuAgregarArticulo
            ) {
            CUListadoArticulos = cuListadoArticulos;
            CUListadoClientes = cuListadoClientes;
            CUAlta = cuAlta;
            CUBuscarPorFechaPedido = cuBuscarPorFechaPedido;
            CUAnularPedido = cuAnularPedido;
            CUBuscarPorIdPedido = cuBuscarPorIdPedido;
            CUListadoPedidosPendientes = cuListadoPedidosPendientes;
            CUAgregarArticulo = cuAgregarArticulo;  

        }

        [Privado(TipoUsuarios = "Administrador")]
        public IActionResult Index() {
            return View(CUListadoPedidosPendientes.ObtenerListado());
        }

        //--------------------------------------------------------------------------
        //----------------------------- CREATE -------------------------------------
        //--------------------------------------------------------------------------
        [Privado(TipoUsuarios = "Administrador")]
        public ActionResult Create() {
            AltaPedidoViewModel vm = new AltaPedidoViewModel() {
                Articulos = CUListadoArticulos.ObtenerListado(),
                Clientes = CUListadoClientes.ObtenerListado()
            };
            return View(vm);
        }

        [Privado(TipoUsuarios = "Administrador")]
        [HttpPost]
        public ActionResult Create(AltaPedidoViewModel vm) {
            try {
                PedidoDTO dto = new PedidoDTO();
                dto.IdCliente = vm.IdCliente;
                dto.TipoPedido = vm.TipoPedido;
                dto.FechaEntrega = vm.FechaEntrega;
                dto.IdArticulo = vm.IdArticulo;
                dto.Cantidad = vm.Cantidad;
                dto.Estado = "Pendiente";

                CUAlta.Alta(dto);

                return RedirectToAction("Index", "Pedidos");
            } catch (DatosInvalidosException e) {
                ViewBag.ErrorMsg = e.Message;
            } catch (RegistroNoExisteException e) {
                ViewBag.ErrorMsg = e.Message;
            } catch (NoStockException e) {
                ViewBag.ErrorMsg = e.Message;
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }

            vm.Articulos = CUListadoArticulos.ObtenerListado();
            vm.Clientes = CUListadoClientes.ObtenerListado();
            return View(vm);
        }

        //--------------------------------------------------------------------------
        //----------------------------- ANULAR -------------------------------------
        //--------------------------------------------------------------------------
        [Privado(TipoUsuarios = "Administrador")]
        public ActionResult AnularPedidos(int id) {
            PedidoDTO p = CUBuscarPorIdPedido.BuscarPorId(id);
            return View(p);
        }

        [Privado(TipoUsuarios = "Administrador")]
        [HttpPost]
        public ActionResult AnularPedidos(int id, PedidoDTO p) {
            try {
                CUAnularPedido.Anular(id);
                return RedirectToAction("Index", "Pedidos");
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }
            return View();
        }

        //--------------------------------------------------------------------------
        //----------------------------- BUSCAR -------------------------------------
        //--------------------------------------------------------------------------
        [Privado(TipoUsuarios = "Administrador")]
        public ActionResult BuscarPedidos() {
            return View();
        }

        [Privado(TipoUsuarios = "Administrador")]
        [HttpPost]
        public ActionResult BuscarPedidos(string fecha) {
            DateOnly fechaABuscar = DateOnly.Parse(fecha);
            List<PedidoNoEntregadoDTO> pedidos = CUBuscarPorFechaPedido.BuscarPorFechaPedido(fechaABuscar);
            if (pedidos.Count == 0) ViewBag.ErrorMsg = "No existen registros";
            return View(pedidos);
        }

        //--------------------------------------------------------------------------
        //------------------------ AGREGAR ARTICULO --------------------------------
        //--------------------------------------------------------------------------
        [Privado(TipoUsuarios = "Administrador")]
        public ActionResult AgregarArticulo(int id) {
            PedidoDTO p = CUBuscarPorIdPedido.BuscarPorId(id);
            ViewBag.Articulos = CUListadoArticulos.ObtenerListado();
            return View(p);
        }

        [Privado(TipoUsuarios = "Administrador")]
        [HttpPost]
        public ActionResult AgregarArticulo(int id, PedidoDTO p) {
            try {
                CUAgregarArticulo.Modificar(p);
                return RedirectToAction("Index", "Pedidos");
            } catch (RegistroNoExisteException e) {
                ViewBag.ErrorMsg = e.Message;
            } catch (NoStockException e) {
                ViewBag.ErrorMsg = e.Message;
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.ToString();
            }

            ViewBag.Articulos = CUListadoArticulos.ObtenerListado();
            return View(p);
        }
    }    
}
