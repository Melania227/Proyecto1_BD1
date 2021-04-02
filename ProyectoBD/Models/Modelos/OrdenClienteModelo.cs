using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoBD.Models.Modelos
{
    public class OrdenClienteModelo
    {
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Detalle")]
        public IEnumerable<Detalle> detalle { get; set; }

        [Display(Name = "Id_Cliente")]
        public int Id_Cliente { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Orden")]
        public Orden Orden { get; set; }

        public int tipo { get; set; }

        [Display(Name = "ID_Parte")]
        public int ID_Parte { get; set; }

        [Display(Name = "ID_Proveedor")]
        public int ID_Proveedor { get; set; }

        [Display(Name = "Cantidad")]
        [Range(1, 99999999)]
        public int Cantidad { get; set; }

        [Display(Name = "ID_Orden")]
        public int ID_Orden { get; set; }
        [Display(Name = "Precio ")]
        [Required(ErrorMessage = "Tiene que ingresar una cantidad de dinero")]
        [Range(1, 99999999)]
        public decimal Precio { get; set; }
    }
}