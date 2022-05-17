using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sinco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinco.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PersonasController : ControllerBase
  {

    private readonly ColegiosincoContext sincoContext;

    public PersonasController(ColegiosincoContext context)
    {
      sincoContext = context;
    }

    [Route("users/{tipo}")]
    [HttpGet]
    public IActionResult Get([FromRoute] int tipo)
    {
      try
      {
        IEnumerable<Persona> data =  sincoContext.Personas.Where(w => w.IdTipoPersona == tipo).ToList();
        return Ok(data);
      }
      catch(Exception)
      {
        return StatusCode(500, "ocurrio un error");
      }
    }

    [Route("users")]
    [HttpPost]
    public IActionResult Post([FromBody] Persona persona)
    {
      try
      {
        sincoContext.Personas.Add(persona);
        sincoContext.SaveChanges();
        return Ok(persona);
      }
      catch (Exception)
      {
        return StatusCode(500, "ocurrio un error");
      }
    }
    [Route("users/{idPersona}")]
    [HttpDelete]
    public IActionResult Delete([FromRoute] int idPersona)
    {
      try
      {
        Persona user = sincoContext.Personas.FirstOrDefault(w=>w.IdPersona == idPersona);
        if(user != null)
        {
          PersonaAsignatura perAsignatura = sincoContext.PersonaAsignaturas.FirstOrDefault(w => w.IdPersona == idPersona);
          if (perAsignatura != null)
          {
            return StatusCode(500, "No es posible eliminar un alumno con asignaturas vinculadas");
          }
          sincoContext.Personas.Attach(user);
          sincoContext.Personas.Remove(user);
          sincoContext.SaveChanges();
          return Ok(idPersona);

        }
        return StatusCode(500,"Alumno no encontrado");

      }
      catch (Exception)
      {
        return StatusCode(500, "ocurrio un error");
      }
    }


  }
}
