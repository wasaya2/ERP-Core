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
    [Route("api/SemenAnalysis")]
    public class SemenAnalysisController : Controller
    {
        private ISemenAnalysisRepository _repo;
    private IDailySemenAnalysis DailySemenAnalysis_repo;

    public SemenAnalysisController(ISemenAnalysisRepository repo , IDailySemenAnalysis DailySemenAnalysisrepo)
        {
            _repo = repo;
      DailySemenAnalysis_repo = DailySemenAnalysisrepo;


        }
     

        [HttpGet("GetAllSemenAnalyses")]
        public IEnumerable<SemenAnalysis> GetAllSemenAnalyses()
        {
            return _repo.GetAll();
        }

        [HttpGet("GetAllSemenAnalysisByPatientId/{PatientId}")]
        public IEnumerable<SemenAnalysis> GetAllSemenAnalysisByPatientId(long PatientId)
        {
            return _repo.GetList(p=>p.PatientId == PatientId, p=>p.Consultant);
        }

        [HttpGet("GetSemenAnalysis/{id}")]
        public SemenAnalysis GetSemenAnalysis(long id)
        {
            return _repo.Find(id);
        }

        [HttpGet("GetSemenAnalysisByPatientId/{id}")]
        public SemenAnalysis GetSemenAnalysisByPatientId(long id)
        {
            return _repo.GetFirst(s=>s.PatientId == id);
        }

        [HttpPut("UpdateSemenAnalysis")]
        [ValidateModel]
        public IActionResult UpdateSemenAnalysis([FromBody]SemenAnalysis model)
        {
            _repo.Update(model);

            return new OkObjectResult(new { SemenAnalysisId = model.SemenAnalysisId });
        }

        [HttpPost("AddSemenAnalysis")]
        [ValidateModel]
        public IActionResult AddSemenAnalysis([FromBody]SemenAnalysis model)
        {
            _repo.Add(model);

            return new OkObjectResult(new { SemenAnalysisId = model.SemenAnalysisId });
        }

        [HttpDelete("DeleteSemenAnalysis/{id}")]
        public void DeleteSemenAnalysis(long id)
        {
            var SemenAnalysis = _repo.Find(id);

            _repo.Delete(SemenAnalysis);
        }





    #region DailySemenAnalysis

    [HttpGet("GetDailySemenAnalysises", Name = "GetDailySemenAnalysises")]
    public IEnumerable<DailySemenAnalysis> GetDailySemenAnalysises()
    {
      return DailySemenAnalysis_repo.GetAll(b=> b.DailySemenAnalysisProcedures).OrderByDescending(a => a.DailySemenAnalysisId );
    }

    [HttpGet("GetDailySemenAnalysis/{id}", Name = "GetDailySemenAnalysis")]
    public DailySemenAnalysis GetDailySemenAnalysis(long id) => DailySemenAnalysis_repo.GetFirst(a => a.DailySemenAnalysisId == id);

    [HttpPut("UpdateDailySemenAnalysis", Name = "UpdateDailySemenAnalysis")]
    [ValidateModelAttribute]
    public IActionResult UpdateDailySemenAnalysis([FromBody]DailySemenAnalysis model)
    {
      DailySemenAnalysis_repo.Update(model);
      return new OkObjectResult(new { DailySemenAnalysisID = model.DailySemenAnalysisId });
    }

    [HttpPost("AddDailySemenAnalysis", Name = "AddDailySemenAnalysis")]
    [ValidateModelAttribute]
    public IActionResult AddDailySemenAnalysis([FromBody]DailySemenAnalysis model)
    {

      model.CreatedAt = DateTime.Now;
      DailySemenAnalysis_repo.Add(model);
      return new OkObjectResult(new { DailySemenAnalysisID = model.DailySemenAnalysisId });
    }

    [HttpDelete("DeleteDailySemenAnalysis/{id}")]
    public IActionResult DeleteDailySemenAnalysis(long id)
    {
      DailySemenAnalysis DailySemenAnalysis = DailySemenAnalysis_repo.Find(id);
      if (DailySemenAnalysis == null)
      {
        return NotFound();
      }

      DailySemenAnalysis_repo.Delete(DailySemenAnalysis);
      return Ok();
    }

    #endregion












  }
}
