using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Obligatorio.Filters {
    public class PrivadoAttribute : Attribute, IActionFilter {
        public string TipoUsuarios { get; set; }

        public void OnActionExecuted(ActionExecutedContext context) {
        }

        public void OnActionExecuting(ActionExecutingContext context) {
            bool usuarioAutenticado = !string.IsNullOrEmpty(context.HttpContext.Session.GetString("TIPOUSUARIO"));
            if (!usuarioAutenticado) {
                context.Result = new RedirectResult("/usuarios/ingresar");
            } else {
                if (!string.IsNullOrEmpty(TipoUsuarios)) {
                    if (!TipoUsuarios.Split(",").Contains(context.HttpContext.Session.GetString("TIPOUSUARIO")))
                        context.Result = new RedirectResult("/home/error");

                }
            }
        }
    }
}
