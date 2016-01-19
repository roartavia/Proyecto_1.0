using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_1._0.Models
{
    public class RequisitoDato
    {
        [Key]
        public int id_req_dato { get; set; }

        [Required(ErrorMessage = "Se debe ingresar si es obligatorio o no")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No se permite el ingreso de números")]
        public string es_obligatorio { get; set; }

        [ForeignKey("TipoDato")]
        public int id_dato { get; set; }

        [ForeignKey("TipoServicio")]
        public int id_servicio { get; set; }

        public virtual TipoDato TipoDato { get; set; }
        public virtual TipoServicio TipoServicio { get; set; }
    }
}