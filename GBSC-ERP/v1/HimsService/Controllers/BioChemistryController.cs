using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.HimsSetup;
using ErpCore.Filters;
using HimsService.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HimsService.Controllers
{
    [Produces("application/json")]
    [Route("api/BioChemistry")]
    public class BioChemistryTestOnTreatmentController : Controller
    {
        private IBioChemistryTestRepository biotest_repo;
        private IReferenceRangeRepository ref_repo;
        private ITestUnitRepository unit_repo;
        private IBioChemistryTestDetailsRepository biodetail_repo;
        private IBioChemistryTestOnTreatmentRepository patientbio_repo;

        public BioChemistryTestOnTreatmentController(IBioChemistryTestRepository biotestrepo,
                                      IReferenceRangeRepository refrepo,
                                      ITestUnitRepository unitrepo,
                                      IBioChemistryTestDetailsRepository biodetailrepo,
                                      IBioChemistryTestOnTreatmentRepository patientbiorepo)
        {
            biotest_repo = biotestrepo;
            ref_repo = refrepo;
            unit_repo = unitrepo;
            biodetail_repo = biodetailrepo;
            patientbio_repo = patientbiorepo;
        }

        #region BioChemistryTest

        [HttpGet("GetBioChemistryTests", Name = "GetBioChemistryTests")]
        public IEnumerable<BioChemistryTest> GetBioChemistryTests()
        {
            IEnumerable<BioChemistryTest> ap = biotest_repo.GetAll();
            ap = ap.OrderByDescending(a => a.BioChemistryTestId);
            return ap;
        }

        [HttpGet("GetBioChemistryTest/{id}", Name = "GetBioChemistryTest")]
        public BioChemistryTest GetBioChemistryTest(long id) => biotest_repo.GetFirst(a => a.BioChemistryTestId == id);

        [HttpPut("UpdateBioChemistryTest", Name = "UpdateBioChemistryTest")]
        [ValidateModelAttribute]
        public IActionResult UpdateBioChemistryTest([FromBody]BioChemistryTest model)
        {
            biotest_repo.Update(model);
            return new OkObjectResult(new { BioChemistryTestID = model.BioChemistryTestId });
        }

        [HttpPost("AddBioChemistryTest", Name = "AddBioChemistryTest")]
        [ValidateModelAttribute]
        public IActionResult AddBioChemistryTest([FromBody]BioChemistryTest model)
        {
            biotest_repo.Add(model);
            return new OkObjectResult(new { BioChemistryTestID = model.BioChemistryTestId });
        }

        [HttpDelete("DeleteBioChemistryTest/{id}")]
        public IActionResult DeleteBioChemistryTest(long id)
        {
            BioChemistryTest test = biotest_repo.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            biotest_repo.Delete(test);
            return Ok();
        }

        #endregion

        #region BioChemistryTestDetail

        [HttpGet("GetBioChemistryTestDetails", Name = "GetBioChemistryTestDetails")]
        public IEnumerable<BioChemistryTestDetails> GetBioChemistryTestDetails()
        {
            IEnumerable<BioChemistryTestDetails> ap = biodetail_repo.GetAll();
            ap = ap.OrderByDescending(a => a.BioChemistryTestId);
            return ap;
        }

        [HttpGet("GetBioChemistryTestDetail/{id}", Name = "GetBioChemistryTestDetail")]
        public BioChemistryTestDetails GetBioChemistryTestDetail(long id) => biodetail_repo.GetFirst(a => a.BioChemistryTestDetailsId == id);

        [HttpPut("UpdateBioChemistryTestDetail", Name = "UpdateBioChemistryTestDetail")]
        [ValidateModelAttribute]
        public IActionResult UpdateBioChemistryTestDetail([FromBody]BioChemistryTestDetails model)
        {
            biodetail_repo.Update(model);
            return new OkObjectResult(new { BioChemistryTestDetailsID = model.BioChemistryTestDetailsId });
        }

        [HttpPost("AddBioChemistryTestDetail", Name = "AddBioChemistryTestDetail")]
        [ValidateModelAttribute]
        public IActionResult AddBioChemistryTestDetail([FromBody]BioChemistryTestDetails model)
        {
            biodetail_repo.Add(model);
            return new OkObjectResult(new { BioChemistryTestDetailsID = model.BioChemistryTestDetailsId });
        }

        [HttpDelete("DeleteBioChemistryTestDetail/{id}")]
        public IActionResult DeleteBioChemistryTestDetail(long id)
        {
            BioChemistryTestDetails test = biodetail_repo.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            biodetail_repo.Delete(test);
            return Ok();
        }

        #endregion

        #region PatientBioChemistryTest

        [HttpGet("GetPatientBioChemistryTests", Name = "GetPatientBioChemistryTests")]
        public IEnumerable<BioChemistryTestOnTreatment> GetPatientBioChemistryTests()
        {
            IEnumerable<BioChemistryTestOnTreatment> ap = patientbio_repo.GetAll();
            ap = ap.OrderByDescending(a => a.BioChemistryTestOnTreatmentId);
            return ap;
        }

        [HttpGet("GetPatientBioChemistryTest/{id}", Name = "GetPatientBioChemistryTest")]
        public BioChemistryTestOnTreatment GetPatientBioChemistryTest(long id) => patientbio_repo.Find(id);

        [HttpGet("GetPatientBioChemistryTestByClinicalRecordId/{id}")]
        public BioChemistryTestOnTreatment GetPatientBioChemistryTestByClinicalRecordId(long id) => patientbio_repo.GetFirst(c=>c.PatientClinicalRecordId == id, c=>c.BioChemistryTestDetails);

        [HttpPut("UpdatePatientBioChemistryTest", Name = "UpdatePatientBioChemistryTest")]
        [ValidateModelAttribute]
        public IActionResult UpdatePatientBioChemistryTest([FromBody]BioChemistryTestOnTreatment model)
        {
            patientbio_repo.Update(model);
            return new OkObjectResult(new { PatientBioChemistryTestID = model.BioChemistryTestOnTreatmentId });
        }

        [HttpPost("AddPatientBioChemistryTest", Name = "AddPatientBioChemistryTest")]
        [ValidateModelAttribute]
        public IActionResult AddPatientBioChemistryTest([FromBody]BioChemistryTestOnTreatment model)
        {
            patientbio_repo.Add(model);
            return new OkObjectResult(new { PatientBioChemistryTestID = model.BioChemistryTestOnTreatmentId });
        }

        [HttpDelete("DeletePatientBioChemistryTest/{id}")]
        public IActionResult DeletePatientBioChemistryTest(long id)
        {
            BioChemistryTestOnTreatment test = patientbio_repo.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            patientbio_repo.Delete(test);
            return Ok();
        }

        #endregion

        #region TestUnit

        [HttpGet("GetTestUnits", Name = "GetTestUnits")]
        public IEnumerable<TestUnit> GetTestUnits()
        {
            IEnumerable<TestUnit> ap = unit_repo.GetAll();
            ap = ap.OrderByDescending(a => a.TestUnitId);
            return ap;
        }

        [HttpGet("GetTestUnit/{id}", Name = "GetTestUnit")]
        public TestUnit GetTestUnit(long id) => unit_repo.GetFirst(a => a.TestUnitId == id);

        [HttpPut("UpdateTestUnit", Name = "UpdateTestUnit")]
        [ValidateModelAttribute]
        public IActionResult UpdateTestUnit([FromBody]TestUnit model)
        {
            unit_repo.Update(model);
            return new OkObjectResult(new { TestUnitID = model.TestUnitId });
        }

        [HttpPost("AddTestUnit", Name = "AddTestUnit")]
        [ValidateModelAttribute]
        public IActionResult AddTestUnit([FromBody]TestUnit model)
        {
            unit_repo.Add(model);
            return new OkObjectResult(new { TestUnitID = model.TestUnitId });
        }

        [HttpDelete("DeleteTestUnit/{id}")]
        public IActionResult DeleteTestUnit(long id)
        {
            TestUnit test = unit_repo.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            unit_repo.Delete(test);
            return Ok();
        }

        #endregion

        #region ReferenceRange

        [HttpGet("GetReferenceRanges", Name = "GetReferenceRanges")]
        public IEnumerable<ReferenceRange> GetReferenceRanges()
        {
            IEnumerable<ReferenceRange> ap = ref_repo.GetAll();
            ap = ap.OrderByDescending(a => a.ReferenceRangeId);
            return ap;
        }

        [HttpGet("GetReferenceRange/{id}", Name = "GetReferenceRange")]
        public ReferenceRange GetReferenceRange(long id) => ref_repo.GetFirst(a => a.ReferenceRangeId == id);

        [HttpPut("UpdateReferenceRange", Name = "UpdateReferenceRange")]
        [ValidateModelAttribute]
        public IActionResult UpdateReferenceRange([FromBody]ReferenceRange model)
        {
            ref_repo.Update(model);
            return new OkObjectResult(new { ReferenceRangeID = model.ReferenceRangeId });
        }

        [HttpPost("AddReferenceRange", Name = "AddReferenceRange")]
        [ValidateModelAttribute]
        public IActionResult AddReferenceRange([FromBody]ReferenceRange model)
        {
            ref_repo.Add(model);
            return new OkObjectResult(new { ReferenceRangeID = model.ReferenceRangeId });
        }

        [HttpDelete("DeleteReferenceRange/{id}")]
        public IActionResult DeleteReferenceRange(long id)
        {
            ReferenceRange range = ref_repo.Find(id);
            if (range == null)
            {
                return NotFound();
            }

            ref_repo.Delete(range);
            return Ok();
        }

        #endregion
    }
}
