//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Evidencia1ClaseWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clientes
    {
        public int idC_liente { get; set; }
        public string nombre_Cliente { get; set; }
        public string apellido_Cliente { get; set; }
        public string eMail { get; set; }
        public Nullable<int> Estatus { get; set; }
        public Nullable<int> Genero { get; set; }
    
        public virtual Genero Genero1 { get; set; }
    }
}