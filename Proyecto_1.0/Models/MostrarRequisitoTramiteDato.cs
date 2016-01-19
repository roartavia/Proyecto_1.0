using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_1._0.Models
{
    public class MostrarRequisitoTramiteDato
    {
        [Required(ErrorMessage = "*")]
        public int IDTramite { get; set; }
    }
}