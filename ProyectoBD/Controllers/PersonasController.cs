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
    public class PersonasController : Controller
    {
        private Proyecto_1Entities13 db = new Proyecto_1Entities13();

        public ActionResult EditarMenu()
        {
            ViewBag.ID_Persona = new SelectList(db.Persona, "Cedula", "Nombre");

            return View();
        }

        public ActionResult AgregarTelefono(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            Persona_Telefono persona_ = new Persona_Telefono();
            persona_.persona = persona;
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona_);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarTelefono(string id, string submitButton, Persona_Telefono telefono)
        {
            int id_i= Int32.Parse(id);
            List<int> lista = (db.Telefono_Persona.Where(x => x.Cedula == id_i).Select(x => x.Telefono)).ToList();
            foreach (int i in lista)
            {
                if (i == telefono.tel) {
                ViewBag.Continue = true;
                ViewBag.Msg = "Error. El numero ya ha sido agregado";
                return View();
                }
            }
            if (submitButton == "Agregar otro número")
            {
                 db.spAddTelefonoACliente(new int?(Int32.Parse(id)), telefono.tel);
                    ViewBag.Continue = true;
                    ViewBag.Msg = "Numero agregado correctamente";
                    return View();
            }
            else {
                db.spAddTelefonoACliente(new int?(Int32.Parse(id)), telefono.tel);
                ViewBag.Continue = false;
                ViewBag.Msg = "Numero agregado correctamente";
                return View();
            }
            
        }

        public ActionResult Suspender()
        {
          
            var PERS = db.Persona
                    .Where(x => x.Cliente.ID_Estado != 2)
                    .Select(x => new
                    {
                        Cedula = x.Cedula,
                        Nombre = x.Nombre
                    });
            ViewBag.ID_Persona = new SelectList(PERS, "Cedula", "Nombre");
            return View();
        }

        // GET: Personas
        public ActionResult Index()
        {
            var persona = db.Persona.Include(p => p.Cliente);
            return View(persona.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Direccion");
            ViewBag.ID_EstadoList = new SelectList(db.Estado, "ID_Estado", "Tipo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonaModelo persona)
        {
           /* if (Math.Floor(Math.Log10(persona.Cedula) + 1) != 9)
            {
                ViewBag.Resultado = false;
                ViewBag.Msg = "Error. Cedula no valida";
                return View(persona);
            }*/
            if (ModelState.IsValid)
            {
                ObjectParameter result = new ObjectParameter("ReturnMessage", typeof(string));
                db.spAddCliente_Persona_ConRestricciones(persona.Cedula, persona.Nombre, persona.Cliente.Direccion, persona.Cliente.Ciudad, persona.Cliente.ID_Estado, result);
                System.Diagnostics.Debug.WriteLine(result.ToString());
                if (result.Value.ToString() == "YES, DONE.")
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
            
            return View(persona);

        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Ciudad", persona.ID_Cliente);
            ViewBag.ID_EstadoList = new SelectList(db.Estado, "ID_Estado", "Tipo");
            ViewBag.Estado = persona.Cliente.ID_Estado;
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Persona persona, string id)
        {
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Ciudad", persona.ID_Cliente);
            ViewBag.ID_EstadoList = new SelectList(db.Estado, "ID_Estado", "Tipo");
            if (persona.Nombre == null) {
                ViewBag.Resultado = false;
                ViewBag.Msg = "Error. Necesita agregar un nombre";
                return View(persona);
            }
            int id_i = Int32.Parse(id);
            List<string> lista = (db.Persona.Select(x => x.Nombre)).ToList();
            foreach (string i in lista)
            {
                if (i == persona.Nombre && (persona.Nombre!= (db.Persona.Find(id_i)).Nombre))
                {
                    ViewBag.Resultado = false;
                    ViewBag.Msg = "Error. El nombre ya ha sido agregado";
                    return View(persona);
                }
            }
            if (ModelState.IsValid)
            {
                db.spModify_Persona(Int32.Parse(id), persona.Nombre, persona.Cliente.Direccion, persona.Cliente.Ciudad, persona.Cliente.ID_Estado);
                ViewBag.Resultado = true;
                ViewBag.Msg = "Cliente editado correctamente.";
            }
            else
            {
                ViewBag.Resultado = false;
                ViewBag.Msg = "Error. El cliente no se pudo editar";
            }
            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMenu(string Cedula)
        {
            return RedirectToAction("Edit", "Personas", new { id = Cedula });
        }


        public ActionResult EditNum(int? id) {
           List<int> lista =(db.Telefono_Persona.Where(x => x.Cedula == id).Select(x => x.Telefono)).ToList();
            ViewBag.hayNum = 1;
            if (lista.Count == 0) {
                ViewBag.hayNum = 0;
            }
            ViewBag.tels = lista;
            Persona persona = db.Persona.Find(id);
            return View(persona);
        }

        public ActionResult EditarMenu2(int id, int num)
        {
            
            Persona_Telefono p_ = new Persona_Telefono();
            p_.ced = id;
            p_.telViejo = num;
            ViewBag.v = id;
            ViewBag.n = num;
            return View(p_);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMenu2(Persona_Telefono persona_)
        {
            if (Math.Floor(Math.Log10(persona_.tel) + 1) == 8)
            {
                db.spModifyTelefonoAPersona(persona_.ced, persona_.telViejo, persona_.tel);
                ViewBag.Resultado = true;
                ViewBag.Msg = "Telefono actualizado correctamente";
                if (persona_.telViejo == persona_.tel)
                {
                    ViewBag.Resultado = false;
                    ViewBag.Msg = "No se pudo actualizar el telefono";
                }
            }
            else {
                ViewBag.Resultado = false;
                ViewBag.Msg = "Error. Numero no valido";
            }
            return View(persona_);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Suspender(string Cedula)
        {
            int Ced = Int32.Parse(Cedula);
            db.spChangetoSuspended_Persona(Ced);
            ViewBag.Resultado = true;
            ViewBag.Msg = "Cliente suspendido correctamente.";
            var PERS = db.Persona
                    .Where(x => x.Cliente.ID_Estado != 2)
                    .Select(x => new
                    {
                        Cedula = x.Cedula,
                        Nombre = x.Nombre
                    });
            ViewBag.ID_Persona = new SelectList(PERS, "Cedula", "Nombre");
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
