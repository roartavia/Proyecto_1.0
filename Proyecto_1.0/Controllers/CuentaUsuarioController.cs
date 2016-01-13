using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_1._0.Models;

namespace Proyecto_1._0.Controllers
{
    public class CuentaUsuarioController : Controller
    {
        private ConexionDb db = new ConexionDb();
        // GET: Account
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        [Authorize(Users = "juan")]
        public ActionResult Index(CuentaUsuario user)
        {
            //var usr = db.userAccount.Single(u => u.nombre_usuario == user.nombre_usuario && u.password == user.password);
            var usr = db.cuentaUsuario.Where(a => a.nombre_usuario.Equals(user.nombre_usuario) && a.password.Equals(user.password)).FirstOrDefault();
            if (usr != null)
            {
                Session["Username"] = usr.nombre_usuario.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "El Usuario o Contraseña es incorrecta.");
                //return View();
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}