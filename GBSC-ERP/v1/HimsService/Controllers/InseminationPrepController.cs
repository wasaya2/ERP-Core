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
    [Route("api/InseminationPrep")]
    public class InseminationPrepController : Controller
    {
        private readonly IInseminationPrepRepository _inseminationRepo;

        public InseminationPrepController(IInseminationPrepRepository inseminationRepo)
        {
            _inseminationRepo = inseminationRepo;
        }

        [HttpGet("GetInseminationPreps", Name = "GetInseminationPreps")]
        public IEnumerable<InseminationPrep> GetInseminationPreps()
        {
            return _inseminationRepo.GetAll();
        }

        [HttpGet("GetInsemenationPrepByClinicalRecordId/{id}")]
        public InseminationPrep GetInsemenationPrepByClinicalRecordId(long id)
        {
            return _inseminationRepo.GetFirst(i => i.PatientClinicalRecordId == id);
        }


        [HttpPost("AddInseminationPrep")]
        [ValidateModelAttribute]
        public IActionResult AddInseminationPrep([FromBody]InseminationPrep model)
        {
            _inseminationRepo.Add(model);

            return new ObjectResult(new { InseminationPrepId = model.InseminationPrepId });
        }

        [HttpGet("GetInesminationPrep/{Id}")]
        public InseminationPrep GetIneminationPrep(long Id)
        {
            return _inseminationRepo.GetFirst(r => r.InseminationPrepId == Id);
        }

        [HttpPut("UpdateInseminationPrep")]
        public IActionResult UpdateInseminationPrep([FromBody]InseminationPrep model)
        {
            _inseminationRepo.Update(model);

            return new OkObjectResult(new { InseminationPrepID = model.InseminationPrepId });
        }

        [HttpDelete("DeleteInseminationPrep/{id}")]
        public IActionResult DeleteInseminationPrep(long id)
        {
            InseminationPrep range = _inseminationRepo.Find(id);
            if (range == null)
            {
                return NotFound();
            }

            _inseminationRepo.Delete(range);
            return Ok();
        }
    }
}
