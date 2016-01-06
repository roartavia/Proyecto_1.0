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
    public class TipoDatoesController : Controller
    {
        private ConexionDb db = new ConexionDb();

        // GET: TipoDatoes
        public ActionResult Index()
        {
            var tipoDato = db.tipoDato.Include(t => t.CatalogoTipoDato).Include(t => t.Instituciones);
            return View(tipoDato.ToList());
        }

        // GET: TipoDatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDato tipoDato = db.tipoDato.Find(id);
            if (tipoDato == null)
            {
                return HttpNotFound();
            }
            return View(tipoDato);
        }

        // GET: TipoDatoes/Create
        public ActionResult Create()
        {
            ViewBag.id_tipo_dato = new SelectList(db.catalogoTipoDato, "id_tipo_dato", "nombre_tipo_dato");
            ViewBag.id_institucion = new SelectList(db.instituciones, "id_institucion", "nombre_institucion");
            return View();
        }

        // POST: TipoDatoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_dato,nombre_dato,id_institucion,id_tipo_dato")] TipoDato tipoDato)
        {
            if (ModelState.IsValid)
            {
                db.tipoDato.Add(tipoDato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipo_dato = new SelectList(db.catalogoTipoDato, "id_tipo_dato", "nombre_tipo_dato", tipoDato.id_tipo_dato);
            ViewBag.id_institucion = new SelectList(db.instituciones, "id_institucion", "nombre_institucion", tipoDato.id_institucion);
            return View(tipoDato);
        }

        // GET: TipoDatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDato tipoDato = db.tipoDato.Find(id);
            if (tipoDato == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipo_dato = new SelectList(db.catalogoTipoDato, "id_tipo_dato", "nombre_tipo_dato", tipoDato.id_tipo_dato);
            ViewBag.id_institucion = new SelectList(db.instituciones, "id_institucion", "nombre_institucion", tipoDato.id_institucion);
            return View(tipoDato);
        }

        // POST: TipoDatoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_dato,nombre_dato,id_institucion,id_tipo_dato")] TipoDato tipoDato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_dato = new SelectList(db.catalogoTipoDato, "id_tipo_dato", "nombre_tipo_dato", tipoDato.id_tipo_dato);
            ViewBag.id_institucion = new SelectList(db.instituciones, "id_institucion", "nombre_institucion", tipoDato.id_institucion);
            return View(tipoDato);
        }

        // GET: TipoDatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDato tipoDato = db.tipoDato.Find(id);
            if (tipoDato == null)
            {
                return HttpNotFound();
            }
            return View(tipoDato);
        }

        // POST: TipoDatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDato tipoDato = db.tipoDato.Find(id);
            db.tipoDato.Remove(tipoDato);
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
