using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_1._0.Models
{
    public class TipoServicio
    {
        [Key]
        public int id_servicio { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el nombre del servicio")]
        public string nombre_servicio { get; set; }

        [ForeignKey("Instituciones")]
        public int id_institucion { get; set; }

        public virtual Instituciones Instituciones { get; set; }


    }
}