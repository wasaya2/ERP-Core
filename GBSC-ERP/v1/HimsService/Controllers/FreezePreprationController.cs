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
    [Route("api/FreezePrepration")]
    public class FreezePreprationController : Controller
    {
        private IFreezePreprationRepository _repo;

        public FreezePreprationController(IFreezePreprationRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllFreezePreprations")]
        public IEnumerable<FreezePrepration> GetAllFreezePreprations()
        {
            return _repo.GetAll();
        }

        [HttpGet("GetFreezePrepration/{id}")]
        public FreezePrepration GetFreezePrepration(long id)
        {
            return _repo.Find(id);
        }

        [HttpGet("GetFreezePreprationByClinicalRecordId/{id}")]
        public FreezePrepration GetFreezePreprationByClinicalRecordId(long id)
        {
            return _repo.GetFirst(f => f.PatientClinicalRecordId == id);
        }

        [HttpPut("UpdateFreezePrepration")]
        [ValidateModel]
        public IActionResult UpdateFreezePrepration([FromBody]FreezePrepration model)
        {
            _repo.Update(model);

            return new OkObjectResult(new { FreezePreprationId = model.FreezePreprationId });
        }

        [HttpPost("AddFreezePrepration")]
        [ValidateModel]
        public IActionResult AddFreezePrepration([FromBody]FreezePrepration model)
        {
            _repo.Add(model);

            return new OkObjectResult(new { FreezePreprationId = model.FreezePreprationId });
        }

        [HttpDelete("DeleteFreezePrepration/{id}")]
        public void DeleteFreezePrepration(long id)
        {
            var FreezePrepration = _repo.Find(id);

            _repo.Delete(FreezePrepration);
        }
    }
}