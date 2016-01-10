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
        protected List<string> keywords = new List<string>();

        [HttpPost]
        // GET: MostrarRequisitoTramiteDato
        public ActionResult Index(Proyecto_1._0.Models.MostrarRequisitoTramiteDato model)
        {
            MySqlConnection mySqlConnection = new MySqlConnection();
            DataTable table = new DataTable();
            mySqlConnection.ConnectionString = "server=localhost;user id=root;password=1234;database =pintae;persistsecurityinfo=True";
            MySqlCommand cmd = new MySqlCommand("mostrar_requisito_tramite_dato", mySqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@tramite", MySqlDbType.VarChar)).Value = model.IDTramite;
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
            return View();
        }
    }
}