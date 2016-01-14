using Proyecto_1._0.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace Proyecto_1._0.Controllers
{
    public class MostrarRequisitoTramiteDatoController : Controller
    {
        private ConexionDb db = new ConexionDb();

        [HttpPost]
        // GET: MostrarRequisitoTramiteDato
        public ActionResult Index(Proyecto_1._0.Models.RequisitoTramiteDato model)
        {
            MySqlConnection mySqlConnection = new MySqlConnection();
            DataTable table = new DataTable();
            mySqlConnection.ConnectionString = "server=localhost;user id=root;password=1234;database =pintae;persistsecurityinfo=True";
            MySqlCommand cmd = new MySqlCommand("mostrar_requisito_tramite_dato", mySqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@tramite", MySqlDbType.Int32)).Value = model.id_tramite;
            if (mySqlConnection.State != ConnectionState.Open)
            {
                mySqlConnection.Open();

                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    sda.Fill(table);
                    return View("Mostrar", table);
                }
            }
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.id_tramite = new SelectList(db.tipoTramite, "id_tramite", "nombre_tramite");
            return View();
        }

        [HttpPost]
        protected void  pagina_servicios(object sender, EventArgs e)
        {
            RedirectToAction("Index", "Home");
        }
        
    }
}