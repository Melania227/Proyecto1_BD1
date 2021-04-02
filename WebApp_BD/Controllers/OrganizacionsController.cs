using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp_BD.Models;
using WebApp_BD.Models.Modelos;

namespace WebApp_BD.Controllers
{
    public class OrganizacionsController : Controller
    {
        private Proyecto_1Entities5 db = new Proyecto_1Entities5();

        // GET: Organizacions
        public ActionResult Index()
        {
            var organizacion = db.Organizacion.Include(o => o.Cliente).Include(o => o.Contacto1);
            return View(organizacion.ToList());
        }

        // GET: Organizacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizacion organizacion = db.Organizacion.Find(id);
            if (organizacion == null)
            {
                return HttpNotFound();
            }
            return View(organizacion);
        }

        // GET: Organizacions/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Ciudad");
            ViewData["ID_Estado"] = new SelectList(db.Estado, "ID_Estado", "Tipo");
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre");
            return View();
        }

        // POST: Organizacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organizacion organizacion, [Bind(Include = "Direccion,Ciudad,ID_Estado")] Cliente cliente, ContactoModel contacto)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter result = new ObjectParameter("ReturnMessage", typeof(string));
                db.spAddCliente_Organizacion_InDB(organizacion.Cedula,organizacion.Nombre,cliente.Direccion,cliente.Ciudad,cliente.ID_Estado,contacto.Nombre,contacto.Telefono,contacto.Cargo, result);
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Ciudad", organizacion.ID_Cliente);
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre", organizacion.ID_Contacto);
            return View(organizacion);
        }

        // GET: Organizacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizacion organizacion = db.Organizacion.Find(id);
            if (organizacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Ciudad", organizacion.ID_Cliente);
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre", organizacion.ID_Contacto);
            return View(organizacion);
        }

        // POST: Organizacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cedula,Nombre,ID_Cliente,ID_Contacto")] Organizacion organizacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Ciudad", organizacion.ID_Cliente);
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre", organizacion.ID_Contacto);
            return View(organizacion);
        }

        // GET: Organizacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizacion organizacion = db.Organizacion.Find(id);
            if (organizacion == null)
            {
                return HttpNotFound();
            }
            return View(organizacion);
        }

        // POST: Organizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organizacion organizacion = db.Organizacion.Find(id);
            db.Organizacion.Remove(organizacion);
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
