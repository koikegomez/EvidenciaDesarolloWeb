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
    
    public partial class Genero
    {
        public Genero()
        {
            this.Clientes = new HashSet<Clientes>();
        }
    
        public int id_Sexo { get; set; }
        public string sDescripcion { get; set; }
    
        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
