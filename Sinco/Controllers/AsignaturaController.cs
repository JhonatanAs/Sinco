using Microsoft.AspNetCore.Mvc;
using Sinco.Datos.Constantes;
using Sinco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinco.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AsignaturaController: ControllerBase
  {
    private readonly ColegiosincoContext sincoContext;

    public AsignaturaController(ColegiosincoContext context)
    {
      sincoContext = context;
    }

    [Route("asignaturas-alumnos")]
    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        IEnumerable<Asignatura> data = sincoContext.Asignaturas.ToList();
        return Ok(data);
      }
      catch (Exception)
      {
        return StatusCode(500, "Ocurrio un error");
      }
    }

    [Route("asignaturas-profesor")]
    [HttpGet]
    public IActionResult GetDisponibles()
    {
      try
      {
        List<int?> asignadas = sincoContext.Personas.Where(w => w.IdMateria != null).Select(s => s.IdMateria).ToList();
        List<Asignatura> asignaturas = sincoContext.Asignaturas.ToList();
        List<Asignatura> libres = asignaturas.Where(a => !asignadas.Contains(a.Idmateria)).ToList();

        return Ok(libres);
      }
      catch (Exception)
      {
        return StatusCode(500, "Ocurrio un error");
      }
    }

  }
}
