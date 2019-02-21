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

    public class BackHomeController : Controller
    {

        IRepository repo;
        public BackHomeController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: BackHome
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //-----------------------------------PAGINACIÓN CLIENTES EN VISTA PARCIAL
        public ActionResult Index(int? indice)//lo haré con linq//? son opcionales
        {
            if (indice==null)
            {
                indice = 0;
            }

            int numeroregistros = 0;
            List<VISTATODOSCLIENTES> clientes = this.repo.PaginarClientes(indice.GetValueOrDefault(),ref numeroregistros);
            ViewBag.Registros = numeroregistros;
            
            return View(clientes);
        }
    }
}