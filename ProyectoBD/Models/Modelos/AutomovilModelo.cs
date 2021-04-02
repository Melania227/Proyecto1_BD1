using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoBD.Models.Modelos
{
    public class AutomovilModelo
    {
        [Display(Name = "añoFabricacion")]
        public int añoFabricacion { get; set; }

        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Display(Name = "Detalle")]
        public string Detalle { get; set; }

        [Display(Name = "Fabricante")]
        public string Fabricante { get; set; }
    }
}