using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using HimsService.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HimsService.Controllers
{
    [Produces("application/json")]
    [Route("api/ThawAssessment")]
    public class ThawAssessmentController : Controller
    {
        private readonly IThawAssessmentRepository _repo;

        public ThawAssessmentController(IThawAssessmentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetThawAssessments")]
        public IEnumerable<ThawAssessment> GetThawAssessments()
        {
            return _repo.GetAll();
        }

        [HttpGet("GetThawAssessmentByClinicalRecordId/{id}")]
        public ThawAssessment GetThawAssessmentByClinicalRecordId(long id)
        {
            return _repo.GetFirst(c => c.PatientClinicalRecordId == id, c=>c.EmbryoFreezeThaweds, c=>c.EmbryoFreezeUnthaweds);
        }

        [HttpGet("GetThawAssessmentByTvopuId/{id}")]
        public ThawAssessment GetThawAssessmentByTvopuId(long id)
        {
            return _repo.GetFirst(c => c.TvopuId == id, c => c.EmbryoFreezeThaweds, c => c.EmbryoFreezeUnthaweds);
        }

        [HttpGet("GetThawAssessment/{id}")]
        public ThawAssessment GetThawAssessments(long id)
        {
            return _repo.Find(id);
        }

        [HttpPost("AddThawAssessment")]
        public IActionResult AddThawAssessment([FromBody]ThawAssessment model)
        {
            _repo.Add(model);

            return new OkObjectResult(new { ThawAssessmentId = model.ThawAssessmentId });
        }

        [HttpPut("UpdateThawAssessment")]
        public IActionResult UpdateThawAssessment([FromBody]ThawAssessment model)
        {
            _repo.Update(model);

            return new OkObjectResult(new { ThawAssessmentId = model.ThawAssessmentId });
        }
    }
}