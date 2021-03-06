﻿using Rent_Flat.Atributos;
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
    public class BackClientesController : Controller
    {
        IRepository repo;
        public BackClientesController(Repository repo)
        {
            this.repo = repo;
        }
        //-------------------
        // GET: BackClientes
        public ActionResult Clientes()
        {
            return View(this.repo.GetClientes());
        }

        //---------------------------------
        [AutorizacionUsuarios(Roles = "Director")]
        public ActionResult Edit(int id)
        {
            List<SelectListItem> comboviviendas = new List<SelectListItem>();
            foreach (var item in this.repo.GetNombreCostas())
            {
                SelectListItem costa = new SelectListItem();
                costa.Value = item.NombreProvincia;
                costa.Text = item.NombreProvincia;
                comboviviendas.Add(costa);

            }
            ViewBag.ComboCostas = comboviviendas;
            return View(this.repo.BuscarClientes(id));
        }
        [HttpPost]

        public ActionResult Edit(Clientes c)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> comboviviendas = new List<SelectListItem>();
                foreach (var item in this.repo.GetNombreCostas())
                {
                    SelectListItem costa = new SelectListItem();
                    costa.Value = item.NombreProvincia;
                    costa.Text = item.NombreProvincia;
                    comboviviendas.Add(costa);

                }
                ViewBag.ComboCostas = comboviviendas;
                return View(c);
            }
            this.repo.ModificarClientes(c);



            return RedirectToAction("Clientes");
        }

        //----------------------------
        //GET: CREATE

        [AutorizacionUsuarios(Roles = "Director")]
        public ActionResult Create()
        {
            List<SelectListItem> comboviviendas = new List<SelectListItem>();
            foreach (var item in this.repo.GetNombreCostas())
            {
                SelectListItem costa = new SelectListItem();
                costa.Value = item.NombreProvincia;
                costa.Text = item.NombreProvincia;
                comboviviendas.Add(costa);

            }
            ViewBag.ComboCostas = comboviviendas;
            return View(new Clientes());
        }
        [HttpPost]
        public ActionResult Create(Clientes cl)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> comboviviendas = new List<SelectListItem>();
                foreach (var item in this.repo.GetNombreCostas())
                {
                    SelectListItem costa = new SelectListItem();
                    costa.Value = item.NombreProvincia;
                    costa.Text = item.NombreProvincia;
                    comboviviendas.Add(costa);

                }
                ViewBag.ComboCostas = comboviviendas;
                return View(cl);
            }
            this.repo.InsertarClientes(cl);
            return RedirectToAction("Clientes");
        }
        //------------------
        //-----------------------
        //DELETE
        [AutorizacionUsuarios(Roles = "Director")]

        public ActionResult Delete(int id)
        {
            Clientes cl = this.repo.BuscarClientes(id);
            return View(cl);
        }

        //Delete
        public ActionResult EliminarClientes(int id)
        {
            this.repo.EliminarClientes(id);
            return RedirectToAction("Clientes");
        }
    }
}