using Microsoft.AspNetCore.Mvc;
using Sinco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinco.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PersonaAsignaturaController:ControllerBase
  {
    private readonly ColegiosincoContext sincoContext;

    public PersonaAsignaturaController(ColegiosincoContext context)
    {
      sincoContext = context;
    }

    [Route("alumno-asignatura")]
    [HttpPost]
    public IActionResult Post([FromBody] PersonaAsignatura personaAsignatura)
    {
      try
      {
        PersonaAsignatura personaAsg = sincoContext.PersonaAsignaturas.FirstOrDefault(w => w.Anio == personaAsignatura.Anio && w.IdPersona == personaAsignatura.IdPersona
        && w.IdMateria ==personaAsignatura.IdMateria);
        if(personaAsg!= null)
        {
          return StatusCode(500, $"El alumno ya tiene una calificación para esta asignatura en el anio {personaAsignatura.Anio}");
        }
        sincoContext.PersonaAsignaturas.Add(personaAsignatura);
        sincoContext.SaveChanges();
        return Ok(personaAsignatura);
      }
      catch (Exception)
      {
        return StatusCode(500, "Ocurrio un error durante el proceso, intentelo nuevamente");
      }
    }
  }
}
