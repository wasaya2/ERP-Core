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

        [HttpGet("GetFrozenEmbryos/{PatientId}")]
        public IEnumerable<EmbryoFreezeUnthawed> GetFrozenEmbryos(long PatientId)
        {
            return _repo.GetFrozonEmbryos(PatientId);
        }

        [HttpGet("GetThawedEmbryos/{PatientId}")]
        public IEnumerable<EmbryoFreezeThawed> GetThawedEmbryos(long PatientId)
        {
            return _repo.GetThawedEmbryos(PatientId);
        }

        [HttpGet("GetThawAssessmentsByPatientId/{PatientId}")]
        public IEnumerable<ThawAssessment> GetThawAssessmentsByPatientId(long PatientId)
        {
            return _repo.GetList(p => p.PatientClinicalRecord?.PatientId == PatientId, p => p.PatientClinicalRecord, p => p.PatientClinicalRecord.Consultant);
        }

        [HttpGet("GetThawAssessmentByClinicalRecordId/{id}")]
        public ThawAssessment GetThawAssessmentByClinicalRecordId(long id)
        {
            return _repo.GetFirst(c => c.PatientClinicalRecordId == id, c => c.EmbryoFreezeThaweds, c => c.EmbryoFreezeUnthaweds);
        }

        [HttpGet("GetThawAssessmentByTvopuId/{id}")]
        public ThawAssessment GetThawAssessmentByTvopuId(long id)
        {
            var assessments = _repo.GetFirst(c => c.TvopuId == id, c => c.EmbryoFreezeThaweds, c => c.EmbryoFreezeUnthaweds);
            return assessments;
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
            try
            {
                _repo.Update(model);

                return new OkObjectResult(new { ThawAssessmentId = model.ThawAssessmentId });
            }
            catch (Exception e)
            {

                throw;
            }

        }

        [HttpDelete("RemoveFrozenEmbryo/{EmbryoFreezeUnthawedId}")]
        public void RemoveFrozenEmbryo(long EmbryoFreezeUnthawedId)
        {
            _repo.RemoveFrozenEmbryo(EmbryoFreezeUnthawedId);
        }

        [HttpPost("AddThawedEmbryo")]
        public IActionResult AddThawedEmbryo([FromBody]EmbryoFreezeThawed embryo)
        {
            _repo.AddThawedEmbryo(embryo);

            return new OkObjectResult(new { EmbryoFreezeThawedId = embryo.EmbryoFreezeThawedId });
        }

        [HttpPut("UpdateThawedEmbryos")]
        public IActionResult UpdateThawedEmbryos([FromBody]IList<EmbryoFreezeThawed> embryos)
        {
            _repo.UpdateThawedEmbryos(embryos);

            return new OkObjectResult(new { result = "Embryos thawed" });
        }
    }
}