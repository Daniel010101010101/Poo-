//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstudianteDaniel2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class notas
    {
        public int idNotas { get; set; }
        public int idEstudiante { get; set; }
        public int idMateria { get; set; }
        public Nullable<double> nota { get; set; }
    
        public virtual estudiante estudiante { get; set; }
        public virtual materia materia { get; set; }
    }
}
