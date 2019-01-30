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
      private ILaproscopyFsRepository LaproscopyFs_repo;
      private ILaproscopySpRepository LaproscopySp_repo;
      private IHystroscopyRepository Hystroscopy_repo;



    public OTController(IOtPatientCaseRepository OtPatientCaserepo , ILaproscopyFsRepository LaproscopyFsrepo , ILaproscopySpRepository LaproscopySprepo , IHystroscopyRepository Hystroscopyrepo)
      {

       OtPatientCase_repo = OtPatientCaserepo;
       LaproscopyFs_repo = LaproscopyFsrepo;
       LaproscopySp_repo = LaproscopySprepo;
      Hystroscopy_repo = Hystroscopyrepo;
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

    #region LaproscopyFs

    [HttpGet("GetLaproscopyFses", Name = "GetLaproscopyFses")]
    public IEnumerable<LaproscopyFS> GetLaproscopyFses()
    {
      IEnumerable<LaproscopyFS> ap = LaproscopyFs_repo.GetAll();
      ap = ap.OrderByDescending(a => a.LaproscopyFSId);
      return ap;
    }

    [HttpGet("GetLaproscopyFs/{id}", Name = "GetLaproscopyFs")]
    public LaproscopyFS GetLaproscopyFs(long id) => LaproscopyFs_repo.GetFirst(a => a.LaproscopyFSId == id);

    [HttpPut("UpdateLaproscopyFs", Name = "UpdateLaproscopyFs")]
    [ValidateModelAttribute]
    public IActionResult UpdateLaproscopyFs([FromBody]LaproscopyFS model)
    {
      LaproscopyFs_repo.Update(model);
      return new OkObjectResult(new { LaproscopyFsID = model.LaproscopyFSId });
    }

    [HttpPost("AddLaproscopyFs", Name = "AddLaproscopyFs")]
    [ValidateModelAttribute]
    public IActionResult AddLaproscopyFs([FromBody]LaproscopyFS model)
    {
      LaproscopyFs_repo.Add(model);
      return new OkObjectResult(new { LaproscopyFsID = model.LaproscopyFSId });
    }

    [HttpDelete("DeleteLaproscopyFs/{id}")]
    public IActionResult DeleteLaproscopyFs(long id)
    {
      LaproscopyFS LaproscopyFses = LaproscopyFs_repo.Find(id);
      if (LaproscopyFses == null)
      {
        return NotFound();
      }

      LaproscopyFs_repo.Delete(LaproscopyFses);
      return Ok();
    }

    #endregion

    #region LaproscopySp

    [HttpGet("GetLaproscopySps", Name = "GetLaproscopySps")]
    public IEnumerable<LaproscopySp> GetLaproscopySps()
    {
      IEnumerable<LaproscopySp> ap = LaproscopySp_repo.GetAll();
      ap = ap.OrderByDescending(a => a.LaproscopySpId);
      return ap;
    }

    [HttpGet("GetLaproscopySp/{id}", Name = "GetLaproscopySp")]
    public LaproscopySp GetLaproscopySp(long id) => LaproscopySp_repo.GetFirst(a => a.LaproscopySpId == id);

    [HttpPut("UpdateLaproscopySp", Name = "UpdateLaproscopySp")]
    [ValidateModelAttribute]
    public IActionResult UpdateLaproscopySp([FromBody]LaproscopySp model)
    {
      LaproscopySp_repo.Update(model);
      return new OkObjectResult(new { LaproscopySpID = model.LaproscopySpId });
    }

    [HttpPost("AddLaproscopySp", Name = "AddLaproscopySp")]
    [ValidateModelAttribute]
    public IActionResult AddLaproscopySp([FromBody]LaproscopySp model)
    {
      LaproscopySp_repo.Add(model);
      return new OkObjectResult(new { LaproscopySpID = model.LaproscopySpId });
    }

    [HttpDelete("DeleteLaproscopySp/{id}")]
    public IActionResult DeleteLaproscopySp(long id)
    {
      LaproscopySp LaproscopySps = LaproscopySp_repo.Find(id);
      if (LaproscopySps == null)
      {
        return NotFound();
      }

      LaproscopySp_repo.Delete(LaproscopySps);
      return Ok();
    }

    #endregion

    #region Hystroscopy

    [HttpGet("GetHystroscopys", Name = "GetHystroscopys")]
    public IEnumerable<Hystroscopy> GetHystroscopys()
    {
      IEnumerable<Hystroscopy> ap = Hystroscopy_repo.GetAll();
      ap = ap.OrderByDescending(a => a.HystroscopyId);
      return ap;
    }

    [HttpGet("GetHystroscopy/{id}", Name = "GetHystroscopy")]
    public Hystroscopy GetHystroscopy(long id) => Hystroscopy_repo.GetFirst(a => a.HystroscopyId == id);

    [HttpPut("UpdateHystroscopy", Name = "UpdateHystroscopy")]
    [ValidateModelAttribute]
    public IActionResult UpdateHystroscopy([FromBody]Hystroscopy model)
    {
      Hystroscopy_repo.Update(model);
      return new OkObjectResult(new { HystroscopyID = model.HystroscopyId });
    }

    [HttpPost("AddHystroscopy", Name = "AddHystroscopy")]
    [ValidateModelAttribute]
    public IActionResult AddHystroscopy([FromBody]Hystroscopy model)
    {
      Hystroscopy_repo.Add(model);
      return new OkObjectResult(new { HystroscopyID = model.HystroscopyId });
    }

    [HttpDelete("DeleteHystroscopy/{id}")]
    public IActionResult DeleteHystroscopy(long id)
    {
      Hystroscopy Hystroscopys = Hystroscopy_repo.Find(id);
      if (Hystroscopys == null)
      {
        return NotFound();
      }

      Hystroscopy_repo.Delete(Hystroscopys);
      return Ok();
    }

    #endregion

  }
}
