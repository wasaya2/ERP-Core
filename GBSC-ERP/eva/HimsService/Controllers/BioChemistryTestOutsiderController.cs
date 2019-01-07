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
    [Route("api/BioChemistryTestOutsider")]
    public class BioChemistryTestOutsiderController : Controller
    {
        private IBioChemistryTestOutsiderRepository _repo;

        public BioChemistryTestOutsiderController(IBioChemistryTestOutsiderRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllBioChemistryTestOutsiders")]
        public IEnumerable<BioChemistryTestOutsider> GetAllBioChemistryTestOutsiders()
        {
            return _repo.GetAll();
        }

        [HttpGet("GetBioChemistryTestOutsider/{id}")]
        public BioChemistryTestOutsider GetBioChemistryTestOutsider(long id)
        {
            return _repo.GetFirst(p => p.BioChemistryTestOutsiderId == id, p => p.BioChemistryTestDetails);
        }

        [HttpGet("GetBioChemistryTestOutsiderByPatientId/{id}")]
        public IEnumerable<BioChemistryTestOutsider> GetBioChemistryTestOutsiderByPatientId(long id)
        {
            return _repo.GetList(p => p.PatientId == id, p => p.Consultant);
        }

        [HttpPut("UpdateBioChemistryTestOutsider")]
        [ValidateModel]
        public IActionResult UpdateBioChemistryTestOutsider([FromBody]BioChemistryTestOutsider model)
        {
            _repo.Update(model);

            return new OkObjectResult(new { BioChemistryTestOutsiderId = model.BioChemistryTestOutsiderId });
        }

        [HttpPost("AddBioChemistryTestOutsider")]
        [ValidateModel]
        public IActionResult AddBioChemistryTestOutsider([FromBody]BioChemistryTestOutsider model)
        {
            _repo.Add(model);

            return new OkObjectResult(new { BioChemistryTestOutsiderId = model.BioChemistryTestOutsiderId });
        }

        [HttpDelete("DeleteBioChemistryTestOutsider/{id}")]
        public void DeleteBioChemistryTestOutsider(long id)
        {
            var BioChemistryTestOutsider = _repo.Find(id);

            _repo.Delete(BioChemistryTestOutsider);
        }
    }
}