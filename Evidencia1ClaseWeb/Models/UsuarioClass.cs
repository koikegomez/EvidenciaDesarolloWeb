using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace Evidencia1ClaseWeb.Models
{
    public class UsuarioClass
    {
        [Display(Name ="ID USUARIO")]
        [Key]
        public int IDUSUARIO { get; set; }
        [Display(Name ="NOMBRE DEL USUARIO")]
        [Required]
        public string NOMBREUSUARIO { get; set; }
        [Display(Name ="CONTRASEÑA")]
        [Required]
        public string CONTRA { get; set; }
        [Display(Name = "TIPO DE USUARIO")]
        public string TIPOUSUARIO { get; set; }
        
    }
}