using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Obligatorio.Models;
using LogicaNegocio.Excepciones;
using Obligatorio.Filters;
using DataTransferObjects;
using Newtonsoft.Json;

namespace Obligatorio.Controllers {
    public class UsuariosController : Controller {
        public ICUAlta<Usuario> CUAlta { get; set; }
        public ICUBaja<Usuario> CUBaja { get; set; }
        public ICUListado<Usuario> CUListado { get; set; }
        public ICUModificar<Usuario> CUModificar { get; set; }
        public ICUAutenticarUsuario CUAutenticarUsuario { get; set; }
        public ICUBuscarPorId<Usuario> CUBuscarPorIdUsuario { get; set; }

        public UsuariosController(ICUAutenticarUsuario cuAutenticarUsuario, ICUAlta<Usuario> cuAlta, ICUListado<Usuario> cuListado, ICUModificar<Usuario> cuModificar, ICUBuscarPorId<Usuario> cuBuscarPorIdUsuario, ICUBaja<Usuario> cuBaja) {
            CUAutenticarUsuario = cuAutenticarUsuario;
            CUAlta = cuAlta;
            CUListado = cuListado;
            CUModificar = cuModificar;
            CUBuscarPorIdUsuario = cuBuscarPorIdUsuario;
            CUBaja = cuBaja;
        }

        [Privado(TipoUsuarios = "Administrador")]
        public IActionResult Index() {
            return View(CUListado.ObtenerListado());
        }

        //--------------------------------------------------------------------------
        //---------------------------- INGRESAR ------------------------------------
        //--------------------------------------------------------------------------
        public IActionResult Ingresar() {
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(IngresarViewModel model) {
            if (!ModelState.IsValid) {
                ViewBag.Error = "Email o Contraseña no pueden ser vacíos";
                return View();
            }

            UsuarioDTO usuarioDTO = CUAutenticarUsuario.Autenticar(model.Email, model.Password);
            
            if (usuarioDTO != null) { 
                HttpContext.Session.SetString("Email", model.Email);
                HttpContext.Session.SetString("TIPOUSUARIO", usuarioDTO.Tipo);
                return RedirectToAction("Index", "Home");
            }

            HttpContext.Session.Clear();

            ViewBag.Error = "Las credenciales no son correctas.";
            return View();
        }

        public IActionResult CerrarSesion() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //--------------------------------------------------------------------------
        //----------------------------- CREATE -------------------------------------
        //--------------------------------------------------------------------------
        [Privado(TipoUsuarios = "Administrador")]
        public ActionResult Create() {
            return View();
        }

        [Privado(TipoUsuarios = "Administrador")]
        [HttpPost]
        public ActionResult Create(Usuario nuevo) {
            try {
                CUAlta.Alta(nuevo);
                return RedirectToAction("Index", "Usuarios");
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
        [Privado(TipoUsuarios = "Administrador")]
        public ActionResult Edit(int id) {
            Usuario u = CUBuscarPorIdUsuario.BuscarPorId(id);
            return View(u);
        }

        [Privado(TipoUsuarios = "Administrador")]
        [HttpPost]
        public ActionResult Edit(int id, Usuario u) {
            try {
                CUModificar.Modificar(u);
                return RedirectToAction("Index", "Usuarios");
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
        [Privado(TipoUsuarios = "Administrador")]
        public ActionResult Delete(int id) {
            Usuario u = CUBuscarPorIdUsuario.BuscarPorId(id);
            return View(u);
        }

        [Privado(TipoUsuarios = "Administrador")]
        [HttpPost]
        public ActionResult Delete(int id, Usuario u) {
            try {
                CUBaja.Baja(id);
                return RedirectToAction("Index", "Usuarios");
            } catch (RegistroNoExisteException e) {
                ViewBag.ErrorMsg = e.Message;
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }
            return View();
        }
    }
}
