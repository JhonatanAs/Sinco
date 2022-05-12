using System;
using System.Collections.Generic;

#nullable disable

namespace Sinco.Models
{
    public partial class PersonaAsignatura
    {
        public int IdpersonaMateria { get; set; }
        public int IdPersona { get; set; }
        public int IdMateria { get; set; }
        public string Anio { get; set; }
        public double Calificacion { get; set; }

        public virtual Asignatura IdMateriaNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
