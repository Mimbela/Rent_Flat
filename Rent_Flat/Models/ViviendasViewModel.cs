using RepositorioRentFlat.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent_Flat.Models
{
    public class ViviendasViewModel
    {
        public int Cod_casa { get; set; }
        public int Cod_Provincia { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public string Ubicacion { get; set; }
        public string Codigo_Posta { get; set; }
        public string Ciudad { get; set; }
        public int Num_habitaciones { get; set; }
        public int Num_banios { get; set; }
        public int Tamanio_vivienda { get; set; }
        public string Descripcion { get; set; }
        public bool Garaje { get; set; }
        public Nullable<int> Cod_TipoVivienda { get; set; }
        public string RutaFoto { get; set; }
        public HttpPostedFileBase ImgData { get; set; }
        public byte[] Foto { get; set; }

        public Galeria_Fotos Galeria_Fotos { get; set; }


        public ViviendasViewModel()
        {
            
            Galeria_Fotos = new Galeria_Fotos();
        }
    }
}