using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoBD.Models.Modelos
{
    public class ClienteModelo
    {
        [Display(Name = "Ciudad")]
        [MaxLength(50, ErrorMessage = "Nombre de la organización puede ser de hasta 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar un nombre")]
        public string Ciudad { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(50, ErrorMessage = "Nombre de la organización puede ser de hasta 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar un nombre")]
        public string Direccion { get; set; }

        [Display(Name = "ID_Estado")]
        public int ID_Estado { get; set; }
    }
}