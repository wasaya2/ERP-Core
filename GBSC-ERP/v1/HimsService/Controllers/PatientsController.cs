using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HimsService.Repos.Interfaces;
using ErpCore.Entities;
using System.Text.RegularExpressions;
using ErpInfrastructure.Data;
using ErpCore.Filters;
using ErpCore.Entities.HimsSetup;
using HimsService.ViewModels;
using System.IO;
using ErpCore.Helpers;

namespace HimsService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PatientsController : Controller
    {
        private IPatientRepository _repo;
        private IPartnerRepository partner_repo;
        private IPatientReferenceRepository ref_repo;
        private IPatientDocumentRepository doc_repo;
        private IPatientVitalRepository PatientVital_repo;
        private IVisitRepository Visit_repo;
        private IAppointmentRepository Appointment_repo;

        public PatientsController(IPatientRepository repo, IPartnerRepository partnerrepo, IPatientReferenceRepository refrepo, IPatientDocumentRepository docrepo , IPatientVitalRepository PatientVital, IVisitRepository visit, IAppointmentRepository appointmentrepo)
        {
            _repo = repo;
            partner_repo = partnerrepo;
            ref_repo = refrepo;
            doc_repo = docrepo;
            PatientVital_repo = PatientVital;
            Visit_repo = visit;
            Appointment_repo = appointmentrepo;
        }

        //[HttpGet("GetPatientSetupPermissions/{userid}/{RoleId}/{featureid}", Name = "GetPatientSetupPermissions")]
        //public IEnumerable<Permission> GetPatientSetupPermissions(long userid, long RoleId, long featureid)
        //{
        //    IEnumerable<Permission> per = _repo.GetFeaturePermissions(userid, RoleId, featureid).Permissions.ToList();
        //    return per;
        //}

        #region Patient
        [HttpGet("GetPatients", Name = "GetPatients")]
        public IEnumerable<Patient> GetPatients()
        {
            IEnumerable<Patient> pat = _repo.GetAll();
            pat = pat.OrderByDescending(s => s.PatientId );
            return pat;
        }

        [HttpGet("GetPatientsWithPartners")]
        public IEnumerable<Patient> GetPatientsWithPartners()
        {
            return _repo.GetAll(p => p.Partner);
        }

        [HttpGet("GetPatientsWithPartnersByCompany/{companyid}")]
        public IEnumerable<Patient> GetPatientsWithPartnersByCompany([FromRoute]long companyid)
        {
            return _repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid, p => p.Partner);
        }

        [HttpGet("GetPatientCB")]
        public IEnumerable<PatientsCB> GetPatientCB() => _repo.GetPatientCB();

        [HttpGet("GetPatientWithPartner/{PatientId}")]
        public Patient GetPatientWithPartner(long PatientId)
        {
            return _repo.GetFirst(p => p.PatientId == PatientId, p => p.Partner);
        }
        
        [HttpGet("GetPatient/{id}", Name = "GetPatient")]
        public Patient GetPatient(long id) => _repo.GetFirst(p => p.PatientId == id);

        //[HttpGet("GetPatient/{id}", Name = "GetPatient")]
        //public Patient GetPatient(long id) => _repo.GetFirst(p => p.PatientId == id, a => a.Appointments, b => b.PatientInvoices, c => c.PatientDocuments, d => d.Partner, e => e.PatientReference);

        [HttpGet("GetPatientAppointmentsByPatientId/{id}", Name = "GetPatientAppointmentsByPatientId")]
        public Patient GetPatientAppointmentsByPatientId(long id) => _repo.GetFirst(p => p.PatientId == id, a => a.Appointments);
    
        [HttpGet("GetPatientDetailPatientId/{id}", Name = "GetPatientDetailPatientId")]
        public Patient GetPatientDetailPatientId(long id) => _repo.GetFirst(p => p.PatientId == id, a => a.PatientDocuments, d => d.Partner, e => e.PatientReference ,x=> x.PatientPackage);

        [HttpGet("SearchPatient", Name = "SearchPatient")]
        public IEnumerable<Patient> SearchPatient(SearchPatientViewModel model)
        {
            return _repo.SearchPatient(model);
        }

        [HttpGet("GetPatientVisits/{patientid}", Name = "GetPatientVisits")]
        public IEnumerable<Visit> GetPatientVisits(long patientid)
        {
          Patient p = _repo.GetFirst(a => a.PatientId == patientid, b => b.Visits, c=> c.Appointments);
          return p.Visits.OrderByDescending(a => a.VisitId);
        }

        [HttpGet("GetPatientLastestDiagnosis/{patientid}", Name = "GetPatientLastestDiagnosis")]
        public IEnumerable<Diagnosis> GetPatientLastestDiagnosis(long patientid)
        {
          var a = _repo.GetLastestVisitDiagnos(patientid);
          return a;
        }

        [HttpGet("GetPatientLatestTest/{patientid}", Name = "GetPatientLatestTest")]
        public IEnumerable<Test> GetPatientLatestTest(long patientid)
        {
          var a = _repo.GetLatestVisitTests(patientid);
          return a;
        }

        [HttpGet("GetPatientbymrn/{mrn}", Name = "GetPatientbymrn")]
        public Patient GetPatientbymrn(string mrn)
        {
          var a = _repo.GetFirst( x => x.MRN == mrn.ToUpper());
          return a;
        }

        private string GenMRN()
        {
            try
            {
                var lastPatient = _repo.GetLast();
                string value = lastPatient.MRN;
                string number = Regex.Match(value, "[0-9]+$").Value;

                return value.Substring(0, value.Length - number.Length) +
                       (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(NullReferenceException)
            {
                return "MRN000000001";
            }
        }

        [HttpPost("AddPatient", Name = "AddPatient")]
        [ValidateModelAttribute]
        public IActionResult AddPatient([FromBody]Patient model)
        {
            model.FullName = (string)(model.FirstName + " " + model.LastName);
            model.Date = DateTime.Now;
            model.MRN = GenMRN();
            model.Display = model.FirstName + " " + model.LastName +"-"+ model.MRN;
            _repo.Add(model);
            return new OkObjectResult(new { patientId = model.PatientId });
        }

        [HttpPut("UpdatePatient", Name = "UpdatePatient")]
        [ValidateModelAttribute]
        public IActionResult UpdatePatient([FromBody]Patient model)
        {
            _repo.Update(model);
            return new OkObjectResult(new { patientId = model.PatientId });
        }

        [HttpDelete("DeletePatient/{id}")]
        public IActionResult DeletePatient(long id)
        {
            Patient patient = _repo.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            _repo.Delete(patient);
            return Ok();
        }

        #endregion

        #region Partner

        [HttpGet("GetPartners", Name = "GetPartners")]
        public IEnumerable<Partner> GetPartners()
        {

            IEnumerable<Partner> par = partner_repo.GetAll();
            par = par.OrderByDescending(s => s.PartnerId);
            return par;
        }

        [HttpGet("GetPartner/{id}", Name = "GetPartner")]
        public Partner GetPartner(long id) => partner_repo.GetFirst(p => p.PartnerId == id);
        
        [HttpPost("AddPartner", Name = "AddPartner")]
        [ValidateModelAttribute]
        public IActionResult AddPartner([FromBody]Partner model)
        {
            model.Display = model.FirstName + " " + model.LastName;
            partner_repo.Add(model);
            return new OkObjectResult(new { PartnerId = model.PartnerId });
        }

        [HttpPut("UpdatePartner", Name = "UpdatePartner")]
        [ValidateModelAttribute]
        public IActionResult UpdatePartner([FromBody]Partner model)
        {
            partner_repo.Update(model);
            return new OkObjectResult(new { PartnerId = model.PartnerId });
        }

        [HttpDelete("DeletePartner/{id}")]
        public IActionResult DeletePartner(long id)
        {
            Partner partner = partner_repo.Find(id);
            if (partner == null)
            {
                return NotFound();
            }

            partner_repo.Delete(partner);
            return Ok();
        }

        #endregion

        #region Patient Reference

        [HttpGet("GetPatientReferences", Name = "GetPatientReferences")]
        public IEnumerable<PatientReference> GetPatientReferences()
        {

            IEnumerable<PatientReference> par = ref_repo.GetAll();
            par = par.OrderByDescending(s => s.PatientReferenceId);
            return par;
        }

        [HttpGet("GetPatientReference/{id}", Name = "GetPatientReference")]
        public PatientReference GetPatientReference(long id) => ref_repo.GetFirst(p => p.PatientReferenceId == id);

        [HttpPost("AddPatientReference", Name = "AddPatientReference")]
        [ValidateModelAttribute]
        public IActionResult AddPatientReference([FromBody]PatientReference model)
        {
            ref_repo.Add(model);
            return new OkObjectResult(new { PatientReferenceId = model.PatientReferenceId });
        }

        [HttpPut("UpdatePatientReference", Name = "UpdatePatientReference")]
        [ValidateModelAttribute]
        public IActionResult UpdatePatientReference([FromBody]PatientReference model)
        {
            ref_repo.Update(model);
            return new OkObjectResult(new { PatientReferenceId = model.PatientReferenceId });
        }


        [HttpDelete("DeletePatientReference/{id}")]
        public IActionResult DeletePatientReference(long id)
        {
            PatientReference PatientReference = ref_repo.Find(id);
            if (PatientReference == null)
            {
                return NotFound();
            }

            ref_repo.Delete(PatientReference);
            return Ok();
        }

    #endregion

        #region Patient Document

        [HttpGet("GetPatientDocuments", Name = "GetPatientDocuments")]
        public IEnumerable<PatientDocument> GetPatientDocuments()
        {

            IEnumerable<PatientDocument> pad = doc_repo.GetAll();
            pad = pad.OrderByDescending(s => s.PatientDocumentId);
            return pad;
        }

        [HttpGet("GetPatientDocument/{id}", Name = "GetPatientDocument")]
        public PatientDocument GetPatientDocument(long id) => doc_repo.GetFirst(p => p.PatientDocumentId == id);

    [HttpGet("GetPatientDocumentsByPatientId/{patientid}", Name = "GetPatientDocumentsByPatientId")]
    public IEnumerable<PatientDocument> GetPatientDocumentsByPatientId(long patientid)
    {
      var a = doc_repo.GetAll().OrderByDescending(b => b.PatientDocumentId);
      return a.Where(c => c.PatientId == patientid);
    }


    [HttpPost("AddPatientDocument/{patientid}", Name = "AddPatientDocument")]
        [ValidateModelAttribute]
        public async Task<IActionResult> AddPatientDocument([FromRoute]long patientid, IFormFile f)
        {
            string storePath = patientid.ToString() + "_" + f.Name;
            string docFolder = Path.Combine("PatientDocuments", storePath);

            try
            {
                if (f == null || f.Length == 0)
                {
                    return Content("File not selected");
                }

                string path = FileUploadHandler.GetFilePathForUpload(docFolder, f.FileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await f.CopyToAsync(stream);
                }
            }
            catch (Exception e)
            {
                return Json(new { result = "Upload Failed", error = e.Message });
            }

            string filePath = FileUploadHandler.FileReturnPath(docFolder, f.FileName);

            PatientDocument doc = new PatientDocument
            {
                PatientId = patientid,
                FilePath = filePath,
                DocumentName = f.FileName
            };
            doc_repo.Add(doc);

            return Json(new { FilePath = filePath, PatientID = patientid });
        }

        [HttpPost("AddPatientDocuments/{patientid}", Name = "AddPatientDocuments")]
        [ValidateModelAttribute]
        public async Task<IActionResult> AddPatientDocuments([FromRoute]long patientid, List<IFormFile> models)
        {
            IList<string> filepaths = new List<string>();
            IList<PatientDocument> docs = new List<PatientDocument>();

            foreach (IFormFile f in models)
            {
                string storePath = patientid.ToString() + "_" + f.Name;
                string docFolder = Path.Combine("PatientDocuments", storePath);

                try
                {
                    if (f == null || f.Length == 0)
                    {
                        return Content("File not selected");
                    }

                    string path = FileUploadHandler.GetFilePathForUpload(docFolder, f.FileName);

                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await f.CopyToAsync(stream);
                    }
                }
                catch (Exception e)
                {
                    return Json(new { result = "Upload Failed", error = e.Message });
                }

                string filePath = FileUploadHandler.FileReturnPath(docFolder, f.FileName);

                PatientDocument doc = new PatientDocument
                {
                    PatientId = patientid,
                    FilePath = filePath,
                    DocumentName = f.FileName
                };
                docs.Add(doc);
                filepaths.Add(filePath);
            }

            doc_repo.AddRange(docs);
            return Json(new { FilePaths = filepaths, PatientID = patientid });
        }

        [HttpPost("UpdatePatientDocument/{patientid}", Name = "UpdatePatientDocument")]
        [ValidateModelAttribute]
        async public Task<IActionResult> UpdatePatientDocument([FromRoute]long patientid, [FromBody]List<IFormFile> models)
        {
            if(DeletePatientDocument(patientid) == Ok())
            {
                return await AddPatientDocuments(patientid, models);
            }
            return new BadRequestObjectResult("Failed");
        }

        [HttpDelete("DeletePatientDocument/{id}")]
        public IActionResult DeletePatientDocument(long id)
        {
            PatientDocument PatientDocument = doc_repo.Find(id);
            if (PatientDocument == null)
            {
                return NotFound();
            }

            doc_repo.Delete(PatientDocument);
            return Ok();
        }



    #endregion

        #region

    [HttpGet("GetLastPatientVital/{patientid}", Name = "GetLastPatientVital")]
    public PatientVital GetLastPatientVital(long patientid)
    {
      return _repo.GetLastestPatientVital(patientid);
    }

        #endregion

        #region Get By Company, Country, City or Branch

        [HttpGet("GetPatientsByCompany/{id}", Name = "GetPatientsByCompany")]
            public IEnumerable<Patient> GetPatientsByCompany(long id)
            {
                //IEnumerable<User> us = _repo.GetAll();
                //us = us.Where(a => a.CompanyId == id);
                //return us;
                return _repo.GetList(a => a.CompanyId == id);
            }

            [HttpGet("GetPatientsByCountry/{id}", Name = "GetPatientsByCountry")]
            public IEnumerable<Patient> GetPatientsByCountry(long id)
            {

                //IEnumerable<User> us = _repo.GetAll();
                //us = us.Where(a => a.CountryId == id);
                //return us;
                return _repo.GetList(a => a.CountryId == id);
            }

            [HttpGet("GetPatientsByCity/{id}", Name = "GetPatientsByCity")]
            public IEnumerable<Patient> GetPatientsByCity(long id)
            {
                //IEnumerable<User> us = _repo.GetAll();
                //us = us.Where(a => a.CityId == id);
                //return us;
                return _repo.GetList(a => a.CityId == id);
            }

            [HttpGet("GetPatientsByBranch/{id}", Name = "GetPatientsByBranch")]
            public IEnumerable<Patient> GetPatientsByBranch(long id)
            {
                //IEnumerable<User> us = _repo.GetAll();
                //us = us.Where(a => a.BranchId == id);
                //return us;
                return _repo.GetList(a => a.BranchId == id);
            }
            #endregion

        #region Add By Patient ID



        #endregion

        [HttpGet("GetFinalizedAppointmentsByMrnAndMonthYear/{MRN}/{date}", Name = "GetFinalizedAppointmentsByMrnAndMonthYear")]
        public IEnumerable<Appointment> GetFinalizedAppointmentsByMrnAndMonthYear(string MRN, DateTime date)
        {
            try
            {
                return Appointment_repo.GetFinalizedAppointmentsByPatientIdAndMonthYear(_repo.GetFirst(a => a.MRN != null && a.MRN == MRN.ToUpper()).PatientId, date);
            }
            catch(NullReferenceException)
            {
                return null;
            }
        }

        [HttpGet("GetPatientWithPackageAndPartnerByMRN/{mrn}", Name = "GetPatientWithPackageAndPartnerByMRN")]
        public Patient GetPatientWithPackageAndPartnerByMRN(string mrn)
        {
            try
            {
                return _repo.GetFirst(a => a.MRN != null && a.MRN == mrn.ToUpper(), b => b.PatientPackage, c => c.Partner);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        [HttpGet("GetPatientInvoicesWithDetailsByMRN/{mrn}", Name = "GetPatientInvoicesWithDetailsByMRN")]
        public Patient GetPatientInvoicesWithDetailsByMRN(string mrn)
        {
            try
            {
                return _repo.GetPatientInvoicesWithDetailsByMRN(mrn.ToUpper());
            }
            catch(NullReferenceException)
            {
                return null;
            }
        }

        [HttpGet("GetPatientInvoiceReturnsWithDetailsByMRN/{mrn}", Name = "GetPatientInvoiceReturnsWithDetailsByMRN")]
        public Patient GetPatientInvoiceReturnsWithDetailsByMRN(string mrn)
        {
            try
            {
                return _repo.GetPatientInvoiceReturnsWithDetailsByMRN(mrn.ToUpper());
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        [HttpGet("GetPatientInvoicesWithDetailsByMRNandDate/{mrn}/{date}", Name = "GetPatientInvoicesWithDetailsByMRNandDate")]
        public IEnumerable<PatientInvoice> GetPatientInvoicesWithDetailsByMRNandDate(string mrn, DateTime date)
        {
            try
            {
                return _repo.GetPatientInvoicesWithDetailsByMRNandDate(mrn.ToUpper(), date).OrderByDescending(a => a.AppointmentId);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        [HttpGet("GetPatientInvoiceReturnsWithDetailsByMRNandDate/{mrn}/{date}", Name = "GetPatientInvoiceReturnsWithDetailsByMRNandDate")]
        public IEnumerable<PatientInvoiceReturn> GetPatientInvoiceReturnsWithDetailsByMRNandDate(string mrn, DateTime date)
        {
            try
            {
                return _repo.GetPatientInvoiceReturnsWithDetailsByMRNandDate(mrn.ToUpper(), date).OrderByDescending(a => a.PatientInvoiceReturnId);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }


    }
}
