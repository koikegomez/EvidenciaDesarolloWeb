using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evidencia1ClaseWeb.Models
{
    public class CategoriasClass
    {
        [Display(Name = "Clave categoria")]
        public int idCategoria { get; set; }
        [Display(Name = "Nombre categoria")]
            [Required]
        public string nombre_Categoria { get; set; }
        [Display(Name = "Descripcion categoria")]
        [Required]
        public string kDescripcio { get; set; }
        [Display(Name = "Estatus categoria")]
        [Required]
        public int Estatus { get; set; }
    }
}