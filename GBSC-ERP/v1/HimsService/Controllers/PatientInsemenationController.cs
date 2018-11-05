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
    [Route("api/PatientInsemenation")]
    public class PatientInsemenationController : Controller
    {
        private readonly IPatientInsemenationRepository _PatientInsemenationRepo;

        public PatientInsemenationController(IPatientInsemenationRepository PatientInsemenationRepo)
        {
            _PatientInsemenationRepo = PatientInsemenationRepo;
        }


        [HttpGet("GetPatientInsemenations")]
        public IEnumerable<PatientInsemenation> GetPatientInsemenations()
        {
            return _PatientInsemenationRepo.GetAll();
        }

        [HttpGet("GetPatientInsemenationByClinicalRecordId/{id}")]
        public PatientInsemenation GetPatientInsemenationByClinicalRecordId(long id)
        {
            return _PatientInsemenationRepo.GetFirst(p => p.PatientClinicalRecordId == id);
        }

        [HttpGet("GetPatientInsemenationById/{Id}")]
        public PatientInsemenation GetPatientInsemenationById(long Id)
        {
            return _PatientInsemenationRepo.GetFirst(b => b.PatientInsemenationId == Id);
        }

        [HttpGet("UpdatePatientInsemenation")]
        [ValidateModelAttribute]
        public IActionResult UpdatePatientInsemenation([FromBody]PatientInsemenation PatientInsemenation)
        {
            _PatientInsemenationRepo.Update(PatientInsemenation);

            return new OkObjectResult(new { PatientInsemenationId = PatientInsemenation.PatientInsemenationId });
        }

        [HttpPost("AddPatientInsemenation")]
        [ValidateModelAttribute]
        public IActionResult AddPatientInsemenation([FromBody]PatientInsemenation PatientInsemenation)
        {
            _PatientInsemenationRepo.Add(PatientInsemenation);

            return new OkObjectResult(new { PatientInsemenationId = PatientInsemenation.PatientInsemenationId });
        }
    }
}