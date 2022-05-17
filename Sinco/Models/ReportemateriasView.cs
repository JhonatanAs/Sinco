using System;
using System.Collections.Generic;

#nullable disable

namespace Sinco.Models
{
    public partial class ReportemateriasView
    {
        public string Anio { get; set; }
        public int Identificacion { get; set; }
        public string Materia { get; set; }
        public int IdMateria { get; set; }
        public int IdProfesor { get; set; }
        public double Calificacion { get; set; }
        public string Nombre { get; set; }
        public string Profesor { get; set; }
        public string Aprobo { get; set; }
    }
}
