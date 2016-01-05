using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_1._0.Models
{
    public class TipoTramite
    {
        [Key]
        public int id_tramite { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el nombre del tramite")]
        public string nombre_tramite { get; set; }

        [ForeignKey("Instituciones")]
        public int id_institucion { get; set; }

        public virtual Instituciones Instituciones { get; set; }
    }
}