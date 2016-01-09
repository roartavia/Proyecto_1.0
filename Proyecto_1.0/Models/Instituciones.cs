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
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No se permite el ingreso de números")]
        public string nombre_institucion { get; set; }
    }
}