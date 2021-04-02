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
    public class Proveidas_porController : Controller
    {
        private Proyecto_1Entities13 db = new Proyecto_1Entities13();

        public ActionResult EditarMenu()
        {
           var partes = db.Parte
                .Where(x => x.ID_Parte == x.ID_Parte)
                .Select(x => new
                {
                    
                    ID_Parte = x.ID_Parte,
                    Nombre = x.Nombre + " - " + x.Marca
                });
            ViewBag.ID_Parte = new SelectList(partes, "ID_Parte", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMenu(string ID_Parte)
        {
            return RedirectToAction("Edit", "Proveidas_por", new { id = ID_Parte });

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parte parteBase = db.Parte.Find(id);
            Proveidas_porModelo provM = new Proveidas_porModelo();
            if (parteBase == null)
            {
                return HttpNotFound();
            }
            var ID_Proveedores = db.spFindProveedorParaParte(id).ToList();
            List<Proveedor> listaProv = new List<Proveedor>();
            foreach (var item in ID_Proveedores)
            {
                listaProv.Add(db.Proveedor.Find(item.GetValueOrDefault()));
            }
            provM.ID_Parte = id ?? default(int);
            ViewBag.ID_Prov = new SelectList(listaProv, "ID_Proveedor", "NombreProveedor");

            return View(provM);
        }

        // GET: Proveidas_por
        public ActionResult Index()
        {
            var proveidas_por = db.Proveidas_por.Include(p => p.Parte).Include(p => p.Proveedor);
            return View(proveidas_por.ToList());
        }

        // GET: Proveidas_por/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveidas_por proveidas_por = db.Proveidas_por.Find(id);
            if (proveidas_por == null)
            {
                return HttpNotFound();
            }
            return View(proveidas_por);
        }

        // GET: Proveidas_por/Create
        public ActionResult Create()
        {
            var partes = db.Parte
               .Where(x => x.ID_Parte == x.ID_Parte)
               .Select(x => new
               {
                   ID_Parte = x.ID_Parte,
                   Nombre = x.Nombre + " - " + x.Marca
               });
            ViewBag.ID_Parte = new SelectList(partes, "ID_Parte", "Nombre");
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "NombreProveedor");
            return View();
        }

        // POST: Proveidas_por/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proveidas_porModelo proveidas_por)
        {
            ViewBag.Resultado = false;
            ViewBag.Msg = "Error. Datos invalidos";
            decimal numero = (decimal)proveidas_por.Precio + ((decimal)proveidas_por.Precio * ((decimal)proveidas_por.PorciónGanada / (decimal)100));
            var partes = db.Parte
               .Where(x => x.ID_Parte == x.ID_Parte)
               .Select(x => new
               {
                   ID_Parte = x.ID_Parte,
                   Nombre = x.Nombre + " - " + x.Marca
               });

            ViewBag.ID_Parte = new SelectList(partes, "ID_Parte", "Nombre");
            ViewBag.ID_Proveedor = new SelectList(db.Proveedor, "ID_Proveedor", "NombreProveedor");
            if (proveidas_por.PorciónGanada == null || proveidas_por.Precio == null)
            {

                ViewBag.Resultado = false;
                ViewBag.Msg = "Error. Datos invalidos";
                return View(proveidas_por);
            }


            ObjectParameter result = new ObjectParameter("outputMessage", typeof(string));
            db.spAssociateParteConProveedor(proveidas_por.ID_Parte, proveidas_por.ID_Proveedor, proveidas_por.Precio, numero, proveidas_por.PorciónGanada, result);
            System.Diagnostics.Debug.WriteLine(result.ToString());
            if (result.Value.ToString() == "DONE SUCCESFULLY.")
            {
                ViewBag.Resultado = true;
                ViewBag.Msg = "Asociacion completada";
            }
            else
            {
                ViewBag.Resultado = false;
                ViewBag.Msg = "Error. No se pudo realizar la asociacion";
            }
            return View(proveidas_por);

        }

        // POST: Proveidas_por/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Proveidas_por proveidas_por)
        {
            if (ModelState.IsValid)
            {
                db.spModifyPrecioProveedorDeParte(proveidas_por.ID_Parte, proveidas_por.ID_Proveedor, proveidas_por.Precio, Decimal.ToInt32(proveidas_por.PrecioCliente));
                return RedirectToAction("Index");
            }
            else {
                return RedirectToAction("Index");
            }
        }

        // GET: Proveidas_por/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveidas_por proveidas_por = db.Proveidas_por.Find(id);
            if (proveidas_por == null)
            {
                return HttpNotFound();
            }
            return View(proveidas_por);
        }

        // POST: Proveidas_por/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveidas_por proveidas_por = db.Proveidas_por.Find(id);
            db.Proveidas_por.Remove(proveidas_por);
            db.SaveChanges();
            return RedirectToAction("Index");
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
