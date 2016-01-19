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
    public class TipoTramitesController : Controller
    {
        private ConexionDb db = new ConexionDb();

        // GET: TipoTramites
        public ActionResult Index(string searchString)
        {
            if (Session["Username"] != null)
            {
                if (Session["Username"].Equals("administrador"))
                {
                    //var tipoTramite = db.tipoTramite.Include(t => t.Instituciones);
                    //var tipoServicio = db.tipoServicio.Include(t => t.Instituciones);
                    var tipoTramite = from s in db.tipoTramite
                                       select s;
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        tipoTramite = tipoTramite.Where(s => s.Instituciones.nombre_institucion.Contains(searchString));
                    }
                    return View(tipoTramite.ToList());
                }
                else
                {
                    return RedirectToAction("Index", "CuentaUsuario");
                }
            }
            else
            {
                return RedirectToAction("Index", "CuentaUsuario");
            }
            
        }

        // GET: TipoTramites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTramite tipoTramite = db.tipoTramite.Find(id);
            if (tipoTramite == null)
            {
                return HttpNotFound();
            }
            return View(tipoTramite);
        }

        // GET: TipoTramites/Create
        public ActionResult Create()
        {
            if (Session["Username"] != null)
            {
                ViewBag.id_institucion = new SelectList(db.instituciones, "id_institucion", "nombre_institucion");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "CuentaUsuario");
            }
            
        }

        // POST: TipoTramites/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tramite,nombre_tramite,id_institucion")] TipoTramite tipoTramite)
        {
            if (ModelState.IsValid)
            {
                if (Session["Username"].Equals("administrador"))
                {
                    db.tipoTramite.Add(tipoTramite);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "CuentaUsuario");
                }        
            }

            ViewBag.id_institucion = new SelectList(db.instituciones, "id_institucion", "nombre_institucion", tipoTramite.id_institucion);
            return View(tipoTramite);
        }

        // GET: TipoTramites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTramite tipoTramite = db.tipoTramite.Find(id);
            if (tipoTramite == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_institucion = new SelectList(db.instituciones, "id_institucion", "nombre_institucion", tipoTramite.id_institucion);
            return View(tipoTramite);
        }

        // POST: TipoTramites/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tramite,nombre_tramite,id_institucion")] TipoTramite tipoTramite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTramite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_institucion = new SelectList(db.instituciones, "id_institucion", "nombre_institucion", tipoTramite.id_institucion);
            return View(tipoTramite);
        }

        // GET: TipoTramites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTramite tipoTramite = db.tipoTramite.Find(id);
            if (tipoTramite == null)
            {
                return HttpNotFound();
            }
            return View(tipoTramite);
        }

        // POST: TipoTramites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoTramite tipoTramite = db.tipoTramite.Find(id);
            db.tipoTramite.Remove(tipoTramite);
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
