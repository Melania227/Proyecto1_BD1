using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoBD.Models.Modelos
{
    public class Proveidas_porModelo
    {
        [Display(Name = "ID_Parte ")]
        public int ID_Parte { get; set; }

        [Display(Name = "ID_Proveedor ")]
        public int ID_Proveedor { get; set; }

        [Display(Name = "Precio ")]
        [Range(1, 99999999)]
        public decimal Precio { get; set; }

        [Display(Name = "Precio Cliente ")]
        [Required(ErrorMessage = "Tiene que ingresar una cantidad de dinero")]
        [Range(1, 99999999)]
        public decimal PrecioCliente { get; set; }


        [Display(Name = "Ganancia ")]
        [Range(1, 100, ErrorMessage = "Numero fuera de rango")]
        public int PorciónGanada { get; set; }
    }
}