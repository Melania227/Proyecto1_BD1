//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp_BD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Parte()
        {
            this.Detalle = new HashSet<Detalle>();
            this.Proveidas_por = new HashSet<Proveidas_por>();
            this.Automovil = new HashSet<Automovil>();
        }
    
        public int ID_Parte { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int ID_Fabricante { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle> Detalle { get; set; }
        public virtual Fabricante Fabricante { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveidas_por> Proveidas_por { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Automovil> Automovil { get; set; }
    }
}
