using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoBD.Models.Modelos
{
    public class OrganizacionModelo
    {
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El nombre puede ser de hasta 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar un nombre")]
        public string Nombre { get; set; }


        [Display(Name = "Cedula Júridica")]
        [Required(ErrorMessage = "Tiene que ingresar un número de cédula júridica")]
        [Range(1000000000, 99999999999, ErrorMessage = "Numero de cédula júridica no valido")]

        public long Cedula { get; set; }


        public ClienteModelo Cliente { get; set; }
        public ContactoModelos Contacto { get; set; }
    }
}