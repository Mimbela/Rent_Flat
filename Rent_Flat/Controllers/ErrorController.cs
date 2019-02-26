using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Rent_Flat.Controllers
{
    public class ErrorController : Controller
    {
      
        public ActionResult PaginaNoEncontrada()
        {
            
            Response.StatusCode = 401;
            ViewBag.Mensaje = "No tienes permiso para acceder a este recurso";
            return View();
    }

        public ActionResult ErrorGeneral()
        {
            ViewBag.Mensaje = "Error general de la aplicación.";
            return View();
        }
    }
}