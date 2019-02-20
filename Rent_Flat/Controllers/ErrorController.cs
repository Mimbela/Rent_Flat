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
            //HttpStatusCode.Unauthorized    //401 -->no autorizado
            //Response.StatusCode =(int)HttpStatusCode.Unauthorized;//not found
            //ViewBag.Mensaje = "El usuario no tiene permiso para acceder a este sitio";
            //return View();
            // Response.StatusCode = (int) HttpStatusCode.NotFound;
            Response.StatusCode = 401;
            ViewBag.Mensaje = "Página no encontrada en el servidor.";
            return View();
    }

        public ActionResult ErrorGeneral()
        {
            ViewBag.Mensaje = "Error general de la aplicación.";
            return View();
        }
    }
}