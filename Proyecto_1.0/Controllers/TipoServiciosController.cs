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
    public class TipoServiciosController : Controller
    {
        private ConexionDb db = new ConexionDb();

        // GET: TipoServicios
        public ActionResult Index()
        {
            var tipoServicio = db.tipoServicio.Include(t => t.Instituciones);
            return View(tipoServicio.ToList());
        }

        // GET: TipoServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServicio tipoServicio = db.tipoServicio.Find(id);
            if (tipoServicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoServicio);
        }

        // GET: TipoServicios/Create
        public ActionResult Create()
        {
            ViewBag.id_institucion = new SelectList(db.instituciones, "id_institucion", "nombre_institucion");
            return View();
        }

        // POST: TipoServicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_servicio,nombre_servicio,id_institucion")] TipoServicio tipoServicio)
        {
            if (ModelState.IsValid)
            {
                db.tipoServicio.Add(tipoServicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_institucion = new SelectList(db.instituciones, "id_institucion", "nombre_institucion", tipoServicio.id_institucion);
            return View(tipoServicio);
        }

        // GET: TipoServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServicio tipoServicio = db.tipoServicio.Find(id);
            if (tipoServicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_institucion = new SelectList(db.instituciones, "id_institucion", "nombre_institucion", tipoServicio.id_institucion);
            return View(tipoServicio);
        }

        // POST: TipoServicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_servicio,nombre_servicio,id_institucion")] TipoServicio tipoServicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoServicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_institucion = new SelectList(db.instituciones, "id_institucion", "nombre_institucion", tipoServicio.id_institucion);
            return View(tipoServicio);
        }

        // GET: TipoServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServicio tipoServicio = db.tipoServicio.Find(id);
            if (tipoServicio == null)
            {
                return HttpNotFound();
            }
            return View(tipoServicio);
        }

        // POST: TipoServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoServicio tipoServicio = db.tipoServicio.Find(id);
            db.tipoServicio.Remove(tipoServicio);
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
