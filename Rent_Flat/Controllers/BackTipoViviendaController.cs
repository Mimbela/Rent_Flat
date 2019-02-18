using Rent_Flat.Atributos;
using RepositorioRentFlat;
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
    public class BackTipoViviendaController : Controller
    {
        IRepository repo;
        public BackTipoViviendaController(IRepository repo)
        {
            this.repo = repo;
        }


        // GET: BackTipoVivienda
        public ActionResult GetTiposVivienda()
        {

            return View(this.repo.GetTiposViviendas());
        }
        //---------------------------------------------------------------------
        //GET: EDIT
       
        [Authorize(Roles = "Director")]
        public ActionResult Edit(int id)
        {

            return View(this.repo.BuscarTipoVivienda(id));
        }
        [HttpPost]
        public ActionResult Edit(Tipos_Vivienda c)
        {
            if (!ModelState.IsValid)
            {
                return View(c);
            }
            this.repo.ModificarTipoVivienda(c);
            return RedirectToAction("GetTiposVivienda");
        }
        //----------------------------
        //GET: CREATE
       
        [Authorize(Roles = "Director")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tipos_Vivienda u)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }
            this.repo.InsertarTipoViviendas(u);
            return RedirectToAction("GetTiposVivienda");
        }

        //----------------------------
        //DELETE
   
        [Authorize(Roles = "Director")]
        public ActionResult Delete(int id)
        {
            Tipos_Vivienda tipos = this.repo.BuscarTipoVivienda(id);
            return View(tipos);
        }

      
        public ActionResult EliminarTipoVivienda(int id)
        {
            this.repo.EliminarTipoViviendas(id);
            return RedirectToAction("GetTiposVivienda");
        }
    }
}