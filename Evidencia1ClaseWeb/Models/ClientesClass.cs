using System.ComponentModel.DataAnnotations;

namespace Evidencia1ClaseWeb.Models
{
    public class ClientesClass
    {
        [Display(Name = "ID CLIENTE")]
        [Key]
        public int idC_liente { get; set; }
        [Display(Name = "NOMBRE CLIENTE")]
        [Required]
        public string nombre_Cliente { get; set; }
        [Display(Name = "APELLIDO CLIENTE")]
        [Required]
        public string apellido_Cliente { get; set; }
        [Display(Name = "CORREO ELECTRINICO CLIENTE")]
        [Required]
        [EmailAddress(ErrorMessage = "Ingresa una dirección  valida.")]
        public string eMail { get; set; }

        [Display(Name = "Genero")]

        public int? Genero { get; set; }
      
        public int eStatus { get; set; }

    }
}