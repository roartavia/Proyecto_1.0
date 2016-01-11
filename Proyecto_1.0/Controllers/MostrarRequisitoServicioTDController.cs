using MySql.Data.MySqlClient;
using Proyecto_1._0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_1._0.Controllers
{
    public class MostrarRequisitoServicioTDController : Controller
    {
        private ConexionDb db = new ConexionDb();

        [HttpPost]
        // GET: MostrarRequisitoTramiteDato
        public ActionResult Index(Proyecto_1._0.Models.MostrarRequisitoServicioTD model)
        {
            MySqlConnection mySqlConnection = new MySqlConnection();
            DataTable table = new DataTable();
            mySqlConnection.ConnectionString = "server=localhost;user id=pablo;password=141093;database =pintae;persistsecurityinfo=True";

            MySqlCommand cmd = new MySqlCommand("mostrar_requisito_servicio_tramite", mySqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@servicio", MySqlDbType.Int32)).Value = model.IDServicio;

            MySqlCommand cmd2 = new MySqlCommand("mostrar_requisito_servicio_dato", mySqlConnection);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new MySqlParameter("@servicio", MySqlDbType.Int32)).Value = model.IDServicio;

            if (mySqlConnection.State != ConnectionState.Open)
            {
                mySqlConnection.Open();

                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    sda.Fill(table);
                    using (MySqlDataAdapter sda2 = new MySqlDataAdapter(cmd2))
                    {
                        sda2.Fill(table);
                        return View("Mostrar", table);
                    }
                }
            }
            return View();
        }

        public ActionResult Index()
        {
            //ViewBag.id_tramite = new SelectList(db.tipoTramite, "id_tramite", "nombre_tramite");
            return View();
        }
    }
}