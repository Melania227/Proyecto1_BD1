using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoBD.Models.Modelos
{
    public class Persona_Telefono
    {
        [Display(Name = "persona")]
        public Persona persona { get; set; }

        [Display(Name = "ced")]
        [Range(100000000, 999999999, ErrorMessage = "Numero de cedula no valido")]
        public int ced { get; set; }

        [Display(Name = "tel")]
        [Range(10000000, 99999999, ErrorMessage = "Los numeros de telefonos son de 8 digitos")]
        public int tel { get; set; }

        [Display(Name = "telViejo")]
        [Range(10000000, 99999999, ErrorMessage = "Los numeros de telefonos son de 8 digitos")]
        public int telViejo { get; set; }
    }
}