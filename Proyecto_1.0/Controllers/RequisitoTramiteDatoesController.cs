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
    public class RequisitoTramiteDatoesController : Controller
    {
        private ConexionDb db = new ConexionDb();

        // GET: RequisitoTramiteDatoes
        public ActionResult Index()
        {
            var requisitoTramite = db.requisitoTramite.Include(r => r.TipoDato).Include(r => r.TipoTramite);
            return View(requisitoTramite.ToList());
        }

        // GET: RequisitoTramiteDatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitoTramiteDato requisitoTramiteDato = db.requisitoTramite.Find(id);
            if (requisitoTramiteDato == null)
            {
                return HttpNotFound();
            }
            return View(requisitoTramiteDato);
        }

        // GET: RequisitoTramiteDatoes/Create
        public ActionResult Create()
        {
            ViewBag.id_dato = new SelectList(db.tipoDato, "id_dato", "nombre_dato");
            ViewBag.id_tramite = new SelectList(db.tipoTramite, "id_tramite", "nombre_tramite");
            return View();
        }

        // POST: RequisitoTramiteDatoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_req_tra,nombre,es_obligatorio,id_tramite,id_dato")] RequisitoTramiteDato requisitoTramiteDato)
        {
            if (ModelState.IsValid)
            {
                db.requisitoTramite.Add(requisitoTramiteDato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_dato = new SelectList(db.tipoDato, "id_dato", "nombre_dato", requisitoTramiteDato.id_dato);
            ViewBag.id_tramite = new SelectList(db.tipoTramite, "id_tramite", "nombre_tramite", requisitoTramiteDato.id_tramite);
            return View(requisitoTramiteDato);
        }

        // GET: RequisitoTramiteDatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitoTramiteDato requisitoTramiteDato = db.requisitoTramite.Find(id);
            if (requisitoTramiteDato == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_dato = new SelectList(db.tipoDato, "id_dato", "nombre_dato", requisitoTramiteDato.id_dato);
            ViewBag.id_tramite = new SelectList(db.tipoTramite, "id_tramite", "nombre_tramite", requisitoTramiteDato.id_tramite);
            return View(requisitoTramiteDato);
        }

        // POST: RequisitoTramiteDatoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_req_tra,nombre,es_obligatorio,id_tramite,id_dato")] RequisitoTramiteDato requisitoTramiteDato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisitoTramiteDato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_dato = new SelectList(db.tipoDato, "id_dato", "nombre_dato", requisitoTramiteDato.id_dato);
            ViewBag.id_tramite = new SelectList(db.tipoTramite, "id_tramite", "nombre_tramite", requisitoTramiteDato.id_tramite);
            return View(requisitoTramiteDato);
        }

        // GET: RequisitoTramiteDatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitoTramiteDato requisitoTramiteDato = db.requisitoTramite.Find(id);
            if (requisitoTramiteDato == null)
            {
                return HttpNotFound();
            }
            return View(requisitoTramiteDato);
        }

        // POST: RequisitoTramiteDatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequisitoTramiteDato requisitoTramiteDato = db.requisitoTramite.Find(id);
            db.requisitoTramite.Remove(requisitoTramiteDato);
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
