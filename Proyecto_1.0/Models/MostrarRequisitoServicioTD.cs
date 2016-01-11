using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_1._0.Models
{
    public class MostrarRequisitoServicioTD
    {
        [Required(ErrorMessage = "Se debe ingresar un dato")]
        public int IDServicio { get; set; }
    }
}