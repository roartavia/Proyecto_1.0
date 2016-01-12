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
        public ActionResult Index(Proyecto_1._0.Models.TipoServicio model)
        {
            MySqlConnection mySqlConnection = new MySqlConnection();
            DataTable table, table2, results;
            table = new DataTable();
            table2 = new DataTable();
            results = new DataTable();
            mySqlConnection.ConnectionString = "server=localhost;user id=pablo;password=141093;database =pintae;persistsecurityinfo=True";

            MySqlCommand cmd = new MySqlCommand("mostrar_requisito_servicio_tramite", mySqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("@servicio", MySqlDbType.Int32)).Value = model.id_servicio;

            MySqlCommand cmd2 = new MySqlCommand("mostrar_requisito_servicio_dato", mySqlConnection);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new MySqlParameter("@servicio", MySqlDbType.Int32)).Value = model.id_servicio;

            if (mySqlConnection.State != ConnectionState.Open)
            {
                mySqlConnection.Open();

                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    sda.Fill(table);
                    using (MySqlDataAdapter sda2 = new MySqlDataAdapter(cmd2))
                    {
                        sda2.Fill(table2);
                        results = table.Copy();
                        results.Merge(table2);
                        return View("Mostrar", results);
                    }
                }
            }
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.id_servicio= new SelectList(db.tipoServicio, "id_servicio", "nombre_servicio");
            return View();
        }
    }
}