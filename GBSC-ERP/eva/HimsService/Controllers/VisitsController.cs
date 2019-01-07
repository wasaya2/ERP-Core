using ErpCore.Entities;
using ErpCore.Filters;
using HimsService.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HimsService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VisitsController : Controller
    {
        private IVisitRepository visit_repo;
        private IVisitNoteRepository note_repo;
        private IPatientVitalRepository vital_repo;
        private IVisitTestRepository VisitTest_repo;
        private IVisitDiagnosisRepository VisitDiagnosis_repo;
        private IAppointmentRepository Appointment_repo;
        private IPatientRepository Patient_repo;

        public VisitsController(IVisitRepository visitrepo, IVisitNoteRepository noterepo, IPatientVitalRepository vitalrepo, IVisitDiagnosisRepository VisitDiagnosis,
                              IVisitTestRepository VisitTest, IAppointmentRepository apprepo, IPatientRepository patientrepo)
        {
            visit_repo = visitrepo;
            note_repo = noterepo;
            vital_repo = vitalrepo;
            VisitTest_repo = VisitTest;
            VisitDiagnosis_repo = VisitDiagnosis;
            Appointment_repo = apprepo;
            Patient_repo = patientrepo;
        }
        
        #region Visit
        [HttpGet("GetVisits", Name = "GetVisits")]
        public IEnumerable<Visit> GetVisits()
        {
            IEnumerable<Visit> vt = visit_repo.GetAll(a=> a.Patient , b=>b.PatientVital, t=>t.VisitTests, d=>d.VisitDiagnoses);

            vt = vt.OrderByDescending(a => a.VisitId);
            return vt;
        }

        [HttpGet("GetActiveVisits", Name = "GetActiveVisits")]

        public IEnumerable<Visit> GetActiveVisits()
        {
          IEnumerable<Visit> av = visit_repo.GetActiveVisits().ToList().OrderByDescending(x => x.VisitId);
          return av;
        }

        [HttpGet("GetVisit/{id}", Name = "GetVisit")]
        public Visit GetVisit(long id)
        {
            Visit x = visit_repo.GetFirst(a => a.VisitId == id, b => b.PatientVital , d=> d.VisitNote, vt => vt.VisitTests , vd=> vd.VisitDiagnoses  );
            return x;
        }

        [HttpGet("GetVisitForUpdate/{id}", Name = "GetVisitForUpdate")]
        public Visit GetVisitForUpdate([FromRoute]long id)
        {
            Visit vis = visit_repo.GetFirst(a => a.VisitId == id, b => b.Patient, c => c.PatientVital, d => d.VisitDiagnoses, e => e.VisitNote, f => f.VisitTests);
            try
            {
                if(vis.EndTime == null)
                {
                    return vis;
                }
                else if(DateTime.UtcNow > vis.EndTime.Value.AddMinutes(15))
                {
                    return null;
                }
                return vis;
            }
            catch(Exception)
            {
                return null;
            }
        }

        [HttpPost("AddVisit", Name = "AddVisit")]
        [ValidateModelAttribute]
        public IActionResult AddVisit([FromBody]Visit model)
        {
            model.StartTime = DateTime.Now;
            model.IsActive = true;
            visit_repo.Add(model);

            Patient pat = Patient_repo.Find(model.PatientId);
            if (pat.TotalVisitsToDate == null)
            {
                pat.TotalVisitsToDate = 1;
            }
            else
            {
                pat.TotalVisitsToDate = pat.TotalVisitsToDate + 1;
            }
            Patient_repo.Update(pat);

            return new OkObjectResult(new { VisitID = model.VisitId });
        }

        [HttpPut("EndVisit/{visitId}", Name = "EndVisit")]
        [ValidateModelAttribute]
        public IActionResult EndVisit([FromRoute]long visitId , [FromBody]Visit model)
        {
            model.EndTime = DateTime.Now;
            model.IsActive = false;
            visit_repo.Update(model);
            return new OkObjectResult(new { VisitID = model.VisitId , PatientID = model.PatientId });
        }

        [HttpGet("GetLastestVisitByPatientId/{id}", Name = "GetLastestVisitByPatientId")]
        public Visit GetLastestVisitByPatientId([FromRoute]long id)
        {
            try
            {
                return visit_repo.GetAll().Where(a => a.PatientId == id).OrderByDescending(a => a.VisitId).FirstOrDefault();
            }
            catch(NullReferenceException)
            {
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        [HttpPut("UpdateVisit", Name = "UpdateVisit")]
        [ValidateModelAttribute]
        public IActionResult UpdateVisit([FromBody]Visit model)
        {
            visit_repo.Update(model);
            return new OkObjectResult(new { VisitID = model.VisitId });
        }


        [HttpDelete("DeleteVisit/{id}")]
        public IActionResult DeleteVisit(long id)
        {
            Visit visit = visit_repo.Find(id);
            if (visit == null)
            {
                return NotFound();
            }

            visit_repo.Delete(visit);
            return Ok();
        }
        #endregion

        #region VisitNote
        [HttpGet("GetVisitNotes", Name = "GetVisitNotes")]
        public IEnumerable<VisitNote> GetVisitNotes()
        {
            IEnumerable<VisitNote> vt = note_repo.GetAll();
            vt = vt.OrderByDescending(a => a.VisitNoteId);
            return vt;
        }

        [HttpGet("GetVisitNote/{id}", Name = "GetVisitNote")]
        public VisitNote GetVisitNote(long id)
        {
            VisitNote x = note_repo.GetFirst(a => a.VisitNoteId == id);
            return x;
        }

        [HttpGet("GetVisitNoteByVisitId/{id}", Name = "GetVisitNoteByVisitId")]
        public VisitNote GetVisitNoteByVisitId(long id)
        {
            VisitNote x = note_repo.GetFirst(a => a.VisitId == id);
            return x;
        }

        [HttpPost("AddVisitNote", Name = "AddVisitNote")]
        [ValidateModelAttribute]
        public IActionResult AddVisitNote([FromBody]VisitNote model)
        {
            note_repo.Add(model);
            return new OkObjectResult("Done");
        }

        [HttpPost("AddVisitNoteByVisitId", Name = "AddVisitNoteByVisitId")]
        [ValidateModelAttribute]
        public IActionResult AddVisitNoteByVisitId([FromBody]VisitNote model)
        {
            try
            {
              VisitNote ClinicalNote = note_repo.GetFirst(a => a.VisitId == model.VisitId);
              if (ClinicalNote != null)
              {
                    note_repo.Delete(ClinicalNote);
              }
              note_repo.Add(model);
              return Ok(model.VisitNoteId);
            }
            catch(NullReferenceException e)
            {
              return BadRequest(e);
            }
        }

        [HttpPut("UpdateVisitNote", Name = "UpdateVisitNote")]
        [ValidateModelAttribute]
        public IActionResult UpdateVisitNote([FromBody]VisitNote model)
        {
            note_repo.Update(model);
            return new OkObjectResult(new { VisitNoteId = model.VisitNoteId });
        }


        [HttpDelete("DeleteVisit/{id}")]
        public IActionResult DeleteVisitNote(long id)
        {
            VisitNote note = note_repo.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            note_repo.Delete(note);
            return Ok();
        }
        #endregion

        #region Patient Vital
        [HttpGet("GetPatientVitals", Name = "GetPatientVitals")]
        public IEnumerable<PatientVital> GetPatientVitals()
        {
            IEnumerable<PatientVital> vt = vital_repo.GetAll(a => a.Visit);
            vt = vt.OrderByDescending(a => a.PatientVitalId);
            return vt;
        }

        [HttpGet("GetPatientVital/{id}", Name = "GetPatientVital")]
        public PatientVital GetPatientVital(long id)
        {
            PatientVital x = vital_repo.GetFirst(a => a.PatientVitalId == id, b => b.Visit);
            return x;
        }

        [HttpGet("GetPatientVitalByVisitId/{id}", Name = "GetPatientVitalByVisitId")]
        public PatientVital GetPatientVitalByVisitId(long id)
        {
            PatientVital x = vital_repo.GetFirst(a => a.VisitId == id, b => b.Visit);
            return x;
        }

        [HttpPost("AddPatientVitals", Name = "AddPatientVitals")]
        [ValidateModelAttribute]
        public IActionResult AddPatientVitals([FromBody]PatientVital models)
        {
          
            vital_repo.Add(models);
            Visit vs = visit_repo.Find(models.VisitId);
            vs.PatientVitalId = models.PatientVitalId;
            visit_repo.Update(vs);
            return new OkObjectResult(new { PatientVitalID = models.PatientVitalId });
        }

        [HttpPost("AddPatientVitalsByVisitId", Name = "AddPatientVitalsByVisitId")]
        [ValidateModelAttribute]
        public IActionResult AddPatientVitalsByVisitId([FromBody]PatientVital model)
        {
            try
            {
                PatientVital Vital = vital_repo.GetFirst(a => a.VisitId == model.VisitId);
                if (Vital != null)
                {
                    vital_repo.Delete(Vital);
                }

                vital_repo.Add(model);
                return Ok(model.PatientVitalId);
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("UpdatePatientVital", Name = "UpdatePatientVital")]
        [ValidateModelAttribute]
        public IActionResult UpdatePatientVital([FromBody]PatientVital model)
        {
            vital_repo.Update(model);
            return new OkObjectResult(new { PatientVitalId = model.PatientVitalId });
        }


        [HttpDelete("DeletePatientVital/{id}")]
        public IActionResult DeletePatientVital(long id)
        {
            PatientVital patientVital = vital_repo.Find(id);
            if (patientVital == null)
            {
                return NotFound();
            }

            vital_repo.Delete(patientVital);
            return Ok();
        }
    #endregion

        #region VisitTest
        [HttpGet("GetVisitTests", Name = "GetVisitTests")]
        public IEnumerable<VisitTest> GetVisitTests()
        {
          IEnumerable<VisitTest> vt = VisitTest_repo.GetAll(a => a.Test);
          vt = vt.OrderByDescending(a => a.VisitTestId);
          return vt;
        }

        [HttpGet("GetVisitTest/{id}", Name = "GetVisitTest")]
        public VisitTest GetVisitTest(long id)
        {
          VisitTest x = VisitTest_repo.GetFirst(a => a.VisitTestId == id,  b => b.Test);
          return x;
        }

        [HttpGet("GetVisitTestsByVisitId/{id}", Name = "GetVisitTestsByVisitId")]
        public IEnumerable<VisitTest> GetVisitTestsByVisitId(long id)
        {
            IEnumerable<VisitTest> x = VisitTest_repo.GetAll().Where(a => a.VisitId == id);
            return x;
        }

        [HttpPost("AddVisitTest", Name = "AddVisitTest")]
        [ValidateModelAttribute]
        public IActionResult AddVisitTest([FromBody]VisitTest model)
        {
          VisitTest_repo.Add(model);
          return new OkObjectResult("Done");
        }

        //[HttpPost("AddVisitTestsByVisitId", Name = "AddVisitTestsByVisitId")]
        //[ValidateModelAttribute]
        //public IActionResult AddVisitTestsByVisitId([FromBody]IEnumerable<VisitTest> model)
        //{
        //    VisitTest_repo.DeleteRange(VisitTest_repo.GetAll().Where(a => a.VisitId == model.FirstOrDefault().VisitId));
        //    VisitTest_repo.AddRange(model);
        //    return Ok("Tests Added");
        //}

        [HttpPost("AddVisitTests", Name = "AddVisitTests")]
        [ValidateModelAttribute]
        public IActionResult AddVisitTests([FromBody]IEnumerable<VisitTest> model)
        {
          VisitTest_repo.AddRange(model);
          return new OkObjectResult("Done");
        }

        [HttpPost("AddVisitTestsByVisitId/{id}", Name = "AddVisitTestsByVisitId")]
        [ValidateModelAttribute]
        public IActionResult AddVisitTestsByVisitId([FromRoute]long id, [FromBody]IEnumerable<VisitTest> models)
        {
            Visit vis = visit_repo.Find(id);
            if(vis == null)
            {
              return BadRequest("Invalid visit ID");
            }
            VisitTest_repo.DeleteRange(VisitTest_repo.GetAll().Where(a => a.VisitId == id));
            VisitTest_repo.AddRange(models);
            return Ok("Visit Tests Added");
        }

        [HttpPut("UpdateVisitTest", Name = "UpdateVisitTest")]
        [ValidateModelAttribute]
        public IActionResult UpdateVisitTest([FromBody]VisitTest model)
        {
          VisitTest_repo.Update(model);
          return new OkObjectResult(new { VisitTestId = model.VisitTestId });
        }


        [HttpDelete("DeleteVisit/{id}")]
        public IActionResult DeleteVisitTest(long id)
        {
          VisitTest note = VisitTest_repo.Find(id);
          if (note == null)
          {
            return NotFound();
          }

          VisitTest_repo.Delete(note);
          return Ok();
        }
        #endregion

        #region VisitDiagnosis
        [HttpGet("GetVisitDiagnosiss", Name = "GetVisitDiagnosiss")]
        public IEnumerable<VisitDiagnosis> GetVisitDiagnosiss()
        {
            return VisitDiagnosis_repo.GetAll().OrderByDescending(a => a.VisitDiagnosisId);
        }

        [HttpGet("GetVisitDiagnosis/{id}", Name = "GetVisitDiagnosis")]
        public VisitDiagnosis GetVisitDiagnosis(long id)
        {
          return VisitDiagnosis_repo.GetFirst(a => a.VisitDiagnosisId == id);
        }

        [HttpGet("GetVisitDiagnosisByVisitId/{id}", Name = "GetVisitDiagnosisByVisitId")]
        public IEnumerable<VisitDiagnosis> GetVisitDiagnosisByVisitId(long id)
        {
            return VisitDiagnosis_repo.GetAll().Where(a => a.VisitId == id);
        }

        //[HttpPost("AddVisitDiagnosis", Name = "AddVisitDiagnosis")]
        //[ValidateModelAttribute]
        //public IActionResult AddVisitDiagnosis([FromBody]VisitDiagnosis model)
        //{
        //  VisitDiagnosis_repo.Add(model);
        //  return new OkObjectResult("Done");
        //}

        [HttpPost("AddVisitDiagnoses", Name = "AddVisitDiagnoses")]
        [ValidateModelAttribute]
        public IActionResult AddVisitDiagnoses([FromBody]IEnumerable<VisitDiagnosis> model)
        {
            try
            {
                VisitDiagnosis_repo.AddRange(model);
                return new OkObjectResult("Done");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("AddVisitDiagnosesByVisitId/{id}", Name = "AddVisitDiagnosesByVisitId")]
        [ValidateModelAttribute]
        public IActionResult AddVisitDiagnosesByVisitId([FromRoute]long id, [FromBody]IEnumerable<VisitDiagnosis> model)
        {
            Visit vis = visit_repo.Find(id);
            if(vis == null)
            {
                return BadRequest("Invalid visit Id");
            }

            VisitDiagnosis_repo.DeleteRange(VisitDiagnosis_repo.GetAll().Where(a => a.VisitId == id));
            VisitDiagnosis_repo.AddRange(model);
            return Ok("Diagnoses Added");
        }

        [HttpPut("UpdateVisitDiagnosis", Name = "UpdateVisitDiagnosis")]
        [ValidateModelAttribute]
        public IActionResult UpdateVisitDiagnosis([FromBody]VisitDiagnosis model)
        {
          VisitDiagnosis_repo.Update(model);
          return new OkObjectResult(new { VisitDiagnosisId = model.VisitDiagnosisId });
        }


        [HttpDelete("DeleteVisitDiagnosis/{id}")]
        public IActionResult DeleteVisitDiagnosis(long id)
        {
          VisitDiagnosis note = VisitDiagnosis_repo.Find(id);
          if (note == null)
          {
            return NotFound();
          }
          VisitDiagnosis_repo.Delete(note);
          return Ok();
        }
        #endregion

        #region Get Appointment By VisitId

        [HttpGet("GetAppointmentByVisitId/{id}", Name = "GetAppointmentByVisitId")]
        public Appointment GetAppointmentByVisitId(long id)
        {
            return Appointment_repo.GetFirst(a => a.VisitId == id);
        }


        #endregion
    }
}
