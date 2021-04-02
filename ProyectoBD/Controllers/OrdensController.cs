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
    public class OrdensController : Controller
    {
        private Proyecto_1Entities13 db = new Proyecto_1Entities13();

        // GET: Ordens
        public ActionResult registroOrdenes()
        {
            var ordenes = db.Orden.ToList();
            List<OrdenClienteModelo> lista = new List<OrdenClienteModelo>();
            foreach (var orden in ordenes)
            {
                if (db.Persona.Where(x => x.ID_Cliente == orden.ID_Cliente) != null)
                {
                    OrdenClienteModelo modelo = new OrdenClienteModelo();
                    modelo.tipo = 1;
                    modelo.Orden = orden;
                    var nomb = db.spFindNombrePorID_Cliente(orden.ID_Cliente).ToList();
                    modelo.Nombre = nomb[0];
                    modelo.Id_Cliente = orden.ID_Cliente;
                    modelo.detalle =( db.Detalle.Where(x => x.ID_Orden == orden.ID_Orden)).ToList();
                    
                    lista.Add(modelo);
                }
                else if (db.Organizacion.Where(x => x.ID_Cliente == orden.ID_Cliente) != null)
                {
                    OrdenClienteModelo modelo = new OrdenClienteModelo();
                    modelo.tipo = 2;
                    modelo.Orden = orden;
                    var nomb = db.spFindNombrePorID_Cliente(orden.ID_Cliente).ToList();
                    modelo.Nombre = nomb[0];
                    modelo.Id_Cliente = orden.ID_Cliente;
                    lista.Add(modelo);
                }
            }
            return View(lista);

        }

        public ActionResult provPieza(int ID_Parte) {
            List<Proveidas_por> parte=(db.Proveidas_por.Where(x => x.ID_Parte == ID_Parte)).ToList();
            List<Proveedor> p = new List<Proveedor>();
            foreach (Proveidas_por par in parte) {
                p.Add(db.Proveedor.Find(par.ID_Proveedor));
            }
            ViewBag.partesProv = new SelectList(p, "ID_Proveedor", "NombreProveedor");
            return PartialView("DisplayPr");
        }

        public ActionResult FindParte()
        {
            ViewBag.NombreP = new SelectList(db.Parte, "Nombre", "Nombre");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FindParte(string nombre)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Ordens", new { nombre = nombre });
            }
            else
            {
                return RedirectToAction("Details");
            }
        }


        public ActionResult Index(string nombre)
        {
            ViewBag.nombre2 = nombre;
            var results = db.spFindProveedorDeParte(nombre).ToList();
            List<Proveedor> provM = new List<Proveedor>();
            foreach (var item in results)
            {
                provM.Add(db.Proveedor.Find((item.ID_Proveedor)));

            }
            
            return View(provM);
        }
        public ActionResult EditNum(int? id)
        {
            List<int> lista = (db.Telefono_Proveedor.Where(x => x.ID_Proveedor == id).Select(x => x.Telefono)).ToList();
            ViewBag.hayNum = 1;
            if (lista.Count == 0)
            {
                ViewBag.hayNum = 0;
            }
            ViewBag.tels = lista;
            Proveedor p = db.Proveedor.Find(id);
            return View(p);
        }

        // GET: Ordens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Orden.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // GET: Ordens/Create   EL CREATE ES LA 2DA DE ORDEN
        public ActionResult Create()
        {
            List<OrdenClienteModelo> lista = new List<OrdenClienteModelo>();

            foreach (Persona p in db.Persona.ToList())
            {
                
                    OrdenClienteModelo modelo = new OrdenClienteModelo();
                    modelo.Id_Cliente = p.ID_Cliente;
                    modelo.Nombre = p.Nombre;
                    lista.Add(modelo);
                
            }
            foreach (Organizacion p in db.Organizacion.ToList())
            {   OrdenClienteModelo modelo = new OrdenClienteModelo();
                    modelo.Id_Cliente = p.ID_Cliente;
                    modelo.Nombre = p.Nombre;
                    lista.Add(modelo);
                
            }

            ViewBag.ID_Cliente = new SelectList(lista, "ID_Cliente", "Nombre");
            return View();
        }

        public ActionResult Asociar() {
            ViewBag.Id_Orden = new SelectList(db.Orden, "ID_Orden", "ID_Orden");
            var tipos = db.Parte
                            .Where(x => x.ID_Parte == x.ID_Parte)
                            .Select(x => new
                            {
                                ID_Parte = x.ID_Parte,
                                Nombre = x.Nombre + " - " + x.Marca
                            }); ;
            ViewBag.Parte = new SelectList(tipos, "ID_Parte", "Nombre");
            //ViewBag.Prov = new SelectList(db.Proveedor, "ID_Proveedor", "NombreProveedor");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Asociar(OrdenClienteModelo orden)
        {
            Orden ordenActual = (Orden)db.Orden.Find(orden.ID_Orden);

            List<Proveidas_por> Lista = db.Proveidas_por.Where(u => u.ID_Parte == orden.ID_Parte && u.ID_Proveedor == orden.ID_Proveedor).ToList();
            Proveidas_por relacionPP = Lista[0];
            decimal precioPartes = (relacionPP.PrecioCliente) * (orden.Cantidad);
            decimal precioVenta = ordenActual.Monto + precioPartes;
            decimal IVA = (decimal)precioVenta *((decimal)13/ (decimal)100);
            decimal TOTAL = precioVenta + IVA;

            ViewBag.Id_Orden = new SelectList(db.Orden, "ID_Orden", "ID_Orden");
            var tipos = db.Parte
                            .Where(x => x.ID_Parte == x.ID_Parte)
                            .Select(x => new
                            {
                                ID_Parte = x.ID_Parte,
                                Nombre = x.Nombre + " - " + x.Marca
                            }); ;
            ViewBag.Parte = new SelectList(tipos, "ID_Parte", "Nombre");
            db.spActualizaPrecioOrden(orden.ID_Orden, IVA, precioVenta, TOTAL);
            Orden Lista1 = db.Orden.Find(orden.ID_Orden);
            db.spInsertDetalleINTOOrden(orden.ID_Orden, orden.ID_Parte, orden.ID_Proveedor, orden.Cantidad, precioPartes);
            ViewBag.Resultado = true;
            ViewBag.Msg = "Asociado correctamente.";
            return View(orden);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdenClienteModelo orden)
        {
           
            List<OrdenClienteModelo> lista = new List<OrdenClienteModelo>();
            if (db.Cliente.Find(orden.Id_Cliente).ID_Estado == 1) {
                db.spModifyEstadoCliente(orden.Id_Cliente);
            }
                foreach (Persona p in db.Persona.ToList())
            {
                OrdenClienteModelo modelo = new OrdenClienteModelo();
                modelo.Id_Cliente = p.ID_Cliente;
                modelo.Nombre = p.Nombre;
                lista.Add(modelo);
            }
            foreach (Organizacion p in db.Organizacion.ToList())
            {
                OrdenClienteModelo modelo = new OrdenClienteModelo();
                modelo.Id_Cliente = p.ID_Cliente;
                modelo.Nombre = p.Nombre;
                lista.Add(modelo);
            }

            ViewBag.ID_Cliente = new SelectList(lista, "ID_Cliente", "Nombre");
            DateTime? fecha = orden.Fecha;
            int? id = orden.Id_Cliente;
            if (db.Cliente.Find(orden.Id_Cliente).ID_Estado == 2)
            {

                ViewBag.Resultado = false;
                ViewBag.Msg = "Error. No se pudo realizar la asociacion, el cliente esta suspendido";
                return View(orden);
            }
            db.spInsertOrdenEnFechaParaCliente(fecha, id);
            ViewBag.Resultado = true;
            ViewBag.Msg = "Asociado correctamente.";

            return View(orden);
        }

        // GET: Ordens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Orden.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Ciudad", orden.ID_Cliente);
            return View(orden);
        }

        // POST: Ordens/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Orden,Fecha,Monto,MontoFinal,IVA,ID_Cliente")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Ciudad", orden.ID_Cliente);
            return View(orden);
        }

        // GET: Ordens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Orden.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // POST: Ordens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orden orden = db.Orden.Find(id);
            db.Orden.Remove(orden);
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
