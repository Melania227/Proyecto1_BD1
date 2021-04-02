using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoBD.Models;
using ProyectoBD.Models.Modelos;

namespace ProyectoBD.Controllers
{
    public class Para_UnController : Controller
    {
        private Proyecto_1Entities13 db = new Proyecto_1Entities13();

       //CREAR
        public ActionResult Create()
        {
            var tipos = db.Automovil
                            .Where(x => x.ID_Automovil == x.ID_Automovil)
                            .Select(x => new
                            {
                                ID_Automovil = x.ID_Automovil,
                                Nombre = x.Modelo + " - " + x.añoFabricacion.ToString() + " - " + x.Fabricante
                            }); ;
            var partes = db.Parte
                .Where(x => x.ID_Parte == x.ID_Parte)
                .Select(x => new
                {
                    ID_Parte = x.ID_Parte,
                    Nombre = x.Nombre + " - " + x.Marca
                });
            ViewBag.ID_Parte = new SelectList(partes, "ID_Parte", "Nombre");
            ViewBag.ID_Automovil = new SelectList(tipos, "ID_Automovil", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Para_UnModelo parte)
        {
            var tipos = db.Automovil
                            .Where(x => x.ID_Automovil == x.ID_Automovil)
                            .Select(x => new
                            {
                                ID_Automovil = x.ID_Automovil,
                                Nombre = x.Modelo + " - " + x.añoFabricacion.ToString() + " - " + x.Fabricante
                            }); ;
            var partes = db.Parte
                .Where(x => x.ID_Parte == x.ID_Parte)
                .Select(x => new
                {
                    ID_Parte = x.ID_Parte,
                    Nombre = x.Nombre + " - " + x.Marca
                });
            ViewBag.ID_Parte = new SelectList(partes, "ID_Parte", "Nombre");
            ViewBag.ID_Automovil = new SelectList(tipos, "ID_Automovil", "Nombre");
            if (ModelState.IsValid)
            {
                ObjectParameter result1 = new ObjectParameter("OutputMessage", typeof(string));
                db.spAssociateParteConAutomovil(parte.ID_Parte, parte.ID_Automovil,result1);
                System.Diagnostics.Debug.WriteLine(result1.ToString());
                if (result1.Value.ToString() == "DONE SUCCESFULLY.")
                {
                    ViewBag.Resultado = true;
                    ViewBag.Msg = "Asociacion realizada correctamente";
                }
                else
                {
                    ViewBag.Resultado = false;
                    ViewBag.Msg = "Error. No se pudo realizar la asociacion";
                }
            }
            return View(parte);
        }

        //DETALLES DE LA CREACION
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartesModelo parte = new PartesModelo();
            Parte parteBase = db.Parte.Find(id);
            if (parteBase == null)
            {
                return HttpNotFound();
            }
            var ID_Autos = db.spFindAutomovilParaParte(id).ToList();
            Fabricante CREADOR = db.Fabricante.Find(parte.ID_Fabricante);
            List<Automovil> listaAutos = new List<Automovil>();
            foreach (var item in ID_Autos)
            {
                listaAutos.Add(db.Automovil.Find(item.GetValueOrDefault()));
            }

            parte.Nombre = parteBase.Nombre;
            parte.Marca = parteBase.Marca;
            parte.TiposAuto = listaAutos;
            parte.Fabricante = CREADOR;

            return View(parte);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
