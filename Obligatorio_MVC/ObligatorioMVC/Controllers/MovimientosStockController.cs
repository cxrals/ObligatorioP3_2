﻿using DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Obligatorio.Filters;

namespace ObligatorioMVC.Controllers {
    public class MovimientosStockController : Controller {

        public string UrlApi;

        public MovimientosStockController(IConfiguration config) {
            UrlApi = config.GetValue<string>("ApiUrl");
        }

        // GET: MovimientosStockController
        [Privado(TipoUsuarios = "Encargado")]
        public ActionResult Index() {
            List<MovimientoStockIndexDTO> movimientosDeStock = new List<MovimientoStockIndexDTO>();

            try{
                HttpClient client = new HttpClient();
                string url = UrlApi + "movimientosStock";
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                var tarea = client.GetAsync(url);
                tarea.Wait();
                var respuesta = tarea.Result;
                HttpContent content = respuesta.Content;
                var tarea2 = content.ReadAsStringAsync();
                tarea2.Wait();
                string cuerpo = tarea2.Result;
                if (respuesta.IsSuccessStatusCode) {
                    movimientosDeStock = JsonConvert.DeserializeObject<List<MovimientoStockIndexDTO>>(cuerpo);
                }
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }
            
            return View(movimientosDeStock);
        }

        // GET: MovimientosStockController/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        //--------------------------------------------------------------------------
        //----------------------------- CREATE -------------------------------------
        //--------------------------------------------------------------------------

        // GET: MovimientosStockController/Create
        [Privado(TipoUsuarios = "Encargado")]
        public ActionResult Create() {
            MovimientoStockDTO movimientoDeStock = new MovimientoStockDTO();
            try {
                movimientoDeStock.Articulos = ObtenerArticulos();
                movimientoDeStock.TiposMovimientos = ObtenerTiposDeMovimientos();
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }
            return View(movimientoDeStock);
        }

        // POST: MovimientosStockController/Create
        [HttpPost]
        [Privado(TipoUsuarios = "Encargado")]
        public ActionResult Create(MovimientoStockDTO movimientoDeStock) {
            movimientoDeStock.EmailUsuario = HttpContext.Session.GetString("Email");
            try {
                HttpClient cliente = new HttpClient();
                string url = UrlApi + "movimientosStock";
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                var tarea = cliente.PostAsJsonAsync(url, movimientoDeStock);
                tarea.Wait();
                var respuesta = tarea.Result;

                HttpContent content = respuesta.Content;
                var tarea2 = content.ReadAsStringAsync();
                tarea2.Wait();
                string cuerpo = tarea2.Result;

                if (respuesta.IsSuccessStatusCode) {
                    return RedirectToAction(nameof(Index));
                } else {
                    ViewBag.ErrorMsg = respuesta.Content.ReadAsStringAsync().Result;
                }
            } catch { }
            movimientoDeStock.Articulos = ObtenerArticulos();
            movimientoDeStock.TiposMovimientos = ObtenerTiposDeMovimientos();
            return View(movimientoDeStock);
        }

        //--------------------------------------------------------------------------
        //----------------------------- BUSCAR -------------------------------------
        //--------------------------------------------------------------------------
        public ActionResult BuscarPorFecha() {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarPorFecha(string desde, string hasta) {
           List<ArticuloDTO> articulosConMovimientosDeStock = new List<ArticuloDTO>();

            try {
                HttpClient client = new HttpClient();
                string url = UrlApi + "MovimientosStock/MovimientosPorFecha/" + desde + "/" + hasta;
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                var tarea = client.GetAsync(url);
                tarea.Wait();
                var respuesta = tarea.Result;
                HttpContent content = respuesta.Content;
                var tarea2 = content.ReadAsStringAsync();
                tarea2.Wait();
                string cuerpo = tarea2.Result;
                if (respuesta.IsSuccessStatusCode) {
                    articulosConMovimientosDeStock = JsonConvert.DeserializeObject<List<ArticuloDTO>>(cuerpo);
                } else {
                    ViewBag.ErrorMsg = respuesta.Content.ReadAsStringAsync().Result;
                }
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }

            return View(articulosConMovimientosDeStock);
        }

        public ActionResult BuscarPorArticuloYTipo() {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarPorArticuloYTipo(int idArticulo, string tipoMovimiento, int? page) {
            List<MovimientoStockIndexDTO> movimientosDeStock = new List<MovimientoStockIndexDTO>();
            if (page == null) page = 1;

            try {
                HttpClient client = new HttpClient();
                //todo no funca pa null tm
                string url = UrlApi + $"MovimientosStock/MovimientosPorArticuloYTipo/{idArticulo}/{tipoMovimiento}/{page}";
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                var tarea = client.GetAsync(url);
                tarea.Wait();
                var respuesta = tarea.Result;

                HttpContent content = respuesta.Content;
                var tarea2 = content.ReadAsStringAsync();
                tarea2.Wait();
                string cuerpo = tarea2.Result;

                if (respuesta.IsSuccessStatusCode) {
                    movimientosDeStock = JsonConvert.DeserializeObject<List<MovimientoStockIndexDTO>>(cuerpo);
                    double cantidadPaginas = ObtenerCantidadPaginas(idArticulo, tipoMovimiento);
                    ViewBag.Paginas = Math.Ceiling(cantidadPaginas);
                    ViewBag.ArticuloId = idArticulo;
                    ViewBag.TipoMov = tipoMovimiento;
                } else {
                    ViewBag.ErrorMsg = respuesta.Content.ReadAsStringAsync().Result;
                }
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }

            return View(movimientosDeStock);
        }

        //--------------------------------------------------------------------------
        //----------------------------- RESUMEN ------------------------------------
        //--------------------------------------------------------------------------
        public ActionResult ObtenerResumen() {
            List<MovimientoCantidadPorAnioYTipoDTO> movimientosDeStock = new List<MovimientoCantidadPorAnioYTipoDTO>();

            try {
                HttpClient client = new HttpClient();
                string url = UrlApi + "MovimientosStock/ResumenMovimientos";
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                var tarea = client.GetAsync(url);
                tarea.Wait();
                var respuesta = tarea.Result;
                HttpContent content = respuesta.Content;
                var tarea2 = content.ReadAsStringAsync();
                tarea2.Wait();
                string cuerpo = tarea2.Result;
                if (respuesta.IsSuccessStatusCode) {
                    movimientosDeStock = JsonConvert.DeserializeObject<List<MovimientoCantidadPorAnioYTipoDTO>>(cuerpo);
                }
            } catch (Exception e) {
                ViewBag.ErrorMsg = e.Message;
            }

            return View(movimientosDeStock);
        }

        //--------------------------------------------------------------------------
        //----------------------------- UTILS --------------------------------------
        //--------------------------------------------------------------------------
        public List<ArticuloDTO> ObtenerArticulos() {
            List<ArticuloDTO> articulos = new List<ArticuloDTO>();

            HttpClient cliente = new HttpClient();
            string url = UrlApi + "articulos";
            var tarea = cliente.GetAsync(url);
            tarea.Wait();
            var respuesta = tarea.Result;
            HttpContent content = respuesta.Content;
            var tarea2 = content.ReadAsStringAsync();
            tarea2.Wait();
            string cuerpo = tarea2.Result;
            if (respuesta.IsSuccessStatusCode) {
                articulos = JsonConvert.DeserializeObject<List<ArticuloDTO>>(cuerpo);
            }

            return articulos;
        }

        public List<TipoMovimientoDTO> ObtenerTiposDeMovimientos() {
            List<TipoMovimientoDTO> tiposDeMovimientos = new List<TipoMovimientoDTO>();

            HttpClient cliente = new HttpClient();
            string url = UrlApi + "tiposMovimientos";
            var tarea = cliente.GetAsync(url);
            tarea.Wait();
            var respuesta = tarea.Result;
            HttpContent content = respuesta.Content;
            var tarea2 = content.ReadAsStringAsync();
            tarea2.Wait();
            string cuerpo = tarea2.Result;
            if (respuesta.IsSuccessStatusCode) {
                tiposDeMovimientos = JsonConvert.DeserializeObject<List<TipoMovimientoDTO>>(cuerpo);
            }

            return tiposDeMovimientos;
        }

        public double ObtenerCantidadPaginas(int idArticulo, string tipoMovimiento) {
            double cantidadPaginas = 0;
            try {
                HttpClient cliente = new HttpClient();
                string url = UrlApi + $"MovimientosStock/CantidadDePaginas/{idArticulo}/{tipoMovimiento}"; ;
                var tarea = cliente.GetAsync(url);
                tarea.Wait();
                var respuesta = tarea.Result;

                HttpContent content = respuesta.Content;
                var tarea2 = content.ReadAsStringAsync();
                tarea2.Wait();
                string contenido = tarea2.Result;

                if (respuesta.IsSuccessStatusCode) {
                    contenido = contenido.Replace(".", ",");
                    double.TryParse(contenido, out cantidadPaginas);
                } else if ((int)respuesta.StatusCode == StatusCodes.Status400BadRequest || (int)respuesta.StatusCode == StatusCodes.Status500InternalServerError) {
                    cantidadPaginas = -1;
                }
            } catch (Exception ex) {
                throw;
            }
            return cantidadPaginas;
        }

    }
}
