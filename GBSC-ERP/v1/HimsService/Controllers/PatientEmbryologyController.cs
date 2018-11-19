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
    [Route("api/PatientEmbryology")]
    public class PatientEmbryologyController : Controller
    {
        private IPatientEmbryologyRepository _repo;

        public PatientEmbryologyController(IPatientEmbryologyRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllPatientEmbryologies")]
        public IEnumerable<PatientEmbryology> GetAllPatientEmbryologies()
        {
            return _repo.GetAll();
        }

        [HttpGet("GetPatientEmbryologyByTvopuId/{Id}")]
        public PatientEmbryology GetPatientEmbryologyByTvopuId(long Id)
        {
            return _repo.GetFirst(c => c.TvopuId == Id, c => c.Tvopu, c => c.Tvopu.PatientClinicalRecord, c=> c.PatientEmbryologyDetails);
        }

        [HttpGet("GetPatientEmbryologyDetailsByTvopuId/{Id}")]
        public List<PatientEmbryologyDetails> GetPatientEmbryologyDetailsByTvopuId(long Id)
        {
            var embryology = _repo.GetFirst(c => c.TvopuId == Id, c => c.PatientEmbryologyDetails);
            return embryology.PatientEmbryologyDetails.ToList();
        }

        [HttpGet("GetPatientEmbryology/{id}")]
        public PatientEmbryology GetPatientEmbryology(long id)
        {
            return _repo.GetFirst(e => e.PatientEmbryologyId == id, e => e.PatientEmbryologyDetails);
        }

        [HttpPut("UpdatePatientEmbryology")]
        [ValidateModel]
        public IActionResult UpdatePatientEmbryology([FromBody]PatientEmbryology model)
        {
            _repo.Update(model);

            return new OkObjectResult(new { PatientEmbryologyId = model.PatientEmbryologyId });
        }

        [HttpPost("AddPatientEmbryology")]
        [ValidateModel]
        public IActionResult AddPatientEmbryology([FromBody]PatientEmbryology model)
        {
            _repo.Add(model);

            return new OkObjectResult(new { PatientEmbryologyId = model.PatientEmbryologyId });
        }

        [HttpDelete("DeletePatientEmbryology/{id}")]
        public void DeletePatientEmbryology(long id)
        {
            var PatientEmbryology = _repo.Find(id);

            _repo.Delete(PatientEmbryology);
        }
    }
}