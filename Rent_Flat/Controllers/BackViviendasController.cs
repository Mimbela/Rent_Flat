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
    public class BackViviendasController : Controller
    {
        IRepository repo;

        public BackViviendasController(IRepository repo)
        {
            this.repo = repo;
        }
        // GET: BackViviendas
        public ActionResult Viviendas()
        {
            
            return View(this.repo.GetViviendas());
        }
        //-------------------------------------------------
        //EDIT
        [Authorize(Roles = "Director")]
        public ActionResult Edit(int id)
        {
            return View(this.repo.BuscarViviendas(id));

        }
        [HttpPost]
        public ActionResult Edit(Viviendas v)
        {
            if (!ModelState.IsValid)
            {
                return View(v);
            }
            this.repo.ModificarVivienda(v);
            return RedirectToAction("Viviendas");

        }
        //----------------------------
        //GET: CREATE
        [Authorize(Roles = "Director")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Viviendas u)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }
            this.repo.InsertarViviendas(u);
            return RedirectToAction("Viviendas");
        }
        //------------------------------------------
        //DELETE
        [Authorize(Roles = "Director")]
        public ActionResult Delete(int id)
        {
            Viviendas viviendas = this.repo.BuscarViviendas(id);
            return View(viviendas);
        }

      
        public ActionResult EliminarViviendas(int id)
        {
            this.repo.EliminarViviendas(id);
            return RedirectToAction("Viviendas");
        }
    }
}