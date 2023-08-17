using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evidencia1ClaseWeb.Models
{
    public class RolpaginaClass

    {
        [Display(Name = "ID PAGINA")]
        [Key]
        public int IDROLPAGINA { get; set; }
        [Display(Name ="ROL")]
        [Required]
        public int ROL { get; set; }
        [Display(Name ="PAGINA")]
        [Required]

        public int PAGINA { get; set; }
        [Display(Name ="Estatus")]
        [Required]
        public int ESTATUS { get; set; }

    }
}