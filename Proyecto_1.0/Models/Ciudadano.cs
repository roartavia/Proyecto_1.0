using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_1._0.Models
{
    public class Ciudadano
    {
        [Required]
        [StringLength(100, ErrorMessage = "Debe de digital el número de cédula. (Completo y solo los números)", MinimumLength = 1)]
        public String Cedula { get; set; }
    }
}