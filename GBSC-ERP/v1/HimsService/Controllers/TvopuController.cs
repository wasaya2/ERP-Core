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
    [Route("api/Tvopu")]
    public class TvopuController : Controller
    {
        private readonly ITvopuRepository _repo;
        private readonly IPatientClinicalRecordRepository _clincRepo;

        public TvopuController(ITvopuRepository repo, IPatientClinicalRecordRepository clincRepo)
        {
            _repo = repo;

            _clincRepo = clincRepo;
        }

        [HttpGet("GetTvopus")]
        public IEnumerable<Tvopu> GetTvopus()
        {
            return _repo.GetAll();
        }

        [HttpGet("GetTvopusByPatientId/{PatientId}")]
        public IEnumerable<Tvopu> GetTvopusByPatientId(long PatientId)
        {
            return _repo.GetList(p => p.PatientClinicalRecord?.PatientId == PatientId, p => p.PatientClinicalRecord, p=>p.PatientClinicalRecord.Consultant);
        }

        [HttpGet("GetTvopuByClinicalRecordId/{id}")]
        public Tvopu GetTvopuByClinicalRecordId(long id)
        {
            return _repo.GetFirst(c => c.PatientClinicalRecordId == id);
        }

        [HttpGet("GetTvopu/{id}")]
        public Tvopu GetTvopus(long id)
        {
            return _repo.Find(id);
        }

        [HttpPost("AddTvopu")]
        public IActionResult AddTvopu([FromBody]Tvopu model)
        {
            _repo.Add(model);

            return new OkObjectResult(new { TvopuId = model.TvopuId });
        }

        [HttpPut("UpdateTvopu")]
        public IActionResult UpdateTvopu([FromBody]Tvopu model)
        {
            _repo.Update(model);

            return new OkObjectResult(new { TvopuId = model.TvopuId });
        }
    }
}