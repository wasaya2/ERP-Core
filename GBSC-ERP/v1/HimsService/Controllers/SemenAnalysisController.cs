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

        public SemenAnalysisController(ISemenAnalysisRepository repo)
        {
            _repo = repo;
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
    }
}