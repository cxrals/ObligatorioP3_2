using DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ObligatorioMVC.Controllers {
    public class UsuariosController : Controller {
        public string UrlApi;

        public UsuariosController(IConfiguration config) {
            UrlApi = config.GetValue<string>("ApiUrl");
        }

        //--------------------------------------------------------------------------
        //---------------------------- INGRESAR ------------------------------------
        //--------------------------------------------------------------------------
        public IActionResult Ingresar() {
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(UsuarioDTO usuarioDTO) { 
            try {
                HttpClient client = new HttpClient();
                string url = UrlApi + "Usuarios/Ingresar";
                var tarea = client.PostAsJsonAsync(url, usuarioDTO);
                tarea.Wait();

                var respuesta = tarea.Result;
                HttpContent content = respuesta.Content;
                var tarea2 = content.ReadAsStringAsync();
                tarea2.Wait();
                string cuerpo = tarea2.Result;
                ViewBag.ErrorMsg = respuesta.Content.ReadAsStringAsync().Result;

                if (respuesta.IsSuccessStatusCode) {
                    UsuarioAutenticadoDTO usuarioAutenticado = JsonConvert.DeserializeObject<UsuarioAutenticadoDTO>(cuerpo);

                    if (usuarioAutenticado != null) {
                        HttpContext.Session.SetString("Email", usuarioAutenticado.Email);
                        HttpContext.Session.SetString("Rol", usuarioAutenticado.Tipo);
                        HttpContext.Session.SetString("Token", usuarioAutenticado.Token);

                        return RedirectToAction("Index", "MovimientosStock");
                    } else {
                        ViewBag.ErrorMsg = "Credenciales incorrectas";
                    }
                } else {
                    ViewBag.ErrorMsg = respuesta.Content.ReadAsStringAsync().Result;
                }
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }

            return View();
        }

        public IActionResult CerrarSesion() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //// GET: UsuariosController
        //public ActionResult Index() {
        //return View();
        //}

        //// GET: UsuariosController/Details/5
        //public ActionResult Details(int id) {
        //    return View();
        //}

        //// GET: UsuariosController/Create
        //public ActionResult Create() {
        //    return View();
        //}

        //// POST: UsuariosController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection) {
        //    try {
        //        return RedirectToAction(nameof(Index));
        //    } catch {
        //        return View();
        //    }
        //}

        //// GET: UsuariosController/Edit/5
        //public ActionResult Edit(int id) {
        //    return View();
        //}

        //// POST: UsuariosController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection) {
        //    try {
        //        return RedirectToAction(nameof(Index));
        //    } catch {
        //        return View();
        //    }
        //}

        //// GET: UsuariosController/Delete/5
        //public ActionResult Delete(int id) {
        //    return View();
        //}

        //// POST: UsuariosController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection) {
        //    try {
        //        return RedirectToAction(nameof(Index));
        //    } catch {
        //        return View();
        //    }
        //}
    }
}
