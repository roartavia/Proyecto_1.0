using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_1._0.Models
{
    public class Instituciones
    {
        [Key]
        public int id_institucion { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string nombre_institucion { get; set; }
    }
}