using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_1._0.Models
{
    public class CuentaUsuario
    {
        [Key]
        public int id_cuenta_usuario { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string nombre_usuario { get; set; }

        [Required(ErrorMessage = "La contrasena es requerida")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "El rol es necesario")]
        public string Roles { get; set; }

    }
}