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
        IRepository repo;
        public HomeController(IRepository repo)
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
            if (busqueda is null) busqueda = new BusquedaModel();
            busqueda.Cod_Casa = 0;
            busqueda.Cod_Cliente = 0;

            return View(this.repo.GetViviendasByFilter(busqueda.TiposViviendaSelectedValue, busqueda.CostasSelectedValue, busqueda.NumeroBaniosSelectedValue, busqueda.NumeroHabitacionesSelectedValue, busqueda.Cod_Casa, busqueda.Cod_Cliente));
        }

       

        public ActionResult Property(int cod_casa)//para sacar una casa para la descripción
        {
            int tipoVivienda = 0;
            int costa = 0;
            int num_banios = 0;
            int num_habitaciones = 0;
            int IdCliente = 0;
            var propiedad = this.repo.GetViviendasByFilter(tipoVivienda, costa, num_banios, num_habitaciones, cod_casa, IdCliente).FirstOrDefault();
            return View(propiedad);
        }

        //-------------------------------------------------------------------------------
        public ActionResult ListaPisosPorFiltro()
        {
            BusquedaModel busqueda = new BusquedaModel();
            var resultado = this.repo.GetViviendasByFilter(busqueda.TiposViviendaSelectedValue, busqueda.CostasSelectedValue, busqueda.NumeroBaniosSelectedValue, busqueda.NumeroHabitacionesSelectedValue, busqueda.Cod_Casa, busqueda.Cod_Cliente);
            return View(resultado);
        }
    }
}

#region
//namespace RepositorioRentFlat.Context
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Security.Principal;

//    public partial class Usuarios : IPrincipal
//    {
//        public int Cod_usuario { get; set; }
//        public string Login { get; set; }
//        public string Password { get; set; }
//        public string Nombre { get; set; }
//        public string Apellido { get; set; }
//        public int DIR { get; set; }
//        public string Email { get; set; }
//        public string Telefono { get; set; }
//        public bool Mostrar_info_contacto { get; set; }
//        public string Perfil { get; set; }
//        public Usuarios(IIdentity identidad)
//        {
//            this.Identity = identidad;
//        }
//        public Usuarios() { }
//        public bool IsInRole(string role)
//        {
//            if (this.Perfil.ToUpper() == role.ToUpper())
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//            //foreach (String r in this.Roles)
//            //{
//            //    if (r.ToUpper() == role.ToUpper())
//            //    {
//            //        return true;
//            //    }
//            //}
//            //return false;
//        }
//        public IIdentity Identity { get; set; }
//    }
//}
#endregion