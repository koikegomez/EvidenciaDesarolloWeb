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
    
    public partial class USUARIO
    {
        public int IDUSUARIO { get; set; }
        public string NOMBREUSUARIO { get; set; }
        public string CONTRA { get; set; }
        public string TIPOUSUARIO { get; set; }
        public Nullable<int> ID { get; set; }
        public Nullable<int> ROL { get; set; }
    
        public virtual ROL ROL1 { get; set; }
    }
}