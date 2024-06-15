using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using DataTransferObjects;

namespace Obligatorio.Controllers {
    public class ClientesController : Controller {
        public ICUListado<ClienteDTO> CUListado { get; set; }
        public ICUBuscarPorRazonSocial CUBuscarPorRazonSocial { get; set; }
        public ICUBuscarClientesPorMontoPedido CUBuscarClientesPorMontoPedido { get; set; }

        public ClientesController(ICUListado<ClienteDTO> cuListado, ICUBuscarPorRazonSocial cuBuscarPorRazonSocial, ICUBuscarClientesPorMontoPedido cuBuscarClientesPorMontoPedido)
        {
            CUListado = cuListado;
            CUBuscarPorRazonSocial = cuBuscarPorRazonSocial;
            CUBuscarClientesPorMontoPedido = cuBuscarClientesPorMontoPedido;
        }

        public IActionResult Index() {
            return View(CUListado.ObtenerListado());
        }

        public ActionResult BuscarClientes() {
            return View(CUListado.ObtenerListado());
        }

        [HttpPost]
        public ActionResult BuscarClientes(string razonSocial) {
            List<ClienteDTO> clientes = CUBuscarPorRazonSocial.BuscarPorRazonSocial(razonSocial);
            if (clientes.Count == 0) ViewBag.ErrorMsg = "No existen registros";
            return View(clientes);
        }

        public ActionResult BuscarPorMonto() {
            return View(CUListado.ObtenerListado());
        }

        [HttpPost]
        public ActionResult BuscarPorMonto(decimal monto) {
            try {
                List<ClienteDTO> clientes = CUBuscarClientesPorMontoPedido.BuscarPorMontoPedido(monto);
                return View(clientes);
            } catch (RegistroNoExisteException e) {
                ViewBag.ErrorMsg = e.Message;
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }
            return View();
        }
    }
}
