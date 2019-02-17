
using Rent_Flat.App_Start;
using RepositorioRentFlat.Context;
using RepositorioRentFlat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Rent_Flat
{
    public class MvcApplication : System.Web.HttpApplication
    {
       
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //INYECCIÓN UNITY
            IoCConfigurationUnity.Configure();
        } 
        //LOGIN
        public void Application_PostAuthenticateRequest()
        {
            HttpCookie cookie = Request.Cookies["TICKETEMPLEADO"];
            if (cookie!=null)
            {
                String datos = cookie.Value;
                FormsAuthenticationTicket ticket= 
                    FormsAuthentication.Decrypt(datos);//desencriptamos el ticket
                                                       // String[] roles = { ticket.UserData };//los roles del usuario
                EntidadRenting entidad = new EntidadRenting();
                String empno = ticket.UserData;
                String username = ticket.Name;//nombre del usuario

                //creamos el usuario en la sesion
                GenericIdentity identidad = new GenericIdentity(username);
                //creamos usuario genérico, solo tiene nombre y rol

                Repository repo = new Repository(entidad);
                Usuarios usuario = repo.ExisteEmpleado(ticket.Name, ticket.UserData);
                if (usuario != null)
                {
                    usuario.Identity = identidad;
                    HttpContext.Current.User = usuario;
                }


                //GenericPrincipal usuario = new GenericPrincipal(identidad, roles);
                //HttpContext.Current.User = usuario;


            }
        }
    }
}
