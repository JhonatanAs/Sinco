using System;
using System.Collections.Generic;

#nullable disable

namespace Sinco.Models
{
    public partial class Asignatura
    {
        public Asignatura()
        {
            PersonaAsignaturas = new HashSet<PersonaAsignatura>();
        }

        public int Idmateria { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<PersonaAsignatura> PersonaAsignaturas { get; set; }
    }
}
