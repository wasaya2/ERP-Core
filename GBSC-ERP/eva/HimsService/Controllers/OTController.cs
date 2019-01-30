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
    [Route("api/OT")]
    public class OTController : Controller
    {
      private IOtPatientCaseRepository OtPatientCase_repo;

      public OTController(IOtPatientCaseRepository OtPatientCaserepo)
      {

       OtPatientCase_repo = OtPatientCaserepo;

      }

    #region OtPatientCase

    [HttpGet("GetOtPatientCases", Name = "GetOtPatientCases")]
    public IEnumerable<OtPatientCase> GetOtPatientCases()
    {
      IEnumerable<OtPatientCase> ap = OtPatientCase_repo.GetAll();
      ap = ap.OrderByDescending(a => a.OtPatientCaseId);
      return ap;
    }

    [HttpGet("GetOtPatientCase/{id}", Name = "GetOtPatientCase")]
    public OtPatientCase GetOtPatientCase(long id) => OtPatientCase_repo.GetFirst(a => a.OtPatientCaseId == id);

    [HttpPut("UpdateOtPatientCase", Name = "UpdateOtPatientCase")]
    [ValidateModelAttribute]
    public IActionResult UpdateOtPatientCase([FromBody]OtPatientCase model)
    {
      OtPatientCase_repo.Update(model);
      return new OkObjectResult(new { OtPatientCaseID = model.OtPatientCaseId });
    }

    [HttpPost("AddOtPatientCase", Name = "AddOtPatientCase")]
    [ValidateModelAttribute]
    public IActionResult AddOtPatientCase([FromBody]OtPatientCase model)
    {
      OtPatientCase_repo.Add(model);
      return new OkObjectResult(new { OtPatientCaseID = model.OtPatientCaseId });
    }

    [HttpDelete("DeleteOtPatientCase/{id}")]
    public IActionResult DeleteOtPatientCase(long id)
    {
      OtPatientCase otPatientCases = OtPatientCase_repo.Find(id);
      if (otPatientCases == null)
      {
        return NotFound();
      }

      OtPatientCase_repo.Delete(otPatientCases);
      return Ok();
    }

    #endregion
  }
}
