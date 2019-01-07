using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Filters;
using HimsService.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HimsService.Controllers
{
  [Produces("application/json")]
  [Route("api/Procedure")]
  public class ProcedureController : Controller
  {


    private IDailyProcedureRepository DailyProcedure_repo;

    public ProcedureController(IDailyProcedureRepository repo)
    {
      DailyProcedure_repo = repo;
    }


    #region DailyProcedure

    [HttpGet("GetDailyProcedures", Name = "GetDailyProcedures")]
    public IEnumerable<DailyProcedure> GetDailyProcedures()
    {
      return DailyProcedure_repo.GetAll().OrderByDescending(a => a.DailyProcedureId);
    }

    [HttpGet("GetDailyProcedure/{id}", Name = "GetDailyProcedure")]
    public DailyProcedure GetDailyProcedure(long id) => DailyProcedure_repo.GetFirst(a => a.DailyProcedureId == id);

    [HttpPut("UpdateDailyProcedure", Name = "UpdateDailyProcedure")]
    [ValidateModelAttribute]
    public IActionResult UpdateDailyProcedure([FromBody]DailyProcedure model)
    {
      DailyProcedure_repo.Update(model);
      return new OkObjectResult(new { DailyProcedureID = model.DailyProcedureId });
    }

    [HttpPost("AddDailyProcedure", Name = "AddDailyProcedure")]
    [ValidateModelAttribute]
    public IActionResult AddDailyProcedure([FromBody]DailyProcedure model)
    {
      DailyProcedure_repo.Add(model);
      return new OkObjectResult(new { DailyProcedureID = model.DailyProcedureId });
    }

    [HttpDelete("DeleteDailyProcedure/{id}")]
    public IActionResult DeleteDailyProcedure(long id)
    {
      DailyProcedure DailyProcedure = DailyProcedure_repo.Find(id);
      if (DailyProcedure == null)
      {
        return NotFound();
      }

      DailyProcedure_repo.Delete(DailyProcedure);
      return Ok();
    }

    #endregion

  }
}
