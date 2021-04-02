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
    
    public partial class Orden
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orden()
        {
            this.Detalle = new HashSet<Detalle>();
        }
    
        public int ID_Orden { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Monto { get; set; }
        public string MontoFinal { get; set; }
        public decimal IVA { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Detalle { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle> Detalle { get; set; }
    }
}
