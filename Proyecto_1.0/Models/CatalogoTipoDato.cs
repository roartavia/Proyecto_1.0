using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_1._0.Models
{
    public class CatalogoTipoDato
    {
        [Key]
        public int id_tipo_dato { get; set; }

        [Required(ErrorMessage = "Seleccione el tipo de dato")]
        public string nombre_tipo_dato { get; set; }

    }
}