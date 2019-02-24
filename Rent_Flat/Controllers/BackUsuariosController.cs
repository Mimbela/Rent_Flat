using Rent_Flat.Atributos;
using RepositorioRentFlat.Context;
using RepositorioRentFlat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent_Flat.Controllers
{
   [AutorizacionUsuarios]
    [Authorize(Roles = "Director")]
    public class BackUsuariosController : Controller
    {
        IRepository repo;
        public BackUsuariosController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: BackUsuarios
        public ActionResult Usuarios()
        {

            return View(this.repo.GetUsuarios());
        }

        //GET:EDIT
        public ActionResult Edit(int id)
        {
            return View(this.repo.BuscarUsuario(id));

        }
        [HttpPost]
        public ActionResult Edit(Usuarios u)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }
            this.repo.ModificarUsuario(u);
            return RedirectToAction("Usuarios");
        }
        //----------------------------
        //GET: CREATE
        public ActionResult Create()
        {
            var algo = this.repo.ComboRolUsuario();
            List<SelectListItem> listaDePerfiles = new List<SelectListItem>();
            foreach(var item in algo)
            {
                SelectListItem Perfil = new SelectListItem()
                {
                    Value = item.Key.ToString(),
                    Text = item.Value
                };
                listaDePerfiles.Add(Perfil);

            }

            ViewBag.ListaPerfiles = listaDePerfiles;

            return View(new Usuarios());
        }
        [HttpPost]
        public ActionResult Create(Usuarios u)
        {
            var algo = this.repo.ComboRolUsuario();

            u.Perfil = algo.ContainsKey(u.DIR) ? algo[u.DIR] : null;


            if (!ModelState.IsValid)
            {
                List<SelectListItem> listaDePerfiles = new List<SelectListItem>();
                foreach (var item in algo)
                {
                    SelectListItem Perfil = new SelectListItem()
                    {
                        Value = item.Key.ToString(),
                        Text = item.Value
                    };
                    listaDePerfiles.Add(Perfil);
                }
                return View(u);
            }
            this.repo.InsertarUsuarios(u);
            return RedirectToAction("Usuarios");
        }
        //------------------------------------------------------
        //DELETE
        public ActionResult Delete(int id)
        {
            Usuarios usuarios = this.repo.BuscarUsuario(id);
            return View(usuarios);
        }

       
        public ActionResult EliminarUsuario(int id)
        {
            this.repo.EliminarUsuario(id);
            return RedirectToAction("Usuarios");
        }
    }
}
//permite que entre cualquiera
//[AllowAnonymous] 
//public ActionResult About() { }