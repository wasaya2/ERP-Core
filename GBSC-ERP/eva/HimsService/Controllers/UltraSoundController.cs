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
    [Route("api/UltraSound")]
    public class UltraSoundController : Controller
    {

      private IUltraSoundPelvisRepository _repo;
      private IFwbInitialRepository FwbInitial_repo;
      private IUltraSoundMasterRepository UltraSoundMaster_repo;

      public UltraSoundController(IUltraSoundPelvisRepository repo , IFwbInitialRepository FwbInitialrepo , IUltraSoundMasterRepository UltraSoundMasterrepo)
      {
        _repo = repo;
        FwbInitial_repo = FwbInitialrepo;
        UltraSoundMaster_repo = UltraSoundMasterrepo;
      }




    #region UltraSoundPelvis

    [HttpGet("GetUltraSoundPelvises", Name = "GetUltraSoundPelvises")]
    public IEnumerable<UltraSoundPelvis> GetUltraSoundPelvises()
    {
      IEnumerable<UltraSoundPelvis> ap = _repo.GetAll();
      ap = ap.OrderByDescending(a => a.UltraSoundPelvisId);
      return ap;
    }

    [HttpGet("GetUltraSoundPelvis/{id}", Name = "GetUltraSoundPelvis")]
    public UltraSoundPelvis GetUltraSoundPelvis(long id) => _repo.GetFirst(a => a.UltraSoundPelvisId == id);

    [HttpPut("UpdateUltraSoundPelvis", Name = "UpdateUltraSoundPelvis")]
    [ValidateModelAttribute]
    public IActionResult UpdateUltraSoundPelvis([FromBody]UltraSoundPelvis model)
    {
      _repo.Update(model);
      return new OkObjectResult(new { UltraSoundPelvisID = model.UltraSoundPelvisId });
    }

    [HttpPost("AddUltraSoundPelvis", Name = "AddUltraSoundPelvis")]
    [ValidateModelAttribute]
    public IActionResult AddUltraSoundPelvis([FromBody]UltraSoundPelvis model)
    {
     _repo.Add(model);
      return new OkObjectResult(new { UltraSoundPelvisID = model.UltraSoundPelvisId });
    }

    [HttpDelete("DeleteUltraSoundPelvis/{id}")]
    public IActionResult DeleteUltraSoundPelvis(long id)
    {
      UltraSoundPelvis ultraSoundPelvis = _repo.Find(id);
      if (ultraSoundPelvis == null)
      {
        return NotFound();
      }

       _repo.Delete(ultraSoundPelvis);
      return Ok();
    }

    #endregion

    #region FwbInitial

    [HttpGet("GetFwbInitials", Name = "GetFwbInitials")]
    public IEnumerable<FwbInitial> GetFwbInitials()
    {
      IEnumerable<FwbInitial> ap = FwbInitial_repo.GetAll();
      ap = ap.OrderByDescending(a => a.FwbInitialId);
      return ap;
    }

    [HttpGet("GetFwbInitial/{id}", Name = "GetFwbInitial")]
    public FwbInitial GetFwbInitial(long id) => FwbInitial_repo.GetFirst(a => a.FwbInitialId == id);

    [HttpPut("UpdateFwbInitial", Name = "UpdateFwbInitial")]
    [ValidateModelAttribute]
    public IActionResult UpdateFwbInitial([FromBody]FwbInitial model)
    {
      FwbInitial_repo.Update(model);
      return new OkObjectResult(new { UltraSoundPelvisID = model.FwbInitialId });
    }

    [HttpPost("AddFwbInitial", Name = "AddFwbInitial")]
    [ValidateModelAttribute]
    public IActionResult AddFwbInitial([FromBody]FwbInitial model)
    {
      FwbInitial_repo.Add(model);
      return new OkObjectResult(new { FwbInitialID = model.FwbInitialId });
    }

    [HttpDelete("DeleteFwbInitial/{id}")]
    public IActionResult DeleteFwbInitial(long id)
    {
      FwbInitial fwbInitials = FwbInitial_repo.Find(id);
      if (fwbInitials == null)
      {
        return NotFound();
      }

      FwbInitial_repo.Delete(fwbInitials);
      return Ok();
    }

    #endregion


    #region UltraSoundMaster

    [HttpGet("GetUltraSoundMasters", Name = "GetUltraSoundMasters")]
    public IEnumerable<UltraSoundMaster> GetUltraSoundMasters()
    {
      IEnumerable<UltraSoundMaster> ap = UltraSoundMaster_repo.GetAll();
      ap = ap.OrderByDescending(a => a.UltraSoundMasterId);
      return ap;
    }

    [HttpGet("GetUltraSoundMaster/{id}", Name = "GetUltraSoundMaster")]
    public UltraSoundMaster GetUltraSoundMaster(long id) => UltraSoundMaster_repo.GetFirst(a => a.UltraSoundMasterId == id);

    [HttpPut("UpdateUltraSoundMaster", Name = "UpdateUltraSoundMaster")]
    [ValidateModelAttribute]
    public IActionResult UpdateUltraSoundMaster([FromBody]UltraSoundMaster model)
    {
      UltraSoundMaster_repo.Update(model);
      return new OkObjectResult(new { UltraSoundMasterID = model.UltraSoundMasterId });
    }

    [HttpPost("AddUltraSoundMaster", Name = "AddUltraSoundMaster")]
    [ValidateModelAttribute]
    public IActionResult AddUltraSoundMaster([FromBody]UltraSoundMaster model)
    {
      UltraSoundMaster_repo.Add(model);
      return new OkObjectResult(new { UltraSoundMasterID = model.UltraSoundMasterId });
    }

    [HttpDelete("DeleteUltraSoundMaster/{id}")]
    public IActionResult DeleteUltraSoundMaster(long id)
    {
      UltraSoundMaster ultraSoundMasters = UltraSoundMaster_repo.Find(id);
      if (ultraSoundMasters == null)
      {
        return NotFound();
      }

      UltraSoundMaster_repo.Delete(ultraSoundMasters);
      return Ok();
    }

    #endregion




  }
}
