using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoBD.Models.Modelos
{
    public class PartesModelo
    {

        [Display(Name = "Nombre ")]
        [MaxLength(50, ErrorMessage = "El nombre puede ser de hasta 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar un nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Marca ")]
        [MaxLength(50, ErrorMessage = "El cargo puede ser de hasta 50 caracteres")]
        [Required(ErrorMessage = "Tiene que ingresar una marca")]
        public string Marca { get; set; }

        [Display(Name = "Fabricante ")]
        public Fabricante Fabricante { get; set; }

        [Display(Name = "ID_Fabricante")]
        public int ID_Fabricante { get; set; }

        [Display(Name = "TipoAuto ")]
        public List<Automovil> TiposAuto { get; set; }

    }
}