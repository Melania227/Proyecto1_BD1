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
    public class OrganizacionsController : Controller
    {
        private Proyecto_1Entities13 db = new Proyecto_1Entities13();

        public ActionResult EditarMenu()
        {
            ViewBag.ID_Org = new SelectList(db.Organizacion, "Cedula", "Nombre");
            return View();
        }

        public ActionResult Suspender()
        {
            var PERS = db.Organizacion
                    .Where(x => x.Cliente.ID_Estado != 2)
                    .Select(x => new
                    {
                        Cedula = x.Cedula,
                        Nombre = x.Nombre
                    });
            ViewBag.ID_Org = new SelectList(PERS, "Cedula", "Nombre");
            return View();
        }


        public ActionResult Index()
        {
            var organizacion = db.Organizacion.Include(o => o.Cliente).Include(o => o.Contacto1);
            return View(organizacion.ToList());
        }

        // GET: Organizacions/Details/5
        public ActionResult Details(long? id)
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
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre");
            ViewBag.ID_EstadoList = new SelectList(db.Estado, "ID_Estado", "Tipo");
            return View();
        }

        // POST: Organizacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizacionModelo organizacion)
        {
            /*if (Math.Floor(Math.Log10(organizacion.Cedula) + 1) != 10) {
                ViewBag.Resultado = false;
                ViewBag.Msg = "Error. Cedula no valida";
                return View(organizacion);
            }
            if (Math.Floor(Math.Log10(organizacion.Contacto.Telefono) + 1) != 8)
            {
                ViewBag.Resultado = false;
                ViewBag.Msg = "Error. Telefono de contacto no valido";
                return View(organizacion);
            }*/
            if (ModelState.IsValid)
            {
                ObjectParameter result = new ObjectParameter("ReturnMessage", typeof(string));
                db.spAddCliente_Organizacion_InDB(organizacion.Cedula, organizacion.Nombre, organizacion.Cliente.Direccion, organizacion.Cliente.Ciudad, 0, organizacion.Contacto.Nombre, organizacion.Contacto.Telefono, organizacion.Contacto.Cargo, result);
                System.Diagnostics.Debug.WriteLine(result.ToString());
                if (result.Value.ToString() == "Done client succesfully")
                {
                    ViewBag.Resultado = true;
                    ViewBag.Msg = "Cliente agregado correctamente.";
                }
                else
                {
                    ViewBag.Resultado = false;
                    ViewBag.Msg = "Error. El cliente ya fue registrado";
                }
            }
            return View(organizacion);
        }


        // GET: Organizacions/Edit/5
        public ActionResult Edit(long? id)
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
            var Estado = db.Estado
                   .Select(x => new
                   {
                       ID_Estado = x.ID_Estado,
                       Tipo = x.Tipo
                   });
            ViewBag.ID_EstadoList = new SelectList(Estado, "ID_Estado", "Tipo");
            ViewBag.Estado = organizacion.Cliente.ID_Estado;
            return View(organizacion);
        }

        // POST: Organizacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Organizacion organizacion, string id)
        {
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Ciudad", organizacion.ID_Cliente);
            ViewBag.ID_Contacto = new SelectList(db.Contacto, "ID_Contacto", "Nombre", organizacion.ID_Contacto);
            var Estado = db.Estado
                   .Where(x => x.ID_Estado != 2)
                   .Select(x => new
                   {
                       ID_Estado = x.ID_Estado,
                       Tipo = x.Tipo
                   });
            ViewBag.ID_EstadoList = new SelectList(Estado, "ID_Estado", "Tipo");
            ViewBag.Estado = organizacion.Cliente.ID_Estado;
            long id_i = Int64.Parse(id);
            List<string> lista = (db.Organizacion.Select(x => x.Nombre)).ToList();
            foreach (string i in lista)
            {
                if (i == organizacion.Nombre && (organizacion.Nombre != (db.Organizacion.Find(id_i)).Nombre))
                {
                    ViewBag.Resultado = false;
                    ViewBag.Msg = "Error. El nombre ya ha sido agregado";
                    return View(organizacion);
                }
            }
            if (organizacion.Nombre == null)
            {
                ViewBag.Resultado = false;
                ViewBag.Msg = "Error. Necesita agregar un nombre";
                return View(organizacion);
            }
            int? m = organizacion.Contacto1.Telefono;
            if (m == null )//|| Math.Floor(Math.Log10(organizacion.Contacto1.Telefono) + 1) != 8)
            {
                ViewBag.Resultado = false;
                ViewBag.Msg = "Error. Necesita agregar un numero valido";
                return View(organizacion);
            }
            if (ModelState.IsValid)
            {
                db.spModify_Organizacion(Int64.Parse(id), organizacion.Nombre, organizacion.Cliente.Direccion, organizacion.Cliente.Ciudad, organizacion.Cliente.ID_Estado, organizacion.Contacto1.Nombre, organizacion.Contacto1.Telefono, organizacion.Contacto1.Cargo);
                ViewBag.Resultado = true;
                ViewBag.Msg = "Cliente editado correctamente.";
            }
            else
            {
                ViewBag.Resultado = false;
                ViewBag.Msg = "Error. El cliente no se pudo editar";
            }
            return View(organizacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMenu(string Cedula)
        {
            
            return RedirectToAction("Edit", "Organizacions", new { id = Cedula });

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Suspender(string Cedula)
        {
            long ced = Int64.Parse(Cedula);
            db.spChangetoSuspended_Organizacion(ced);
            ViewBag.Resultado = true;
            ViewBag.Msg = "Cliente suspendido correctamente.";
            var PERS = db.Organizacion
                    .Where(x => x.Cliente.ID_Estado != 2)
                    .Select(x => new
                    {
                        Cedula = x.Cedula,
                        Nombre = x.Nombre
                    });
            ViewBag.ID_Org = new SelectList(PERS, "Cedula", "Nombre");
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
