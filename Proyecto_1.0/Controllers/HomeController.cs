using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_1._0.Models;
namespace Proyecto_1._0.Controllers
{
    public class HomeController : Controller
    {
        private ConexionDb db = new ConexionDb();
        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "CuentaUsuario");
            }
        }

        public ActionResult About()
        {
            if (Session["Username"].Equals("administrador"))
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "CuentaUsuario");
            }
        }


        public ActionResult Contact()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "CuentaUsuario");
            }
        }
    }

}