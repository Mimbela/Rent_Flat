using Rent_Flat.Models;
using RepositorioRentFlat.Context;
using RepositorioRentFlat.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent_Flat.Controllers
{
    public class HomeController : Controller
    {
        Repository repo;
        public HomeController(Repository repo)
        {
            this.repo = repo;
        }
        // GET: Home
        public ActionResult Index()
        {
            var tiposVivienda = this.repo.GetTiposViviendas();
            var costas = this.repo.GetNombreCostas();

            BusquedaModel busquedaModel = new BusquedaModel();

            busquedaModel.TiposVivienda.AddRange(tiposVivienda.Select(x => new SelectListItem() { Value = x.Cod_tipo_vivienda.ToString(), Text = x.Descripcion }));
            busquedaModel.ListaCostas.AddRange(costas.Select(x => new SelectListItem() { Value = x.Cod_Provincia.ToString(), Text = x.NombreProvincia }));

            return View(busquedaModel);
        }
        [HttpPost]
        public ActionResult ListaPisosPorFiltro(BusquedaModel busqueda)
        {

            return View(this.repo.GetViviendasByFilter(busqueda.TiposViviendaSelectedValue, busqueda.CostasSelectedValue, busqueda.NumeroBaniosSelectedValue, busqueda.NumeroHabitacionesSelectedValue));
        }
    }
}