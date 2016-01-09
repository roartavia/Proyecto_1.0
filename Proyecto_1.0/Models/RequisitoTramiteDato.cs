using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_1._0.Models
{
    public class RequisitoTramiteDato
    {
        [Key]
        public int id_req_tra { get; set; }

        [Required(ErrorMessage = "Se debe ingresar si es obligatorio o no")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No se permite el ingreso de números")]
        public string es_obligatorio { get; set; }

        [ForeignKey("TipoTramite")]
        public int id_tramite { get; set; }

        [ForeignKey("TipoDato")]
        public int id_dato { get; set; }

        public virtual TipoTramite TipoTramite { get; set; }
        public virtual TipoDato TipoDato { get; set; }
    }
}