using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mi_Parte.Models;
using System.Threading.Tasks;

namespace Mi_Parte.Controllers
{
    public class ConsultaTramitesController : Controller
    {
        [AllowAnonymous]
        public ActionResult ConsultaPorCedula()
        {  
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ConsultaPorCedula(Ciudadano model)
        {
            if (ModelState.IsValid)
            {
                if (model.Cedula != "")
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction("ViewTramites", new { cedula = model.Cedula });
                }
            }
            return View();
        }

        public ViewResult ViewTramites(string cedula)
        {
            PINTAE_Service.Service1 servicio = new PINTAE_Service.Service1();
            string respuestaListaJson = servicio.ConsultaTramitesPorCedulaJson(cedula);

            if (respuestaListaJson == "-1") { ViewBag.Error = 1; return View(); } //Error de conexión.
            else if (respuestaListaJson == "-2") { ViewBag.Error = 2; return View(); } //No hay trámites para esa cedula.
            else { 
                JArray listaTramitesTempJson = JArray.Parse(respuestaListaJson);
                List<PINTAE_Service.TramiteRealizado> listaTramites = new List<PINTAE_Service.TramiteRealizado>();

                foreach (JToken token in listaTramitesTempJson)
                {
                    listaTramites.Add(JsonConvert.DeserializeObject<PINTAE_Service.TramiteRealizado>(token.ToString()));
                }

                //PINTAE_Service.TramiteRealizado product = JsonConvert.DeserializeObject<PINTAE_Service.TramiteRealizado>(listaTramites[0].ToString());
                //PINTAE_Service.TramiteRealizado tramiteTemp = new PINTAE_Service.TramiteRealizado();

                ViewBag.TramitesCiudadano = listaTramites;

                return View();
            }
        }

        public ActionResult InfoTramite(int id_tramite_realizado)
        {
            PINTAE_Service.Service1 servicio = new PINTAE_Service.Service1();

            string respuestaTramiteJson = servicio.ConsultaTramitePorIdJson(id_tramite_realizado, true);
            if (respuestaTramiteJson == "-1") { ViewBag.Error = 1; return View(); } //Error de conexión.
            else if (respuestaTramiteJson == "-2") { ViewBag.Error = 2; return View(); } //No hay trámites para esa cedula.
            else
            {
                InfoTramiteConsultado infoTramite = JsonConvert.DeserializeObject<InfoTramiteConsultado>(respuestaTramiteJson);

                return View(infoTramite);
            }
        }
    }
}