using Rent_Flat.Atributos;
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

          //  var listaTiposVivienda = new List<SelectListItem>();

            var listaTiposVivienda = new List<SelectListItem>();
            foreach (var item in this.repo.GetTiposViviendas())
            {
                SelectListItem tipoVivienda = new SelectListItem();
                tipoVivienda.Value = item.Cod_tipo_vivienda.ToString();
                tipoVivienda.Text = item.Descripcion;
                listaTiposVivienda.Add(tipoVivienda);
            }

            List<SelectListItem> comboviviendas = new List<SelectListItem>();
            foreach (var item in this.repo.GetNombreCostas())
            {
                SelectListItem costa = new SelectListItem();
                costa.Value = item.Cod_Provincia.ToString();
                costa.Text = item.NombreProvincia;
                comboviviendas.Add(costa);

            }
           

            List<SelectListItem> comboclientes = new List<SelectListItem>();
            foreach (var item in this.repo.GetClientes())
            {
                SelectListItem cliente = new SelectListItem();
                cliente.Value = item.IdCliente.ToString();
                cliente.Text = item.NombreCliente + " " + item.ApellidoCliente;
                comboclientes.Add(cliente);

            }

            ViewBag.ComboCostas = comboviviendas;
            ViewBag.comboclientes = comboclientes;
            ViewBag.listaTiposVivienda = listaTiposVivienda;


            //  listaTiposVivienda.AddRange(this.repo.GetTiposViviendas().Select(x => new SelectListItem() { Value = x.Cod_tipo_vivienda.ToString(), Text = x.Descripcion }));
            //  ViewBag.ListaTiposViviendaCreate = listaTiposVivienda;

            //  listaTiposVivienda.AddRange(this.repo.GetTiposViviendas().Select(x => new SelectListItem() { Value = x.Cod_tipo_vivienda.ToString(), Text = x.Descripcion }));

            return View(this.repo.BuscarViviendas(id));

        }
        [HttpPost]
        public ActionResult Edit(Viviendas v)
        {
           
            List<SelectListItem> comboviviendas = new List<SelectListItem>();
            foreach (var item in this.repo.GetNombreCostas())
            {
                SelectListItem costa = new SelectListItem();
                costa.Value = item.Cod_Provincia.ToString();
                costa.Text = item.NombreProvincia;
                comboviviendas.Add(costa);

            }
            ViewBag.ComboCostas = comboviviendas;
            v.Ciudad = comboviviendas.Where(x => x.Value == v.Cod_Provincia.ToString()).Select(x => x.Text).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                var listaTiposVivienda = new List<SelectListItem>();
                foreach (var item in this.repo.GetTiposViviendas())
                {
                    SelectListItem tipoVivienda = new SelectListItem();
                    tipoVivienda.Value = item.Cod_tipo_vivienda.ToString();
                    tipoVivienda.Text = item.Descripcion;
                    listaTiposVivienda.Add(tipoVivienda);
                }

              


                List<SelectListItem> comboclientes = new List<SelectListItem>();
                foreach (var item in this.repo.GetClientes())
                {
                    SelectListItem cliente = new SelectListItem();
                    cliente.Value = item.IdCliente.ToString();
                    cliente.Text = item.NombreCliente + " " + item.ApellidoCliente;
                    comboclientes.Add(cliente);

                }

                
                ViewBag.comboclientes = comboclientes;
                ViewBag.listaTiposVivienda = listaTiposVivienda;

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

            List<SelectListItem> comboviviendas = new List<SelectListItem>();
            foreach (var item in this.repo.GetNombreCostas())
            {
                SelectListItem costa = new SelectListItem();
                costa.Value = item.Cod_Provincia.ToString();
                costa.Text = item.NombreProvincia;
                comboviviendas.Add(costa);

            }
            ViewBag.ComboCostas = comboviviendas;

            List<SelectListItem> comboclientes = new List<SelectListItem>();
            foreach (var item in this.repo.GetClientes())
            {
                SelectListItem cliente = new SelectListItem();
                cliente.Value = item.IdCliente.ToString();
                cliente.Text = item.NombreCliente + " "+ item.ApellidoCliente;
                comboclientes.Add(cliente);

            }
            ViewBag.comboclientes = comboclientes;



            //  listaTiposVivienda.AddRange(this.repo.GetTiposViviendas().Select(x => new SelectListItem() { Value = x.Cod_tipo_vivienda.ToString(), Text = x.Descripcion }));
            ViewBag.ListaTiposViviendaCreate = listaTiposVivienda;
            return View(new ViviendasViewModel(){});
        }
        [HttpPost]
        public ActionResult Create(ViviendasViewModel u, HttpPostedFileBase ImgData)
        {
            string fileContent = string.Empty;
            string fileContentType = string.Empty;

            List<SelectListItem> comboviviendas = new List<SelectListItem>();
            foreach (var item in this.repo.GetNombreCostas())
            {
                SelectListItem costa = new SelectListItem();
                costa.Value = item.Cod_Provincia.ToString();
                costa.Text = item.NombreProvincia;
                comboviviendas.Add(costa);

            }
            ViewBag.ComboCostas = comboviviendas;
            u.Ciudad = comboviviendas.Where(x => x.Value == u.Cod_Provincia.ToString()).Select(x=>x.Text).FirstOrDefault();
            

            if (!ModelState.IsValid || ImgData == null)
            {
                List<SelectListItem> comboclientes = new List<SelectListItem>();
                foreach (var item in this.repo.GetClientes())
                {
                    SelectListItem cliente = new SelectListItem();
                    cliente.Value = item.IdCliente.ToString();
                    cliente.Text = item.NombreCliente + " " + item.ApellidoCliente;
                    comboclientes.Add(cliente);

                }
                ViewBag.comboclientes = comboclientes;

                var list = this.repo.GetTiposViviendas().Select(x => new SelectListItem() { Value = x.Cod_tipo_vivienda.ToString(), Text = x.Descripcion });


                ViewBag.ListaTiposViviendaCreate = new List<SelectListItem>();
                ViewBag.ListaTiposViviendaCreate.AddRange(list);
                return View(u);
            }
            byte[] foto = new byte[ImgData.InputStream.Length];
            u.ImgData.InputStream.Read(foto, 0, foto.Length);
            fileContent = Convert.ToBase64String(foto);
            fileContentType = u.ImgData.ContentType;

            Viviendas vivienda = new Viviendas()
            {
                Cod_Provincia = u.Cod_Provincia,
                Cod_TipoVivienda = u.Cod_TipoVivienda,
                Codigo_Posta = u.Codigo_Posta,
                Ciudad = u.Ciudad,
                IdCliente = u.IdCliente,
                Garaje = u.Garaje,
                Descripcion = u.Descripcion,
                Num_banios = u.Num_banios,
                Num_habitaciones = u.Num_habitaciones,
                Tamanio_vivienda = u.Tamanio_vivienda,
                Ubicacion = u.Ubicacion
            };

            int InsertedVivienda = this.repo.InsertarViviendas(vivienda);
            Galeria_Fotos galeria = new Galeria_Fotos()
            {
                Cod_casa = InsertedVivienda,
                Foto = foto
            };

            this.repo.InsertarImagen(galeria);



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