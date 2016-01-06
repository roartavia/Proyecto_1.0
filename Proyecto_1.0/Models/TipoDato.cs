using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_1._0.Models
{
    public class TipoDato
    {
        [Key]
        public int id_dato { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el nombre del dato")]
        public string nombre_dato { get; set; }

        [ForeignKey("Instituciones")]
        public int id_institucion { get; set; }

        [ForeignKey("CatalogoTipoDato")]
        public int id_tipo_dato { get; set; }

        public virtual Instituciones Instituciones { get; set; }
        public virtual CatalogoTipoDato CatalogoTipoDato { get; set; }
    }
}