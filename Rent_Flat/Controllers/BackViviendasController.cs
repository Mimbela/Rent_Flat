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
            var listaTiposVivienda = new List<SelectListItem>();
            listaTiposVivienda.AddRange(this.repo.GetTiposViviendas().Select(x => new SelectListItem() { Value = x.Cod_tipo_vivienda.ToString(), Text = x.Descripcion }));
            ViewBag.listaTiposVivienda = listaTiposVivienda;
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
            var listaTiposVivienda = new List<SelectListItem>();
            foreach (var item in this.repo.GetTiposViviendas())
            {
                SelectListItem tipoVivienda = new SelectListItem();
                tipoVivienda.Value = item.Cod_tipo_vivienda.ToString();
                tipoVivienda.Text = item.Descripcion;
                listaTiposVivienda.Add(tipoVivienda);
            }


          //  listaTiposVivienda.AddRange(this.repo.GetTiposViviendas().Select(x => new SelectListItem() { Value = x.Cod_tipo_vivienda.ToString(), Text = x.Descripcion }));
            ViewBag.ListaTiposViviendaCreate = listaTiposVivienda;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Viviendas u)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.ListaTiposViviendaCreate.AddRange(this.repo.GetTiposViviendas().Select(x => new SelectListItem() { Value = x.Cod_tipo_vivienda.ToString(), Text = x.Descripcion }));
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