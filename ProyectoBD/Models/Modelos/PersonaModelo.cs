using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoBD.Models.Modelos
{
    public class PersonaModelo
    {
        [Display(Name = "Nombre Completo")]
        [MaxLength(50, ErrorMessage = "Nombre completo puede ser de hasta 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar un nombre válido")]
        public string Nombre { get; set; }


        [Display(Name = "Cedula")]
        [Range(100000000, 999999999, ErrorMessage = "Numero fuera de rango")]
        [Required(ErrorMessage = "Tiene que ingresar un número de cédula")]

        public int Cedula { get; set; }


        public ClienteModelo Cliente { get; set; }

        /*[Display(Name = "Número de telefono")]
        [Required(ErrorMessage = "Tiene que ingresar un número de telefono")]
        public int Cedula { get; set; }*/


    }
}