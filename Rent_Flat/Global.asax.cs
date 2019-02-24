
using Rent_Flat.App_Start;
using Rent_Flat.Controllers;
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

        //-------------errores
        protected void Application_EndRequest()
        {
            var context = new HttpContextWrapper(Context);
            RouteData rutaerror = new RouteData();
            if (context.Response.StatusCode == 401)
            {
                rutaerror.Values.Add("controller", "Error");
                rutaerror.Values.Add("action", "PaginaNoEncontrada");
                //context.Response.Redirect("");
                IController controlador = new ErrorController();
                //MEDIANTE EL METODO Execute, REDIRIGIMOS
                //EL REQUEST, ENVIANDO EL CONTEXTO (Context)
                //Y RouteData
                controlador.Execute(
                new RequestContext(new HttpContextWrapper(Context), rutaerror));
            }

        }


            protected void Application_Error()
        {
            //DEBEMOS CAPTURAR LA EXCEPCION
            //QUE ESTA LLAMANDO AL METODO
            //ACTUALMENTE
            Exception ex = Server.GetLastError();
            //ESTAMOS EN ENTORNO HTTP
            //LAS EXCEPCIONES QUE DESEAMOS CAPTURAR
            //TIENEN CODIGOS HTTP
            //DEBEMOS CONVERTIR NUESTRO Exception GENERAL
            //A UN TIPO DE EXCEPCION HTTP
            HttpException exhttp = ex as HttpException;
            String action = "";
            if (exhttp.GetHttpCode() == 404)
            {
                action = "PaginaNoEncontrada";
            }
            else
            {
                action = "ErrorGeneral";
            }
            //EL OBJETO HTTPEXCEPTION CONTIENE
            //LOS CODIGOS DE ERROR HTTP
            //ALMACENAMOS LA ACCION DONDE DESEAMOS ENVIAR
            //DEPENDIENDO DE LOS ERRORES HTTP
            //    String accion = "";
            //    switch (httpexception.GetHttpCode())
            //    {
            //    case 404:
            //    accion = "PaginaNoEncontrada";
            //    break;
            //    case 403: //FORBIDDEN
            //    accion = "ErrorGeneral";
            //    break;

            //    default:
            //    accion = "ErrorGeneral";
            //    break;
            //}
            //AL CAPTURAR LA EXCEPCIONES GLOBALES
            //DEBEMOS LIMPIAR EL CONTEXTO DEL ERROR
            Context.ClearError();
            //REDIRECCIONAMOS, PERO NO LO VAMOS A HACER
            //CON ROUTING
            //VAMOS A ENVIAR LA PETICION REQUEST
            //DIRECTAMENTE AL CONTROLADOR Error
            //NECESITAMOS ROUTEDATA PARA INDICAR
            //DONDE VAMOS A DIRIGIRNOS
            RouteData ruta = new RouteData();
            //AÑADIMOS A LA RUTA EL CONTROLADOR
            //Y EL ACTION


            ruta.Values.Add("controller", "Error");
            ruta.Values.Add("action", action);
            //PARA PODER EJECUTAR LA PETICION A UN CONTROLADOR
            //CON UNA RUTA, NECESITAMOS LA CLASE IController
            //QUE PERMITE EJECUTAR OTRA PETICION






            IController controlador = new ErrorController();
            //MEDIANTE EL METODO Execute, REDIRIGIMOS
            //EL REQUEST, ENVIANDO EL CONTEXTO (Context)
            //Y RouteData
            controlador.Execute(
            new RequestContext(new HttpContextWrapper(Context), ruta));
        }
    }
        
    
}
