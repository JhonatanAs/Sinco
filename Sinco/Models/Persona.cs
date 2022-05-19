using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Sinco.Models
{
    public partial class Persona
    {
        public Persona()
        {
            PersonaAsignaturas = new HashSet<PersonaAsignatura>();
        }

        public int IdPersona { get; set; }
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdTipoPersona { get; set; }
        public int? IdMateria { get; set; }

        [JsonIgnore]
        public virtual Asignatura IdMateriaNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<PersonaAsignatura> PersonaAsignaturas { get; set; }
    }
}
