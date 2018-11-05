using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities.HR;
using ErpCore.Entities.HR.Attendance;
using ErpCore.Entities.HR.Payroll;
using ErpCore.Entities.HR.Payroll.PayrollAdmin;
using ErpCore.Filters;
using Microsoft.AspNetCore.Mvc;
using SystemAdministrationService.Repos.Hr.AttendanceRepos.Interfaces;
using SystemAdministrationService.Repos.Hr.PayrollRepos.Interfaces;

namespace SystemAdministrationService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PayrollController : Controller
    {
        private IGratuityRepository Gratuity_repo;
        private IGratuitySlabGratuityRepository GratuitySlabGratuity_repo;
        private IMonthlyUserSalaryRepository MonthlyUserSalary_repo;
        private IStopSalaryRepository StopSalary_repo;
        private IPaySlipRepository PaySlip_repo;
        private ITaxAdjustmentRepository TaxAdjustment_repo;
        private IUserRosterAttendanceRepository UserRosterAttendance_repo;

        public PayrollController(

          IGratuityRepository repo1,
          IMonthlyUserSalaryRepository repo2,
          IStopSalaryRepository repo3,
          IPaySlipRepository repo4,
          ITaxAdjustmentRepository repo5,
          IUserRosterAttendanceRepository repo6,
          IGratuitySlabGratuityRepository repo7
      )
        {
            Gratuity_repo = repo1;
            MonthlyUserSalary_repo = repo2;
            StopSalary_repo = repo3;
            PaySlip_repo = repo4;
            TaxAdjustment_repo = repo5;
            UserRosterAttendance_repo = repo6;
            GratuitySlabGratuity_repo = repo7;
        }

        #region Gratuity

        [HttpGet("GetGratuities", Name = "GetGratuities")]
        public IEnumerable<Gratuity> GetGratuities()
        {
            return Gratuity_repo.GetAll(s => s.GratuitySlabGratuities).OrderByDescending(a => a.UserGratuityId);
        }

        [HttpGet("GetGratuity/{id}", Name = "GetGratuity")]
        public Gratuity GetGratuity(long id) => Gratuity_repo.GetFirst(a => a.UserGratuityId == id, b => b.GratuitySlabGratuities);

        [HttpPost("AddGratuity", Name = "AddGratuity")]
        [ValidateModelAttribute]
        public IActionResult AddGratuity([FromBody]Gratuity model)
        {
            Gratuity_repo.Add(model);
            return new OkObjectResult(new { GratuityID = model.UserGratuityId });
        }

        [HttpPut("UpdateGratuity", Name = "UpdateGratuity")]
        [ValidateModelAttribute]
        public IActionResult UpdateGratuity([FromBody]Gratuity model)
        {
            try
            {
                GratuitySlabGratuity_repo.DeleteRange(GratuitySlabGratuity_repo.GetAll().Where(a => a.GratuityId == model.UserGratuityId));
                Gratuity_repo.Update(model);
            return new OkObjectResult(new { GratuityID = model.UserGratuityId });
                }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("DeleteGratuity/{id}")]
        public IActionResult DeleteGratuity(long id)
        {
            Gratuity a = Gratuity_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Gratuity_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region MonthlyUserSalary

        [HttpGet("GetMonthlyUserSalaries", Name = "GetMonthlyUserSalaries")]
        public IEnumerable<MonthlyUserSalary> GetMonthlyUserSalaries()
        {
            return MonthlyUserSalary_repo.GetAll(r => r.UserRosterAttendances).OrderByDescending(a=>a.MonthlyUserSalaryId);
        }

        [HttpGet("GetMonthlyUserSalary/{id}", Name = "GetMonthlyUserSalary")]
        public MonthlyUserSalary GetMonthlyUserSalary(long id) => MonthlyUserSalary_repo.GetFirst(a => a.MonthlyUserSalaryId == id,b => b.UserRosterAttendances);

        [HttpPost("AddMonthlyUserSalary", Name = "AddMonthlyUserSalary")]
        [ValidateModelAttribute]
        public IActionResult AddMonthlyUserSalary([FromBody]MonthlyUserSalary model)
        {
            MonthlyUserSalary_repo.Add(model);
            return new OkObjectResult(new { MonthlyUserSalaryID = model.MonthlyUserSalaryId });
        }

        [HttpPut("UpdateMonthlyUserSalary", Name = "UpdateMonthlyUserSalary")]
        [ValidateModelAttribute]
        public IActionResult UpdateMonthlyUserSalary([FromBody]MonthlyUserSalary model)
        {
            try
            {
                UserRosterAttendance_repo.DeleteRange(UserRosterAttendance_repo.GetAll().Where(a => a.MonthlyUserSalaryId == model.MonthlyUserSalaryId));
                MonthlyUserSalary_repo.Update(model);
            return new OkObjectResult(new { MonthlyUserSalaryID = model.MonthlyUserSalaryId });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("DeleteMonthlyUserSalary/{id}")]
        public IActionResult DeleteMonthlyUserSalary(long id)
        {
            MonthlyUserSalary a = MonthlyUserSalary_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            MonthlyUserSalary_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region StopSalary

        [HttpGet("GetStopSalaries", Name = "GetStopSalaries")]
        public IEnumerable<StopSalary> GetStopSalaries()
        {
            return StopSalary_repo.GetAll().OrderByDescending(a=>a.StopSalaryId);
        }

        [HttpGet("GetStopSalary/{id}", Name = "GetStopSalary")]
        public StopSalary GetStopSalary(long id) => StopSalary_repo.GetFirst(a => a.StopSalaryId == id);

        [HttpPost("AddStopSalary", Name = "AddStopSalary")]
        [ValidateModelAttribute]
        public IActionResult AddStopSalary([FromBody]StopSalary model)
        {
            StopSalary_repo.Add(model);
            return new OkObjectResult(new { StopSalaryID = model.StopSalaryId });
        }

        [HttpPut("UpdateStopSalary", Name = "UpdateStopSalary")]
        [ValidateModelAttribute]
        public IActionResult UpdateStopSalary([FromBody]StopSalary model)
        {
            StopSalary_repo.Update(model);
            return new OkObjectResult(new { StopSalaryID = model.StopSalaryId });
        }

        [HttpDelete("DeleteStopSalary/{id}")]
        public IActionResult DeleteStopSalary(long id)
        {
            StopSalary a = StopSalary_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            StopSalary_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region PaySlip

        [HttpGet("GetPaySlips", Name = "GetPaySlips")]
        public IEnumerable<PaySlip> GetPaySlips()
        {
            return PaySlip_repo.GetAll(a => a.UserLoanPayslips).OrderByDescending(a=>a.PaySlipid);
        }

        [HttpGet("GetPaySlip/{id}", Name = "GetPaySlip")]
        public PaySlip GetPaySlip(long id) => PaySlip_repo.GetFirst(a => a.PaySlipid == id, b => b.UserLoanPayslips);

        [HttpPost("AddPaySlip", Name = "AddPaySlip")]
        [ValidateModelAttribute]
        public IActionResult AddPaySlip([FromBody]PaySlip model)
        {
            PaySlip_repo.Add(model);
            return new OkObjectResult(new { PaySlipid = model.PaySlipid });
        }

        [HttpPut("UpdatePaySlip", Name = "UpdatePaySlip")]
        [ValidateModelAttribute]
        public IActionResult UpdatePaySlip([FromBody]PaySlip model)
        {
            PaySlip_repo.Update(model);
            return new OkObjectResult(new { PaySlipID = model.PaySlipid });
        }

        [HttpDelete("DeletePaySlip/{id}")]
        public IActionResult DeletePaySlip(long id)
        {
            PaySlip a = PaySlip_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            PaySlip_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region TaxAdjustment

        [HttpGet("GetTaxAdjustments", Name = "GetTaxAdjustments")]
        public IEnumerable<TaxAdjustment> GetTaxAdjustments()
        {
            return TaxAdjustment_repo.GetAll().OrderByDescending(a=>a.TaxAdjustmentId);
        }

        [HttpGet("GetTaxAdjustment/{id}", Name = "GetTaxAdjustment")]
        public TaxAdjustment GetTaxAdjustment(long id) => TaxAdjustment_repo.GetFirst(a => a.TaxAdjustmentId == id);

        [HttpPost("AddTaxAdjustment", Name = "AddTaxAdjustment")]
        [ValidateModelAttribute]
        public IActionResult AddTaxAdjustment([FromBody]TaxAdjustment model)
        {
            TaxAdjustment_repo.Add(model);
            return new OkObjectResult(new { TaxAdjustmentID = model.TaxAdjustmentId });
        }

        [HttpPut("UpdateTaxAdjustment", Name = "UpdateTaxAdjustment")]
        [ValidateModelAttribute]
        public IActionResult UpdateTaxAdjustment([FromBody]TaxAdjustment model)
        {
            TaxAdjustment_repo.Update(model);
            return new OkObjectResult(new { TaxAdjustmentID = model.TaxAdjustmentId });
        }

        [HttpDelete("DeleteTaxAdjustment/{id}")]
        public IActionResult DeleteTaxAdjustment(long id)
        {
            TaxAdjustment a = TaxAdjustment_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            TaxAdjustment_repo.Delete(a);
            return Ok();
        }
        #endregion
    }
}