using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent_Flat.Controllers
{
    public class PaginasSecundariasController : Controller
    {
        // GET: PaginasSecundarias
        public ActionResult AcercaDeNosotros()
        {
            return View();
        }


        //---------------------------------------CONTACTO
        public ActionResult Contacto()
        {
            return View();
        }

        //------------------------------------PISOS EN ALQUILER
        public ActionResult Alquiler()
        {
            return View();
        }
    }
}