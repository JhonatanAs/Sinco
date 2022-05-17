using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        
        [JsonIgnore]
        public virtual Asignatura IdMateriaNavigation { get; set; }
        
        [JsonIgnore]
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
