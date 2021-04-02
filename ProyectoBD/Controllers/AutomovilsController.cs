using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoBD.Models;
using ProyectoBD.Models.Modelos;

namespace ProyectoBD.Controllers
{
    public class AutomovilsController : Controller
    {
        private Proyecto_1Entities13 db = new Proyecto_1Entities13();

        // GET: Automovils
       
        public ActionResult Index(int? año, string mod)
        {
            ViewBag.hayNum = 0;
            var partesM = db.spFindPartePorModelo_Año(año, mod).ToList();
            List<Parte> partesMList = new List<Parte>();
            foreach (var item in partesM)
            {
                partesMList.Add(db.Parte.Find(item.GetValueOrDefault()));
            }

            List<string> Info = new List<string>();
            ViewBag.Info= año.ToString();
            ViewBag.Mod = mod;
            if (partesM.Count != 0) {
                ViewBag.hayNum = 1;
                    }
            return View(partesMList);
        }

        // GET: Automovils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.Automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // GET: Automovils/Create
        public ActionResult Create()
        {
            ViewBag.Modelo = new SelectList(db.Automovil, "Modelo", "Modelo");
            ViewBag.añoFabricacion = new SelectList(db.Automovil, "añoFabricacion", "añoFabricacion");
            return View();
        }

        // POST: Automovils/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string añoFabricacion, string Modelo)
        {
           return RedirectToAction("Index", "Automovils", new {
                año = añoFabricacion,
                mod = Modelo 
            });
        }

        // GET: Automovils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.Automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // POST: Automovils/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Automovil,añoFabricacion,Fabricante,Modelo,Detalle")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(automovil);
        }

        // GET: Automovils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovil automovil = db.Automovil.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            return View(automovil);
        }

        // POST: Automovils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automovil automovil = db.Automovil.Find(id);
            db.Automovil.Remove(automovil);
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
