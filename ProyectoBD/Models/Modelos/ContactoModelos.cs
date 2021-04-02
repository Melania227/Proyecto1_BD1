using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoBD.Models.Modelos
{
    public class ContactoModelos
    {

        [Display(Name = "Nombre ")]
        [MaxLength(50, ErrorMessage = "El nombre puede ser de hasta 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar un nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Cargo ")]
        [MaxLength(50, ErrorMessage = "El cargo puede ser de hasta 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar un cargo")]
        public string Cargo { get; set; }

        [Display(Name = "Número de telefono")]
        [Required(ErrorMessage = "Tiene que ingresar un número de telefono")]
        [Range(10000000, 99999999, ErrorMessage = "Los numeros de telefonos son de 8 digitos")]
        public int Telefono { get; set; }
    }
}