//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoBD_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Telefono_Proveedor
    {
        public int ID_Proveedor { get; set; }
        public int Telefono { get; set; }
    
        public virtual Proveedor Proveedor { get; set; }
    }
}
