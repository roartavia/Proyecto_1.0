using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace Proyecto_1._0.Controllers
{
    public class ViewDataController : Controller
    {
        // GET: ViewData
        public string ViewServices()
        {
            PINTAE_Service.Service1 servicio = new PINTAE_Service.Service1();
            string res = servicio.ConsultaTramitesCiudadanoJson();
            return res;
        }
    }
}