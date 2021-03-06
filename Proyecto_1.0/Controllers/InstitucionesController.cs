﻿using System;
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
    public class InstitucionesController : Controller
    {
        private ConexionDb db = new ConexionDb();

        // GET: Instituciones
        public ActionResult Index(string sortOrder, string searchString)
        {
            if (Session["Username"] != null)
            {
                if (Session["Username"].Equals("administrador"))
                {
                    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                    var inst = from s in db.instituciones
                                   select s;
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        inst = inst.Where(s => s.nombre_institucion.Contains(searchString));
                    }
                    switch (sortOrder)
                    {
                        case "name_desc":
                            inst = inst.OrderByDescending(s => s.nombre_institucion);
                            break;
                        default:
                            inst = inst.OrderBy(s => s.nombre_institucion);
                            break;
                    }
                    return View(inst.ToList());
                    //return View(db.instituciones.ToList());
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

        // GET: Instituciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituciones instituciones = db.instituciones.Find(id);
            if (instituciones == null)
            {
                return HttpNotFound();
            }
            return View(instituciones);
        }

        // GET: Instituciones/Create
        public ActionResult Create()
        {
            if (Session["Username"] != null)
            {
                return View();
            } else
            {
                return RedirectToAction("Index", "CuentaUsuario");
            }
            
        }

        // POST: Instituciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_institucion,nombre_institucion")] Instituciones instituciones)
        {
            if (ModelState.IsValid)
            {
                if (Session["Username"].Equals("administrador"))
                {
                    db.instituciones.Add(instituciones);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "CuentaUsuario");
                }
                
            }
            return View(instituciones);
        }

        // GET: Instituciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituciones instituciones = db.instituciones.Find(id);
            if (instituciones == null)
            {
                return HttpNotFound();
            }
            return View(instituciones);
        }

        // POST: Instituciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_institucion,nombre_institucion")] Instituciones instituciones)
        {
            if (ModelState.IsValid)
            {
                if (Session["Username"].Equals("administrador"))
                {
                    db.Entry(instituciones).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "CuentaUsuario");
                }
                
            }
            return View(instituciones);
        }

        // GET: Instituciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituciones instituciones = db.instituciones.Find(id);
            if (instituciones == null)
            {
                return HttpNotFound();
            }
            return View(instituciones);
        }

        // POST: Instituciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instituciones instituciones = db.instituciones.Find(id);
            db.instituciones.Remove(instituciones);
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
