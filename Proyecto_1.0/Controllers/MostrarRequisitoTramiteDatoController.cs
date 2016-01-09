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

        [HttpPost]
        // GET: MostrarRequisitoTramiteDato
        public ActionResult Index(Proyecto_1._0.Models.MostrarRequisitoTramiteDato model)
        {
            MySqlConnection mySqlConnection = new MySqlConnection();
            mySqlConnection.ConnectionString = "server=localhost;user id=pablo;password=141093;database =pintae;persistsecurityinfo=True";
            MySqlCommand cmd = new MySqlCommand("mostrar_requisito_tramite_dato", mySqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@tramite", MySqlDbType.VarChar)).Value = model.IDTramite;

            if (mySqlConnection.State != ConnectionState.Open)
            {
                mySqlConnection.Open();

                MySqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(rdr);
                return RedirectToAction("Mostrar");
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}