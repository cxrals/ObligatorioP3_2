using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.Controllers {
    public class ArticulosController : Controller {
        public ICUAlta<Articulo> CUAlta { get; set; }
        public ICUBaja<Articulo> CUBaja { get; set; }
        public ICUListado<Articulo> CUListado { get; set; }
        public ICUModificar<Articulo> CUModificar { get; set; }
        public ICUBuscarPorId<Articulo> CUBuscarPorIdArticulo { get; set; }

        public ArticulosController(ICUAlta<Articulo> cuAlta, ICUListado<Articulo> cuListado, ICUBuscarPorId<Articulo> cuBuscarPorIdArticulo, ICUModificar<Articulo> cuModificar, ICUBaja<Articulo> cuBaja) {
            CUAlta = cuAlta;
            CUBaja = cuBaja;
            CUListado = cuListado;
            CUModificar = cuModificar;
            CUBuscarPorIdArticulo = cuBuscarPorIdArticulo;
        }

        public IActionResult Index() {
            return View(CUListado.ObtenerListado());
        }

        //--------------------------------------------------------------------------
        //----------------------------- CREATE -------------------------------------
        //--------------------------------------------------------------------------
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Articulo nuevo) {
            try {
                CUAlta.Alta(nuevo);
                return RedirectToAction("Index", "Articulos");
            } catch (DatosInvalidosException e) {
                ViewBag.ErrorMsg = e.Message;
            } catch (DuplicadoException e) {
                ViewBag.ErrorMsg = e.Message;
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }

            return View();
        }

        //--------------------------------------------------------------------------
        //----------------------------- UPDATE -------------------------------------
        //--------------------------------------------------------------------------
        public ActionResult Edit(int id) {
            Articulo a = CUBuscarPorIdArticulo.BuscarPorId(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult Edit(int id, Articulo a) {
            try {
                CUModificar.Modificar(a);
                return RedirectToAction("Index", "Articulos");
            } catch (DatosInvalidosException e) {
                ViewBag.ErrorMsg = e.Message;
            } catch (DuplicadoException e) {
                ViewBag.ErrorMsg = e.Message;
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }

            return View();
        }

        //--------------------------------------------------------------------------
        //----------------------------- DELETE -------------------------------------
        //--------------------------------------------------------------------------
        public ActionResult Delete(int id) {
            Articulo a = CUBuscarPorIdArticulo.BuscarPorId(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult Delete(int id, Articulo a) {
            try {
                CUBaja.Baja(id);
                return RedirectToAction("Index", "Articulos");
            } catch (RegistroNoExisteException e) {
                ViewBag.ErrorMsg = e.Message;
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }
            return View();
        }
    }
}
