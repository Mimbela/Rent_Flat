using Rent_Flat.Services;
using RepositorioRentFlat.Context;
using RepositorioRentFlat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Rent_Flat.Controllers
{
    public class ValidacionController : Controller
    {
        IRepository repo;
        public ValidacionController(IRepository repo)
        {
            this.repo = repo;
        }
        // GET: Validacion
        public ActionResult Login()
        {
            return View();
        }
        //post :login
        [HttpPost]
        public ActionResult Login(String login , String password)
        {
            var encodingService = new EncodingService();
            var cryptedPassword = encodingService.SHA256(password);
            Usuarios usuarios = this.repo.ExisteEmpleado(login, cryptedPassword);
            if (usuarios!=null)
            {
                FormsAuthenticationTicket ticket =
                    new FormsAuthenticationTicket
                    (1, login, DateTime.Now, DateTime.Now.AddMinutes(30), true, usuarios.Password);
                String cifrado = FormsAuthentication.Encrypt(ticket);//ciframos el ticket
                //creamos la cookie con los datos cifrados
                HttpCookie cookie = new HttpCookie("TICKETEMPLEADO", cifrado);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "BackHome");
               // return View();

            }
            else
            {
                ViewBag.Mensaje = "Usuario/Password incorrectos";
            }
            return View();
        }
       
        public ActionResult ErrorAcceso()
        {

            return View();
        }
        public ActionResult CerrarSesion()
        {
            //DEBEMOS QUITAR AL USUARIO Y SU IDENTIDAD
            HttpContext.User = null;
            //SALIR DE LA AUTENTIFICACION
            FormsAuthentication.SignOut();
            //RECUPERAR LA COOKIE Y EXPIRARLA
            HttpCookie cookie = Request.Cookies["TICKETEMPLEADO"];
            cookie.Expires = DateTime.Now.AddYears(-1);
            //VOLVER A ESCRIBIR LA COOKIE
            Response.Cookies.Add(cookie);
            //DONDE ME LO LLEVO????
            return
                RedirectToAction("Index", "BackHome");
        }
    }
}
//prueba 

    //control de usuarios(repo)
    //crear la cookie(login)
    //3º usuario en la Seesion (Global.assax)
    //4º atributos de autorización (decoración)

    //ticket-->explorador del cliente
    //session-->se guarda en el servidor