using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_1._0.Models
{
    public class RequisitoServicioTramite
    {
        [Key]
        public int id_req_ser { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el nombre")]
        public string nombre_req_tramite { get; set; }

        [Required(ErrorMessage = "Se debe ingresar si es obligatorio o no")]
        public string es_obligatorio { get; set; }

        [ForeignKey("TipoTramite")]
        public int id_tramite { get; set; }

        [ForeignKey("TipoServicio")]
        public int id_servicio { get; set; }

        public virtual TipoTramite TipoTramite { get; set; }
        public virtual TipoServicio TipoServicio { get; set; }
    }
}