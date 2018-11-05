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

        public TvopuController(ITvopuRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetTvopus")]
        public IEnumerable<Tvopu> GetTvopus()
        {
            return _repo.GetAll();
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