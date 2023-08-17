using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evidencia1ClaseWeb.Models
{
    public class PaginaClass
    {
        [Display(Name = "ID DEL LA PAGINA")]
        [Key]
        public int IDPAGINA { get; set; }

        [Display(Name = "MENSAJE")]
        [Required]
        public string MENSAJE { get; set; }

        [Display(Name ="ACCIÓN")]
        [Required]
        public string ACCION { get; set; }

        [Display(Name = "CONTROLADOR")]
        [Required]
        public string CONTROLADOR { get; set; }

        [Display(Name ="Estatus Cliente")]
        [Required]
        public int ESTATUS { get; set; }

    }
}