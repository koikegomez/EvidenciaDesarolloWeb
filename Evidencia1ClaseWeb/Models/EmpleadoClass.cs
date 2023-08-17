using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evidencia1ClaseWeb.Models
{
    public class EmpleadoClass
    {
        [Display(Name ="ID")]
        [Key]
        public int idEmpleado { get; set; }
        [Display(Name ="Nombre del empleado")]
        [Required]
        public string nombreEmpleado { get; set; }
        [Display(Name ="Apellido del empleado")]
        [Required]
        public string apellidoEmpleado { get; set; }
        [Display(Name ="Numero del departamento")]
        [Key]
        public int iDepartamento { get; set; }

        public DateTime fechaIngreso { get; set; }
        public string empleadoCelular { get; set; }

        public int Estatus { get; set; }

    }
}