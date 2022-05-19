using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Sinco.Models
{
  public partial class Asignatura
  {
    public Asignatura()
    {
      PersonaAsignaturas = new HashSet<PersonaAsignatura>();
      Personas = new HashSet<Persona>();
    }

    public int Idmateria { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }

    [JsonIgnore]
    public virtual ICollection<PersonaAsignatura> PersonaAsignaturas { get; set; }
    [JsonIgnore]
    public virtual ICollection<Persona> Personas { get; set; }
    }
}
