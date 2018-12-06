using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Filters;
using HimsService.Repos.Interfaces;
using HimsService.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HimsService.Controllers
{
    [Produces("application/json")]
    [Route("api/PatientClinicalRecord")]
    public class PatientClinicalRecordController : Controller
    {
        private IPatientClinicalRecordRepository _repo;

        public PatientClinicalRecordController(IPatientClinicalRecordRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllPatientClinicalRecords")]
        public IEnumerable<PatientClinicalRecord> GetAllPatientClinicalRecords()
        {
            return _repo.GetAll();
        }

        [HttpGet("SearchClinicalRecords")]
        public IEnumerable<ClinicalRecordViewModel> SearchClinicalRecords(string patientname, string spousename, string mrn, long? cyclenumber, long? treatmentnumber)
        {
            return _repo.SearchClinicalRecords(patientname, spousename, mrn, cyclenumber, treatmentnumber);
        }

        [HttpGet("GetClinicalRecordsByPatientId/{Id}")]
        public IEnumerable<PatientClinicalRecord> GetClinicalRecordsByPatientId(long? Id)
        {
            return _repo.GetList(p => p.PatientId == Id);
        }

        [HttpGet("GetPatientClinicalRecord/{id}")]
        public PatientClinicalRecord GetPatientClinicalRecord(long id)
        {
            return _repo.GetFirst(c => c.PatientClinicalRecordId == id, f => f.ClinicalRecordDrugs);
        }

        [HttpGet("GetPatientClinicalRecordWithChildren/{id}")]
        public PatientClinicalRecord GetPatientClinicalRecordWithChildren(long id)
        {
            return _repo.GetFirst(c => c.PatientClinicalRecordId == id,
                f => f.ThawAssessment,
                f => f.PatientInsemenation,
                f => f.InseminationPrep,
                f => f.FreezePrepration,
                f => f.Tvopu,
                f => f.BioChemistryTestOnTreatment,
                f => f.Biopsy);
        }

        [HttpPut("UpdatePatientClinicalRecord")]
        [ValidateModel]
        public IActionResult UpdatePatientClinicalRecord([FromBody]PatientClinicalRecord model)
        {
            _repo.Update(model);

            return new OkObjectResult(new { PatientClinicalRecordId = model.PatientClinicalRecordId });
        }

        [HttpPost("AddPatientClinicalRecord")]
        [ValidateModel]
        public IActionResult AddPatientClinicalRecord([FromBody]PatientClinicalRecord model)
        {
            _repo.Add(model);

            return new OkObjectResult(new { PatientClinicalRecordId = model.PatientClinicalRecordId });
        }

        [HttpDelete("DeletePatientClinicalRecord/{id}")]
        public void DeletePatientClinicalRecord(long id)
        {
            var PatientClinicalRecord = _repo.Find(id);

            _repo.Delete(PatientClinicalRecord);
        }
    }
}