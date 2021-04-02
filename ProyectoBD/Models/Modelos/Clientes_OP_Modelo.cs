using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoBD.Models.Modelos
{
    public class Clientes_OP_Modelo
    {
        [Display(Name = "Organizacion ")]
        public List<Organizacion> Organizacion { get; set; }

        [Display(Name = "Persona ")]
        public List<Persona> Persona { get; set; }
    }
}