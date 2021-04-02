using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoBD.Models.Modelos
{
    public class Para_UnModelo
    {

        [Display(Name = "ID_Parte ")]
        public int ID_Parte { get; set; }

        [Display(Name = "ID_Automovil ")]
        public int ID_Automovil { get; set; }


    }
}