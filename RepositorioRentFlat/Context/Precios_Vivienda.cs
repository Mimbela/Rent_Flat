//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RepositorioRentFlat.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Precios_Vivienda
    {
        public int Cod_Precio { get; set; }
        public int Cod_casa { get; set; }
        public decimal Precio { get; set; }
        public System.DateTime Fecha_alta { get; set; }
        public Nullable<System.DateTime> Fecha_baja { get; set; }
        public bool Precio_activo { get; set; }
    }
}
