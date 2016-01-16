using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_1._0.Models;

namespace Proyecto_1._0.Controllers
{
    public class RequisitoDatoesController : Controller
    {
        private ConexionDb db = new ConexionDb();

        // GET: RequisitoDatoes
        public ActionResult Index( string searchString)
        {
            //var requisitoDato = db.requisitoDato.Include(r => r.TipoDato).Include(r => r.TipoServicio);
            var requisitoDato = from s in db.requisitoDato
                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                requisitoDato = requisitoDato.Where(s => s.TipoServicio.nombre_servicio.Contains(searchString));
            }
            return View(requisitoDato.ToList());
        }

        // GET: RequisitoDatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitoDato requisitoDato = db.requisitoDato.Find(id);
            if (requisitoDato == null)
            {
                return HttpNotFound();
            }
            return View(requisitoDato);
        }

        // GET: RequisitoDatoes/Create
        public ActionResult Create()
        {
            ViewBag.id_dato = new SelectList(db.tipoDato, "id_dato", "nombre_dato");
            ViewBag.id_servicio = new SelectList(db.tipoServicio, "id_servicio", "nombre_servicio");
            return View();
        }

        // POST: RequisitoDatoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_req_dato,es_obligatorio,id_dato,id_servicio")] RequisitoDato requisitoDato)
        {
            if (ModelState.IsValid)
            {
                db.requisitoDato.Add(requisitoDato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_dato = new SelectList(db.tipoDato, "id_dato", "nombre_dato", requisitoDato.id_dato);
            ViewBag.id_servicio = new SelectList(db.tipoServicio, "id_servicio", "nombre_servicio", requisitoDato.id_servicio);
            return View(requisitoDato);
        }

        // GET: RequisitoDatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitoDato requisitoDato = db.requisitoDato.Find(id);
            if (requisitoDato == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_dato = new SelectList(db.tipoDato, "id_dato", "nombre_dato", requisitoDato.id_dato);
            ViewBag.id_servicio = new SelectList(db.tipoServicio, "id_servicio", "nombre_servicio", requisitoDato.id_servicio);
            return View(requisitoDato);
        }

        // POST: RequisitoDatoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_req_dato,es_obligatorio,id_dato,id_servicio")] RequisitoDato requisitoDato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisitoDato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_dato = new SelectList(db.tipoDato, "id_dato", "nombre_dato", requisitoDato.id_dato);
            ViewBag.id_servicio = new SelectList(db.tipoServicio, "id_servicio", "nombre_servicio", requisitoDato.id_servicio);
            return View(requisitoDato);
        }

        // GET: RequisitoDatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitoDato requisitoDato = db.requisitoDato.Find(id);
            if (requisitoDato == null)
            {
                return HttpNotFound();
            }
            return View(requisitoDato);
        }

        // POST: RequisitoDatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequisitoDato requisitoDato = db.requisitoDato.Find(id);
            db.requisitoDato.Remove(requisitoDato);
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
