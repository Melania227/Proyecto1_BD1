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
    public class PartesController : Controller
    {
        private Proyecto_1Entities13 db = new Proyecto_1Entities13();

        // GET: Partes
        public ActionResult Index()
        {  
            var parte = db.Parte.Include(p => p.Fabricante);
            return View(parte.ToList());
        }

        /*public ActionResult DetailsMenu() {
            List<Proveidas_por> lista = db.Proveidas_por.ToList();
            
        }*/

        // GET: Partes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parte parte = db.Parte.Find(id);
            if (parte == null)
            {
                return HttpNotFound();
            }
            return View(parte);
        }

        // GET: Partes/Create
        public ActionResult Create()
        {
            ViewBag.ID_Fabricante = new SelectList(db.Fabricante, "ID_Fabricante", "Nombre");
            return View();
        }

        public ActionResult Eliminar()
        {
            var partes = db.Parte
                .Where(x => x.ID_Parte == x.ID_Parte)
                .Select(x => new
                {
                    ID_Parte = x.ID_Parte,
                    Nombre = x.Nombre + " - " + x.Marca
                });
            ViewBag.partesE = new SelectList(partes, "ID_Parte", "Nombre");
            return View();
        }

        // POST: Partes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PartesModelo parte)
        {
            ViewBag.ID_Fabricante = new SelectList(db.Fabricante, "ID_Fabricante", "Nombre");
            if (ModelState.IsValid)
            {
                ObjectParameter result1 = new ObjectParameter("outputMessage", typeof(string));
                db.spAddUnaParte(parte.Nombre, parte.Marca, parte.ID_Fabricante, result1);
                System.Diagnostics.Debug.WriteLine(result1.ToString());
                if (result1.Value.ToString() == "DONE SUCCESFULLY.")
                {
                    ViewBag.Msg = "Parte agregada correctamente.";
                }
                else
                {
                    ViewBag.Msg = "Error. La parte no se pudo agregar";
                }
                return View();
            }
            return View();
        }

        // GET: Partes/Edit/5
        public ActionResult Edit()
        {
            var tipos = db.Parte
            .Where(x => x.ID_Parte == x.ID_Parte)
            .Select(x => new
            {
                ID_Parte = x.ID_Parte,
                Nombre = x.Nombre + " - " + x.Marca
            }); ;
            ViewBag.Parte = new SelectList(tipos, "ID_Parte", "Nombre");
            return View();
        }

        // POST: Partes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Proveidas_porModelo orden)
        {
            List<Proveidas_por> Lista = db.Proveidas_por.Where(u => u.ID_Parte == orden.ID_Parte && u.ID_Proveedor == orden.ID_Proveedor).ToList();
            if (Lista.Any()) { 
            Proveidas_por proveed = Lista[0];
            ViewBag.Resultado = false;
            ViewBag.Msg = "Error. No se ha logrado editar.";
            var tipos = db.Parte
            .Where(x => x.ID_Parte == x.ID_Parte)
            .Select(x => new
            {
                ID_Parte = x.ID_Parte,
                Nombre = x.Nombre + " - " + x.Marca
            }); ;
            ViewBag.Parte = new SelectList(tipos, "ID_Parte", "Nombre");
            
            if (orden.PorciónGanada == 0 && orden.Precio != 0)
            {
                decimal numero = (decimal)orden.Precio + ((decimal)orden.Precio * ((decimal)proveed.PorciónGanada / (decimal)100));
                db.spModifyPrecioClienteINProveedorDeParte(orden.ID_Parte, orden.ID_Proveedor, numero);
                db.spModifyPrecioProveedorDeParte(orden.ID_Parte, orden.ID_Proveedor, orden.Precio, proveed.PorciónGanada);
                ViewBag.Resultado = true;
                ViewBag.Msg = "Precio editado correctamente";
            }
            else if (orden.PorciónGanada != 0 && orden.Precio == 0)
            {
                decimal numero = (decimal)proveed.Precio + ((decimal)proveed.Precio * ((decimal)orden.PorciónGanada / (decimal)100));
                db.spModifyPrecioClienteINProveedorDeParte(orden.ID_Parte, orden.ID_Proveedor, numero);

                db.spModifyPrecioProveedorDeParte(orden.ID_Parte, orden.ID_Proveedor, proveed.Precio, orden.PorciónGanada);
                ViewBag.Resultado = true;
                ViewBag.Msg = "Precio editado correctamente";

            }
            else if (orden.PorciónGanada != 0 && orden.Precio != 0) 
            {
                decimal numero = (decimal)orden.Precio + ((decimal)orden.Precio * ((decimal)orden.PorciónGanada / (decimal)100));
                db.spModifyPrecioClienteINProveedorDeParte(orden.ID_Parte, orden.ID_Proveedor, numero);

                db.spModifyPrecioProveedorDeParte(orden.ID_Parte, orden.ID_Proveedor, orden.Precio, orden.PorciónGanada);
                ViewBag.Resultado = true;
                ViewBag.Msg = "Precios editados correctamente";

            }
                return View(orden);
            }
            var t = db.Parte
            .Where(x => x.ID_Parte == x.ID_Parte)
            .Select(x => new
            {
                ID_Parte = x.ID_Parte,
                Nombre = x.Nombre + " - " + x.Marca
            }); ;
            ViewBag.Parte = new SelectList(t, "ID_Parte", "Nombre");
            ViewBag.Resultado = false;
            ViewBag.Msg = "Error. No se ha logrado editar.";
            return View(orden);
        }

        // GET: Partes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int ID_Parte)
        {
            var partes = db.Parte
               .Where(x => x.ID_Parte == x.ID_Parte)
               .Select(x => new
               {
                   ID_Parte = x.ID_Parte,
                   Nombre = x.Nombre + " - " + x.Marca
               });
            ViewBag.partesE = new SelectList(partes, "ID_Parte", "Nombre");
            if (ModelState.IsValid)
            {
                ObjectParameter result1 = new ObjectParameter("outputMessage", typeof(string));
                db.spDeleteParte(ID_Parte, result1);
                System.Diagnostics.Debug.WriteLine(result1.ToString());
                if (result1.Value.ToString() == "DONE SUCCESFULLY.")
                {
                    ViewBag.Msg = "Parte eliminada correctamente.";
                }
                else
                {
                    ViewBag.Msg = "Error. La parte no se pudo eliminar porque es parte de una orden";
                }
                return View();
            }
            return View();
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
