using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErpCore.Entities;
using HimsService.Repos.Interfaces;
using ErpCore.Filters;
using ErpCore.Entities.HimsSetup;
using HimsService.Repos;

namespace HimsService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AppointmentsController : Controller
    {
        private IAppointmentRepository _repo;

        public AppointmentsController(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAppointments", Name = "GetAppointments")]
        public IEnumerable<Appointment> GetAppointments()
        {
            try
            {
                IEnumerable<Appointment> ap = _repo.GetAll(b => b.AppointmentTests);
                ap = ap.OrderByDescending(a => a.AppointmentId);
                return ap;
            }
            catch (Exception e)
            {

                throw;
            }

        }

        [HttpGet("GetAppointmentByVisit/{visitId}")]
        public Appointment GetAppointmentByVisit(long visitId)
        {
            return _repo.GetFirst(r => r.VisitId == visitId);
        }

        [HttpGet("GetAppointment/{id}", Name = "GetAppointment")]
        public Appointment GetAppointment(long id) => _repo.GetFirst(a => a.AppointmentId == id, b => b.AppointmentTests, c => c.Patient, d => d.Consultant, e => e.PatientInvoice, f => f.VisitNature);

        [HttpGet("GetAppointmentTestByAppointmentId/{id}", Name = "GetAppointmentTestByAppointmentId")]
        public Appointment GetAppointmentTestByAppointmentId(long id) => _repo.GetFirst(a => a.AppointmentId == id, b => b.AppointmentTests);



    [HttpGet("GetAppointmentForInvoiceUpdate/{id}", Name = "GetAppointmentForInvoiceUpdate")]
        public Appointment GetAppointmentForInvoiceUpdate(long id) => _repo.GetFirst(a => a.AppointmentId == id);

        [HttpGet("GetAppointmentDetails/{id}", Name = "GetAppointmentDetails")]
        public Appointment GetAppointmentDetails(long id)
        {
            return _repo.GetAppointmentDetails(id);
        }


        [HttpPut("UpdateAppointment", Name = "UpdateAppointment")]
        [ValidateModelAttribute]
        public IActionResult UpdateAppointment([FromBody]Appointment model)
        {
            if(model.FinalTime != null)
            {
                model.AppointmentDay = model.FinalTime.Value.Date.ToString();
            }
            else
            {
                model.AppointmentDay = model.TentativeTime.Value.DayOfWeek.ToString();
            }
            _repo.Update(model);
            return new OkObjectResult(new { AppointmentID = model.AppointmentId });
        }

        [HttpPost("AddAppointment", Name = "AddAppointment")]
        [ValidateModelAttribute]
        public IActionResult AddAppointment([FromBody] Appointment model)
        {
            model.AppointmentDay = model.TentativeTime.Value.DayOfWeek.ToString();
            _repo.Add(model);
            return new OkObjectResult(new { AppointmentID = model.AppointmentId });
        }

        [HttpPost("AddAppointmentByVisitId", Name = "AddAppointmentByVisitId")]
        [ValidateModelAttribute]
        public IActionResult AddAppointmentByVisitId([FromBody]Appointment model)
        {
            try
            {
                Appointment App = _repo.GetFirst(a => a.VisitId == model.VisitId);
                if (App != null)
                {
                    _repo.Delete(App);
                }
                _repo.Add(model);
                return Ok(model.AppointmentId);
            }
            catch (NullReferenceException e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("DeleteAppointment/{id}")]
        public IActionResult DeleteAppointment(long id)
        {
            Appointment appointment = _repo.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _repo.Delete(appointment);
            return Ok();
        }

        [HttpGet("GetAppointmentByConsultantNameAndDate/{id}/{date}", Name = "GetAppointmentByConsultantNameAndDate")]
        [ValidateModelAttribute]
        public IEnumerable<Appointment> GetAppointmentByConsultantNameAndDate(long id, DateTime date)
        {
            return _repo.GetConsultantAndAppointmentdate(id , date);
        }

        [HttpGet("GetAppointmentByDate/{date}", Name = "GetAppointmentByDate")]
        [ValidateModelAttribute]
        public IEnumerable<Appointment> GetAppointmentByDate(DateTime date)
        {
        //  return _repo.GetAll().Where(a => a.AppointmentDate.Value.Date.ToString() == dat)
        return _repo.GetDataByTentativedate(date);
        }

        [HttpGet("GetAppointmentsByDate/{date}", Name = "GetAppointmentsByDate")]
        [ValidateModelAttribute]
        public IList<Appointment> GetAppointmentsByDate(DateTime date)
        {
          return _repo.GetAll().Where(a => a.AppointmentDate != null && a.TentativeTime != null && a.TentativeTime.Value.Date == date.Date).ToList();
        }

        [HttpPost("UpdateAppointmentTests/{appointmentid}", Name = "UpdateAppointmentTests")]
        [ValidateModelAttribute]
        public IActionResult UpdateAppointmentTests([FromRoute]long appointmentid, [FromBody]IEnumerable<AppointmentTest> model)
        {
              Appointment app = _repo.Find(appointmentid);
              app.AppointmentTests = model;
              _repo.Update(app);
              return new OkObjectResult(new { AppointmentId = appointmentid });
        }

        #region Get By Company, Country, City or Branch

        [HttpGet("GetAppointmentsByCompany/{id}", Name = "GetAppointmentsByCompany")]
        public IEnumerable<Appointment> GetAppointmentsByCompany(long id)
        {
            return _repo.GetList(a => a.CompanyId == id);
        }

        [HttpGet("GetAppointmentsByCountry/{id}", Name = "GetAppointmentsByCountry")]
        public IEnumerable<Appointment> GetAppointmentsByCountry(long id)
        {
            return _repo.GetList(a => a.CountryId == id);
        }

        [HttpGet("GetAppointmentsByCity/{id}", Name = "GetAppointmentsByCity")]
        public IEnumerable<Appointment> GetAppointmentsByCity(long id)
        {
            return _repo.GetList(a => a.CityId == id);
        }

        [HttpGet("GetAppointmentsByBranch/{id}", Name = "GetAppointmentsByBranch")]
        public IEnumerable<Appointment> GetAppointmentsByBranch(long id)
        {
            return _repo.GetList(a => a.BranchId == id);
        }
        #endregion


        [HttpGet("GetAppointmentsByDateAndPatientID/{date}/{patId}", Name = "GetAppointmentsByDateAndPatientID")]
        public IActionResult GetAppointmentsByDateAndPatientID([FromRoute]DateTime date, [FromRoute]long patId)
        {
            try
            {
                return new OkObjectResult(_repo.GetAppointmentsByDateAndPatientID(date, patId));
            }
            catch(NullReferenceException)
            {
                return BadRequest("Invalid Query");
            }
            catch(InvalidOperationException)
            {
                return BadRequest("Appointment hasn't finished yet");
            }
        }

        [HttpGet("GetFinalizedAppointmentsByDateAndMRN/{date}/{mrn}", Name = "GetFinalizedAppointmentsByDateAndMRN")]
        public IActionResult GetFinalizedAppointmentsByDateAndMRN([FromRoute]DateTime date, [FromRoute]string mrn)
        {
            try
            {
                return new OkObjectResult(_repo.GetFinalizedAppointmentsByDateAndMRN(date, mrn.ToUpper()));
            }
            catch (NullReferenceException)
            {
                return BadRequest("Invalid Query");
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Appointment hasn't finished yet");
            }
        }

        [HttpGet("GetFinalizedAppointmentsByMRN/{mrn}", Name = "GetFinalizedAppointmentsByMRN")]
        public IActionResult GetFinalizedAppointmentsByMRN([FromRoute]string mrn)
        {
            try
            {
                return new OkObjectResult(_repo.GetFinalizedAppointmentsByMRN(mrn.ToUpper()));
            }
            catch (NullReferenceException)
            {
                return BadRequest("No Finalized Appointments");
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Invalid MRN");
            }
        }


    }
}
