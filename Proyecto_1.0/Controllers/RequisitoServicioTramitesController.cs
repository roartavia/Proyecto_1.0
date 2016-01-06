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
    public class RequisitoServicioTramitesController : Controller
    {
        private ConexionDb db = new ConexionDb();

        // GET: RequisitoServicioTramites
        public ActionResult Index()
        {
            var requisitoServicio = db.requisitoServicio.Include(r => r.TipoServicio).Include(r => r.TipoTramite);
            return View(requisitoServicio.ToList());
        }

        // GET: RequisitoServicioTramites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitoServicioTramite requisitoServicioTramite = db.requisitoServicio.Find(id);
            if (requisitoServicioTramite == null)
            {
                return HttpNotFound();
            }
            return View(requisitoServicioTramite);
        }

        // GET: RequisitoServicioTramites/Create
        public ActionResult Create()
        {
            ViewBag.id_servicio = new SelectList(db.tipoServicio, "id_servicio", "nombre_servicio");
            ViewBag.id_tramite = new SelectList(db.tipoTramite, "id_tramite", "nombre_tramite");
            return View();
        }

        // POST: RequisitoServicioTramites/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_req_ser,nombre_req_tramite,es_obligatorio,id_tramite,id_servicio")] RequisitoServicioTramite requisitoServicioTramite)
        {
            if (ModelState.IsValid)
            {
                db.requisitoServicio.Add(requisitoServicioTramite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_servicio = new SelectList(db.tipoServicio, "id_servicio", "nombre_servicio", requisitoServicioTramite.id_servicio);
            ViewBag.id_tramite = new SelectList(db.tipoTramite, "id_tramite", "nombre_tramite", requisitoServicioTramite.id_tramite);
            return View(requisitoServicioTramite);
        }

        // GET: RequisitoServicioTramites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitoServicioTramite requisitoServicioTramite = db.requisitoServicio.Find(id);
            if (requisitoServicioTramite == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_servicio = new SelectList(db.tipoServicio, "id_servicio", "nombre_servicio", requisitoServicioTramite.id_servicio);
            ViewBag.id_tramite = new SelectList(db.tipoTramite, "id_tramite", "nombre_tramite", requisitoServicioTramite.id_tramite);
            return View(requisitoServicioTramite);
        }

        // POST: RequisitoServicioTramites/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_req_ser,nombre_req_tramite,es_obligatorio,id_tramite,id_servicio")] RequisitoServicioTramite requisitoServicioTramite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisitoServicioTramite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_servicio = new SelectList(db.tipoServicio, "id_servicio", "nombre_servicio", requisitoServicioTramite.id_servicio);
            ViewBag.id_tramite = new SelectList(db.tipoTramite, "id_tramite", "nombre_tramite", requisitoServicioTramite.id_tramite);
            return View(requisitoServicioTramite);
        }

        // GET: RequisitoServicioTramites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequisitoServicioTramite requisitoServicioTramite = db.requisitoServicio.Find(id);
            if (requisitoServicioTramite == null)
            {
                return HttpNotFound();
            }
            return View(requisitoServicioTramite);
        }

        // POST: RequisitoServicioTramites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequisitoServicioTramite requisitoServicioTramite = db.requisitoServicio.Find(id);
            db.requisitoServicio.Remove(requisitoServicioTramite);
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
