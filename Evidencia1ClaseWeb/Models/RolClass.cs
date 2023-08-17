using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evidencia1ClaseWeb.Models
{
    public class RolClass
    {
        [Display(Name =" ID ROL")]
        [Key]
        public int IDROL { get; set; }
        [Display(Name = "NOMBRE" )]
        [Required]  
        public string NOMBRE { get; set; }
        [Display(Name ="DESCRIPCIÓN")]
        [Required]
        public string DESCRIPCION { get; set; }
    }
}