using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities.HR.Attendance;
using ErpCore.Entities.HR.Attendance.AttendanceAdmin;
using ErpCore.Filters;
using Microsoft.AspNetCore.Mvc;
using SystemAdministrationService.Repos.Hr.AttendanceRepos.Interfaces;

namespace SystemAdministrationService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AttendanceController : Controller
    {
        private IAttendanceRequestRepository AttendanceRequest_repo;
        private IEmployeeOverTimeEntitlementRepository EmployeeOverTimeEntitlement_repo;
        private IOfficialVisitEntryRepository OfficialVisitEntry_repo;
        private IOverTimeEntitlementRepository OverTimeEntitlement_repo;
        private IUserRosterAttendanceRepository UserRosterAttendance_repo;
        private IAttendanceFlagExemptionRepository AttendanceFlagExemption_repo;
        private IAttendanceRuleRepository AttendanceRule_repo;


        public AttendanceController(

      IAttendanceRequestRepository repo1,
      IOfficialVisitEntryRepository repo2,
      IOverTimeEntitlementRepository repo3,
      IEmployeeOverTimeEntitlementRepository repo4,
      IUserRosterAttendanceRepository repo5, 
      IAttendanceFlagExemptionRepository repo6,
      IAttendanceRuleRepository repo7

      )
        {
            AttendanceRequest_repo = repo1;
            OfficialVisitEntry_repo = repo2;
            OverTimeEntitlement_repo = repo3;
            EmployeeOverTimeEntitlement_repo = repo4;
            UserRosterAttendance_repo = repo5;
            AttendanceFlagExemption_repo = repo6;
            AttendanceRule_repo = repo7;

        }

        #region Attendance Request
        [HttpGet("GetAttendanceRequests", Name = "GetAttendanceRequests")]
        public IEnumerable<AttendanceRequest> GetAttendanceRequests()
        {
            return AttendanceRequest_repo.GetAll().OrderByDescending(a => a.AttendanceRequestId);
        }

        [HttpGet("GetAttendanceRequest/{id}", Name = "GetAttendanceRequest")]
        public AttendanceRequest GetAttendanceRequest(long id) => AttendanceRequest_repo.GetFirst(a => a.AttendanceRequestId == id);

        [HttpPost("AddAttendanceRequest", Name = "AddAttendanceRequest")]
        [ValidateModelAttribute]
        public IActionResult AddAttendanceRequest([FromBody]AttendanceRequest model)
        {
            AttendanceRequest_repo.Add(model);
            return new OkObjectResult(new { AttendanceRequestID = model.AttendanceRequestId });
        }

        [HttpPut("UpdateAttendanceRequest", Name = "UpdateAttendanceRequest")]
        [ValidateModelAttribute]
        public IActionResult UpdateAttendanceRequest([FromBody]AttendanceRequest model)
        {
            AttendanceRequest_repo.Update(model);
            return new OkObjectResult(new { AttendanceRequestID = model.AttendanceRequestId });
        }

        [HttpDelete("DeleteAttendanceRequest/{id}")]
        public IActionResult DeleteAttendanceRequest(long id)
        {
            AttendanceRequest a = AttendanceRequest_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            AttendanceRequest_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Official Visit Entry
        [HttpGet("GetOfficialVisitEntries", Name = "GetOfficialVisitEntries")]
        public IEnumerable<OfficialVisitEntry> GetOfficialVisitEntries()
        {
            return OfficialVisitEntry_repo.GetAll().OrderByDescending(a => a.OfficialVisitEntryId);
        }

        [HttpGet("GetOfficialVisitEntry/{id}", Name = "GetOfficialVisitEntry")]
        public OfficialVisitEntry GetOfficialVisitEntry(long id) => OfficialVisitEntry_repo.GetFirst(a => a.OfficialVisitEntryId == id);

        [HttpPost("AddOfficialVisitEntry", Name = "AddOfficialVisitEntry")]
        [ValidateModelAttribute]
        public IActionResult AddOfficialVisitEntry([FromBody]OfficialVisitEntry model)
        {
            OfficialVisitEntry_repo.Add(model);
            return new OkObjectResult(new { OfficialVisitEntryID = model.OfficialVisitEntryId });
        }

        [HttpPut("UpdateOfficialVisitEntry", Name = "UpdateOfficialVisitEntry")]
        [ValidateModelAttribute]
        public IActionResult UpdateOfficialVisitEntry([FromBody]OfficialVisitEntry model)
        {
            OfficialVisitEntry_repo.Update(model);
            return new OkObjectResult(new { OfficialVisitEntryID = model.OfficialVisitEntryId });
        }

        [HttpDelete("DeleteOfficialVisitEntry/{id}")]
        public IActionResult DeleteOfficialVisitEntry(long id)
        {
            OfficialVisitEntry a = OfficialVisitEntry_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            OfficialVisitEntry_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region OverTime Entitlement
        [HttpGet("GetOverTimeEntitlements", Name = "GetOverTimeEntitlements")]
        public IEnumerable<OverTimeEntitlement> GetOverTimeEntitlements()
        {
            return OverTimeEntitlement_repo.GetAll().OrderByDescending(a => a.OverTimeEntitlementId);
        }

        [HttpGet("GetOverTimeEntitlement/{id}", Name = "GetOverTimeEntitlement")]
        public OverTimeEntitlement GetOverTimeEntitlement(long id) => OverTimeEntitlement_repo.GetFirst(a => a.OverTimeEntitlementId == id);

        [HttpPost("AddOverTimeEntitlement", Name = "AddOverTimeEntitlement")]
        [ValidateModelAttribute]
        public IActionResult AddOverTimeEntitlement([FromBody]OverTimeEntitlement model)
        {
            OverTimeEntitlement_repo.Add(model);
            return new OkObjectResult(new { OverTimeEntitlementID = model.OverTimeEntitlementId });
        }

        [HttpPut("UpdateOverTimeEntitlement", Name = "UpdateOverTimeEntitlement")]
        [ValidateModelAttribute]
        public IActionResult UpdateOverTimeEntitlement([FromBody]OverTimeEntitlement model)
        {
            OverTimeEntitlement_repo.Update(model);
            return new OkObjectResult(new { OverTimeEntitlementID = model.OverTimeEntitlementId });
        }

        [HttpDelete("DeleteOverTimeEntitlement/{id}")]
        public IActionResult DeleteOverTimeEntitlement(long id)
        {
            OverTimeEntitlement a = OverTimeEntitlement_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            OverTimeEntitlement_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Employee OverTime Entitlment
        [HttpGet("GetEmployeeOverTimeEntitlments", Name = "GetEmployeeOverTimeEntitlments")]
        public IEnumerable<EmployeeOverTimeEntitlement> GetEmployeeOverTimeEntitlments()
        {
            return EmployeeOverTimeEntitlement_repo.GetAll().OrderByDescending(a => a.EmployeeOverTimeEntitlementId);
        }

        [HttpGet("GetEmployeeOverTimeEntitlment/{id}", Name = "GetEmployeeOverTimeEntitlment")]
        public EmployeeOverTimeEntitlement GetEmployeeOverTimeEntitlment(long id) => EmployeeOverTimeEntitlement_repo.GetFirst(a => a.EmployeeOverTimeEntitlementId == id);

        [HttpPost("AddEmployeeOverTimeEntitlment", Name = "AddEmployeeOverTimeEntitlment")]
        [ValidateModelAttribute]
        public IActionResult AddEmployeeOverTimeEntitlment([FromBody]EmployeeOverTimeEntitlement model)
        {
            EmployeeOverTimeEntitlement_repo.Add(model);
            return new OkObjectResult(new { EmployeeOverTimeEntitlmentID = model.EmployeeOverTimeEntitlementId });
        }

        [HttpPut("UpdateEmployeeOverTimeEntitlment", Name = "UpdateEmployeeOverTimeEntitlment")]
        [ValidateModelAttribute]
        public IActionResult UpdateEmployeeOverTimeEntitlment([FromBody]EmployeeOverTimeEntitlement model)
        {
            EmployeeOverTimeEntitlement_repo.Update(model);
            return new OkObjectResult(new { EmployeeOverTimeEntitlmentID = model.EmployeeOverTimeEntitlementId });
        }

        [HttpDelete("DeleteEmployeeOverTimeEntitlment/{id}")]
        public IActionResult DeleteEmployeeOverTimeEntitlment(long id)
        {
            EmployeeOverTimeEntitlement a = EmployeeOverTimeEntitlement_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            EmployeeOverTimeEntitlement_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region User Roster Attendance
        [HttpGet("GetUserRosterAttendances", Name = "GetUserRosterAttendances")]
        public IEnumerable<UserRosterAttendance> GetUserRosterAttendances()
        {
            return UserRosterAttendance_repo.GetAll().OrderByDescending(a => a.UserRosterAttendanceId);
        }


        [HttpGet("GetUserAttendancesbydate/{fromdate}/{todate}", Name = "GetUserAttendancesbydate")]
        public IEnumerable<UserRosterAttendance> GetUserAttendancesbydate(DateTime fromdate ,DateTime todate)
        {
          //  return UserRosterAttendance_repo.GetAll().OrderByDescending(a => a.UserRosterAttendanceId);
          return UserRosterAttendance_repo.getUserAttendacesByDate(fromdate, todate);
        }

    [HttpGet("GetUserRosterAttendance/{id}", Name = "GetUserRosterAttendance")]
        public UserRosterAttendance GetUserRosterAttendance(long id) => UserRosterAttendance_repo.GetFirst(a => a.UserRosterAttendanceId == id);

        [HttpPost("AddUserRosterAttendance", Name = "AddUserRosterAttendance")]
        [ValidateModelAttribute]
        public IActionResult AddUserRosterAttendance([FromBody]UserRosterAttendance model)
        {
            UserRosterAttendance_repo.Add(model);
            return new OkObjectResult(new { UserRosterAttendanceID = model.UserRosterAttendanceId });
        }

        [HttpPut("UpdateUserRosterAttendance", Name = "UpdateUserRosterAttendance")]
        [ValidateModelAttribute]
        public IActionResult UpdateUserRosterAttendance([FromBody]UserRosterAttendance model)
        {
            UserRosterAttendance_repo.Update(model);
            return new OkObjectResult(new { UserRosterAttendanceID = model.UserRosterAttendanceId });
        }

        [HttpDelete("DeleteUserRosterAttendance/{id}")]
        public IActionResult DeleteUserRosterAttendance(long id)
        {
            UserRosterAttendance a = UserRosterAttendance_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            UserRosterAttendance_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Attendance Flag Exemption
        [HttpGet("GetAttendanceFlagExemptions", Name = "GetAttendanceFlagExemptions")]
        public IEnumerable<AttendanceFlagExemption> GetAttendanceFlagExemptions()
        {
            return AttendanceFlagExemption_repo.GetAll().OrderByDescending(a => a.AttendanceFlagExemptionId);
        }

        [HttpGet("GetAttendanceFlagExemption/{id}", Name = "GetAttendanceFlagExemption")]
        public AttendanceFlagExemption GetAttendanceFlagExemption(long id) => AttendanceFlagExemption_repo.GetFirst(a => a.AttendanceFlagExemptionId == id);

        [HttpPost("AddAttendanceFlagExemption", Name = "AddAttendanceFlagExemption")]
        [ValidateModelAttribute]
        public IActionResult AddAttendanceFlagExemption([FromBody]AttendanceFlagExemption model)
        {
            AttendanceFlagExemption_repo.Add(model);
            return new OkObjectResult(new { AttendanceFlagExemptionID = model.AttendanceFlagExemptionId });
        }

        [HttpPut("UpdateAttendanceFlagExemption", Name = "UpdateAttendanceFlagExemption")]
        [ValidateModelAttribute]
        public IActionResult UpdateAttendanceFlagExemption([FromBody]AttendanceFlagExemption model)
        {
            AttendanceFlagExemption_repo.Update(model);
            return new OkObjectResult(new { AttendanceFlagExemptionID = model.AttendanceFlagExemptionId });
        }

        [HttpDelete("DeleteAttendanceFlagExemption/{id}")]
        public IActionResult DeleteAttendanceFlagExemption(long id)
        {
            AttendanceFlagExemption a = AttendanceFlagExemption_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            AttendanceFlagExemption_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Attendance Rule
        [HttpGet("GetAttendanceRules", Name = "GetAttendanceRules")]
        public IEnumerable<AttendanceRule> GetAttendanceRules()
        {
            return AttendanceRule_repo.GetAll(a => a.AttendanceRuleLeaveTypes).OrderByDescending(a => a.AttendanceRuleId);
        }

        [HttpGet("GetAttendanceRule/{id}", Name = "GetAttendanceRule")]
        public AttendanceRule GetAttendanceRule(long id) => AttendanceRule_repo.GetFirst(a => a.AttendanceRuleId == id, b=>b.AttendanceRuleLeaveTypes);

        [HttpPost("AddAttendanceRule", Name = "AddAttendanceRule")]
        [ValidateModelAttribute]
        public IActionResult AddAttendanceRule([FromBody]AttendanceRule model)
        {
            AttendanceRule_repo.Add(model);
            return new OkObjectResult(new { AttendanceRuleID = model.AttendanceRuleId });
        }

        [HttpPut("UpdateAttendanceRule", Name = "UpdateAttendanceRule")]
        [ValidateModelAttribute]
        public IActionResult UpdateAttendanceRule([FromBody]AttendanceRule model)
        {
            AttendanceRule_repo.Update(model);
            return new OkObjectResult(new { AttendanceRuleID = model.AttendanceRuleId });
        }

        [HttpDelete("DeleteAttendanceRule/{id}")]
        public IActionResult DeleteAttendanceRule(long id)
        {
            AttendanceRule a = AttendanceRule_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            AttendanceRule_repo.Delete(a);
            return Ok();
        }

        #endregion

    }
}
