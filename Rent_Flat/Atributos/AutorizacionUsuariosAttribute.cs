using RepositorioRentFlat.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Rent_Flat.Atributos
{
    public class AutorizacionUsuariosAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            //RouteValueDictionary ruta;//a que controler y action queremos enviar
            //RedirectToRouteResult direccion;//para realizar la acción de redirección

            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //si quiero que entren todos los empleados, no escribo nada
                //pero si queremos hacer el login por rol, sí escribimos

                // GenericPrincipal usuario = filterContext.HttpContext.User as GenericPrincipal;
                Usuarios usuario = filterContext.HttpContext.User as Usuarios;
                if (usuario.Perfil !="Director"){ }
                if (usuario.IsInRole("Director")==false)
                {
                    filterContext.Result =
                       GetRutaRedirect("Validacion", "ErrorAcceso");
                }

            }
            else
            {
                //ruta = new RouteValueDictionary(
                //    new { controller = "Validacion", action = "Login" });
                //direccion = new RedirectToRouteResult(ruta);
                filterContext.Result = GetRutaRedirect("Validacion", "Login");
            }

        }
        public RedirectToRouteResult GetRutaRedirect(String controlador, String accion)
        {
           RouteValueDictionary ruta = new RouteValueDictionary(new { controller = controlador, action = accion });
           RedirectToRouteResult direccion = new RedirectToRouteResult(ruta);
            return direccion;
        }
    }
}