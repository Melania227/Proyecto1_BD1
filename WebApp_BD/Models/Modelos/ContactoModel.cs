using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp_BD.Models.Modelos
{
    public class ContactoModel
    {
        [Display(Name = "Nombre Completo de contacto")]
        [MaxLength(50, ErrorMessage = "Nombre completo debe ser menor a 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar su Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Número de telefono")]
        [Required(ErrorMessage = "Tiene que ingresar su número de telefono")]
        public int Telefono { get; set; }

        [Display(Name = "Cargo")]
        [MaxLength(50, ErrorMessage = "Nombre completo debe ser menor a 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar su Nombre")]
        public string Cargo { get; set; }

    }
}