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
    public class BackCostasController : Controller
    {
        IRepository repo;
        public BackCostasController(Repository repo)
        {
            this.repo = repo;
        }
        // GET: BackCostas
        public ActionResult Nombre_Costas()
        {
            return View(this.repo.GetNombreCostas());
        }

        //GET: EDIT
        public ActionResult Edit(int id)
        {

            return View(this.repo.BuscarCosta(id));
        }
        [HttpPost]
        public ActionResult Edit(Costas c)
        {
            if (!ModelState.IsValid)
            {
                return View(c);
            }
            this.repo.ModificarCosta(c);
            return RedirectToAction("Nombre_Costas");
        }
        //----------------------------
        //GET: CREATE
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Costas costas)
        {
            if (!ModelState.IsValid)
            {
                return View(costas);
            }
            this.repo.InsertarCosta(costas);
            return RedirectToAction("Nombre_Costas");
        }
        //-----------------------
        //DELETE
        public ActionResult Delete(int id)
        {
            Costas costas = this.repo.BuscarCosta(id);
            return View(costas);
        }

        //Delete
        public ActionResult EliminarCostas(int id)
        {
            this.repo.EliminarCosta(id);
            return RedirectToAction("Nombre_Costas");
        }
    }
}