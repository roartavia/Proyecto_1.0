using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Proyecto_1._0.Models;

namespace Proyecto_1._0.Controllers
{
    public class PeticionesController : Controller
    {
        // GET: Peticiones
        public ActionResult ConsultaPeticiones()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ConsultaPeticiones(Institucion model)
        {
            if (ModelState.IsValid)
            {
                if (model.id_institucion > 0)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction("VerSolicitudes", new { id_institucion = model.id_institucion });
                }
            }
            return View();
        }

        public ViewResult VerSolicitudes(int id_institucion)
        {
            PINTAE_Service1.Service1 servicio = new PINTAE_Service1.Service1();
            string respuestaListaJson = servicio.ConsultarPeticionesJson(id_institucion, true);

            if (respuestaListaJson == "-1") { ViewBag.Error = 1; return View(); } //Error de conexión.
            else if (respuestaListaJson == "-2") { ViewBag.Error = 2; return View(); } //No hay trámites para esa cedula.
            else {
                JArray listPeticiones = JArray.Parse(respuestaListaJson);
                List<PINTAE_Service1.Peticion> listaPeticiones = new List<PINTAE_Service1.Peticion>();

                foreach (JToken token in listPeticiones)
                {
                    listaPeticiones.Add(JsonConvert.DeserializeObject<PINTAE_Service1.Peticion>(token.ToString()));
                }

                //PINTAE_Service.TramiteRealizado product = JsonConvert.DeserializeObject<PINTAE_Service.TramiteRealizado>(listaTramites[0].ToString());
                //PINTAE_Service.TramiteRealizado tramiteTemp = new PINTAE_Service.TramiteRealizado();

                ViewBag.Peticiones = listaPeticiones;

                return View();
            }
        }

        public ViewResult ResponderPeticion(int id_tramite_realizado, int id_dato, string cedula)
        {
            PINTAE_Service1.Service1 servicio = new PINTAE_Service1.Service1();
            string nombreMIMTipodato = servicio.GetNombreCatalogoTipoDato(id_dato, true);

            if (nombreMIMTipodato == "-1") { ViewBag.Error = 1; return View(); } //Error de conexión.
            else if (nombreMIMTipodato == "-2" || nombreMIMTipodato == "") { ViewBag.Error = 2; return View(); } //No hay trámites para esa cedula.
            else {
                PeticionDato peticion = new PeticionDato();
                peticion.Cedula = cedula;
                peticion.Id_dato = id_dato;
                peticion.Id_tramite_solicitado = id_tramite_realizado;
                peticion.Nombre_dato = nombreMIMTipodato;

                ViewBag.TipoDato = nombreMIMTipodato;
                Session["Peticion"] = peticion;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ResponderPeticion(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Get file info
                var fileName = Path.GetFileName(file.FileName);
                var contentLength = file.ContentLength;
                var contentType = file.ContentType;

                // Get file data
                byte[] data = new byte[] { };
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    data = binaryReader.ReadBytes(file.ContentLength);
                }


                PeticionDato peticion = (PeticionDato)Session["Peticion"];

                PINTAE_Service1.Service1 servicio = new PINTAE_Service1.Service1();
                string response = servicio.CallProcEntregarDato(peticion.Id_dato, true, peticion.Id_tramite_solicitado, true, data, peticion.Cedula);
                if (response == "1") { return RedirectToAction("ConsultaPeticiones"); }
                else { return RedirectToAction("ConsultaPeticiones"); }
            }
            else
            {
                // Show error ...
                return View("Foo");
            }
        }
    }
}