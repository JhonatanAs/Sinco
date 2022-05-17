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
  public class ReporteController: ControllerBase
  {

    private readonly ColegiosincoContext sincoContext;

    public ReporteController(ColegiosincoContext context)
    {
      sincoContext = context;
    }
  
    [Route("report")]
    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        IEnumerable<ReportemateriasView> data = sincoContext.ReportemateriasViews.ToList();
        return Ok(data);
      }
      catch (Exception)
      {
        return StatusCode(500, "ocurrio un error");
      }
    }
  }
}
