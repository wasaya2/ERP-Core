using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities.HR.Attendance.AttendanceSetup;
using ErpCore.Entities.HR.Attendance.OvertimeSetup;
using ErpCore.Filters;
using Microsoft.AspNetCore.Mvc;
using SystemAdministrationService.Repos.Hr.AttendanceRepos.Interfaces;

namespace SystemAdministrationService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AttendanceSetupController : Controller
    {
        private IAssignRosterRepository AssignRoster_repo;
        private IAttendanceFlagRepository AttendanceFlag_repo;
        private IAttendanceRequestApproverRepository AttendanceRequestApprover_repo;
        private IAttendanceRequestTypeRepository AttendanceRequestType_repo;
        private IFlagCategoryRepository FlagCategory_repo;
        private IFlagEffectTypeRepository FlagEffectType_repo;
        private IFlagValueRepository FlagValue_repo;
        private IFlagTypeRepository FlagType_repo;
        private IRosterRepository Roster_repo;
        private IShiftRepository Shift_repo;
        private IOverTimeFlagRepository OverTimeFlag_repo;
        private IOverTimeTypeRepository OverTimeType_repo;
        private IEmployeeWorkingDayOtRepository EmployeeWorkingDayOt_repo;
        private IEmployeeOffDayOtRepository EmployeeOffDayOt_repo;
        private IEmployeeIncomingOtRepository EmployeeIncomingOt_repo;
        private IEmployeeOutgoingOtRepository EmployeeOutgoingOt_repo;
        private IShiftAttendanceFlagRepository ShiftAttendanceFlag_repo;
        private IUserAssignRosterRepository UserAssignRoster_repo;

        public AttendanceSetupController(

      IAssignRosterRepository repo1,
      IAttendanceFlagRepository repo3,
      IAttendanceRequestApproverRepository repo4,
      IAttendanceRequestTypeRepository repo5,
      IFlagCategoryRepository repo6,
      IFlagEffectTypeRepository repo7,
      IFlagTypeRepository repo8,
      IFlagValueRepository repo9,
      IRosterRepository repo10,
      IShiftRepository repo11,
      IOverTimeFlagRepository repo12,
      IOverTimeTypeRepository repo13,
      IEmployeeWorkingDayOtRepository repo14,
      IEmployeeOffDayOtRepository repo15,
      IEmployeeIncomingOtRepository repo16,
      IEmployeeOutgoingOtRepository repo17,
      IShiftAttendanceFlagRepository repo18,
      IUserAssignRosterRepository repo19

      )
        {
            AssignRoster_repo = repo1;
            //AssignRosterShift_repo = repo2;
            AttendanceFlag_repo = repo3;
            AttendanceRequestApprover_repo = repo4;
            AttendanceRequestType_repo = repo5;
            FlagCategory_repo = repo6;
            FlagEffectType_repo = repo7;
            FlagType_repo = repo8;
            FlagValue_repo = repo9;
            Roster_repo = repo10;
            Shift_repo = repo11;

            OverTimeFlag_repo = repo12;
            OverTimeType_repo = repo13;
            EmployeeWorkingDayOt_repo = repo14;
            EmployeeOffDayOt_repo = repo15;
            EmployeeIncomingOt_repo = repo16;
            EmployeeOutgoingOt_repo = repo17;
            ShiftAttendanceFlag_repo = repo18;
            UserAssignRoster_repo = repo19;

        }


        #region Assign Roster
        [HttpGet("GetAssignRosters", Name = "GetAssignRosters")]
        public IEnumerable<AssignRoster> GetAssignRosters()
        {
            return AssignRoster_repo.GetAll(r => r.UserAssignRosters, x => x.Daysoffs).OrderByDescending(a => a.AssignRosterId);
        }
        
        [HttpGet("GetAssignedRostersByUser/{userid}", Name = "GetAssignedRostersByUser")]
        public IEnumerable<UserAssignRoster> GetAssignedRostersByUser([FromRoute]long userid, DateTime fromdate, DateTime todate)
        {
            //return UserAssignRoster_repo.GetList(a => a.UserId == userid, b => b.AssignRoster).OrderByDescending(a => a.AssignRosterId);
            return UserAssignRoster_repo.GetAssignedRostersByUser(userid, fromdate, todate);
        }

        [HttpGet("GetAssignRoster/{id}", Name = "GetAssignRoster")]
        public AssignRoster GetAssignRoster(long id) => AssignRoster_repo.GetFirst(a => a.AssignRosterId == id, b => b.UserAssignRosters , x => x.Daysoffs);

        [HttpPost("AddAssignRoster", Name = "AddAssignRoster")]
        [ValidateModelAttribute]
        public IActionResult AddAssignRoster([FromBody]AssignRoster model)
        {
            model.Year = model.FromDate.Value.Year.ToString() + '-' + model.ToDate.Value.Year.ToString();
            model.Month = model.FromDate.Value.Month.ToString() + ", " + model.FromDate.Value.Year.ToString() + " - " + model.ToDate.Value.Month.ToString() + ", " + model.ToDate.Value.Year.ToString();
            AssignRoster_repo.Add(model);
            return new OkObjectResult(new { AssignRosterID = model.AssignRosterId });
        }

        [HttpPut("UpdateAssignRoster", Name = "UpdateAssignRoster")]
        [ValidateModelAttribute]
        public IActionResult UpdateAssignRoster([FromBody]AssignRoster model)
        {
            model.Year = model.FromDate.Value.Year.ToString() + " - " + model.ToDate.Value.Year.ToString();
            model.Month = model.FromDate.Value.Month.ToString() + ", " + model.FromDate.Value.Year.ToString() + " - " + model.ToDate.Value.Month.ToString() + ", " + model.ToDate.Value.Year.ToString();
            UserAssignRoster_repo.DeleteRange(UserAssignRoster_repo.GetList(a => a.AssignRosterId == model.AssignRosterId));
            AssignRoster_repo.Update(model);
            return new OkObjectResult(new { AssignRosterID = model.AssignRosterId });
        }

        [HttpDelete("DeleteAssignRoster/{id}")]
        public IActionResult DeleteAssignRoster(long id)
        {
            AssignRoster a = AssignRoster_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            AssignRoster_repo.Delete(a);
            return Ok();
        }

        #endregion
        
        #region Attendance Flag
        [HttpGet("GetAttendanceFlags", Name = "GetAttendanceFlags")]
        public IEnumerable<AttendanceFlag> GetAttendanceFlags()
        { 
            return AttendanceFlag_repo.GetAll().OrderByDescending(a => a.AttendanceFlagId);
        }

        [HttpGet("GetAttendanceFlag/{id}", Name = "GetAttendanceFlag")]
        public AttendanceFlag GetAttendanceFlag(long id) => AttendanceFlag_repo.GetFirst(a => a.AttendanceFlagId == id);

        [HttpPost("AddAttendanceFlag", Name = "AddAttendanceFlag")]
        [ValidateModelAttribute]
        public IActionResult AddAttendanceFlag([FromBody]AttendanceFlag model)
        {
            AttendanceFlag_repo.Add(model);
            return new OkObjectResult(new { AttendanceFlagID = model.AttendanceFlagId });
        }

        [HttpPut("UpdateAttendanceFlag", Name = "UpdateAttendanceFlag")]
        [ValidateModelAttribute]
        public IActionResult UpdateAttendanceFlag([FromBody]AttendanceFlag model)
        {
            AttendanceFlag_repo.Update(model);
            return new OkObjectResult(new { AttendanceFlagID = model.AttendanceFlagId });
        }

        [HttpDelete("DeleteAttendanceFlag/{id}")]
        public IActionResult DeleteAttendanceFlag(long id)
        {
            AttendanceFlag a = AttendanceFlag_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            AttendanceFlag_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Attendance Request Approver
        [HttpGet("GetAttendanceRequestApprovers", Name = "GetAttendanceRequestApprovers")]
        public IEnumerable<AttendanceRequestApprover> GetAttendanceRequestApprovers()
        {
            IEnumerable<AttendanceRequestApprover> ra = AttendanceRequestApprover_repo.GetAll();
            ra = ra.OrderByDescending(a => a.AttendanceRequestApproverId);
            return ra;
        }

        [HttpGet("GetAttendanceRequestApprover/{id}", Name = "GetAttendanceRequestApprover")]
        public AttendanceRequestApprover GetAttendanceRequestApprover(long id) => AttendanceRequestApprover_repo.GetFirst(a => a.AttendanceRequestApproverId == id);

        [HttpPost("AddAttendanceRequestApprover", Name = "AddAttendanceRequestApprover")]
        [ValidateModelAttribute]
        public IActionResult AddAttendanceRequestApprover([FromBody]AttendanceRequestApprover model)
        {
            AttendanceRequestApprover_repo.Add(model);
            return new OkObjectResult(new { AttendanceRequestApproverID = model.AttendanceRequestApproverId });
        }

        [HttpPut("UpdateAttendanceRequestApprover", Name = "UpdateAttendanceRequestApprover")]
        [ValidateModelAttribute]
        public IActionResult UpdateAttendanceRequestApprover([FromBody]AttendanceRequestApprover model)
        {
            AttendanceRequestApprover_repo.Update(model);
            return new OkObjectResult(new { AttendanceRequestApproverID = model.AttendanceRequestApproverId });
        }

        [HttpDelete("DeleteAttendanceRequestApprover/{id}")]
        public IActionResult DeleteAttendanceRequestApprover(long id)
        {
            AttendanceRequestApprover a = AttendanceRequestApprover_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            AttendanceRequestApprover_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Attendance Request Type
        [HttpGet("GetAttendanceRequestTypes", Name = "GetAttendanceRequestTypes")]
        public IEnumerable<AttendanceRequestType> GetAttendanceRequestTypes()
        {
            return AttendanceRequestType_repo.GetAll().OrderByDescending(a => a.AttendanceRequestTypeId);
        }

        [HttpGet("GetAttendanceRequestType/{id}", Name = "GetAttendanceRequestType")]
        public AttendanceRequestType GetAttendanceRequestType(long id) => AttendanceRequestType_repo.GetFirst(a => a.AttendanceRequestTypeId == id);

        [HttpPost("AddAttendanceRequestType", Name = "AddAttendanceRequestType")]
        [ValidateModelAttribute]
        public IActionResult AddAttendanceRequestType([FromBody]AttendanceRequestType model)
        {
            AttendanceRequestType_repo.Add(model);
            return new OkObjectResult(new { AttendanceRequestTypeID = model.AttendanceRequestTypeId });
        }

        [HttpPut("UpdateAttendanceRequestType", Name = "UpdateAttendanceRequestType")]
        [ValidateModelAttribute]
        public IActionResult UpdateAttendanceRequestType([FromBody]AttendanceRequestType model)
        {
            AttendanceRequestType_repo.Update(model);
            return new OkObjectResult(new { AttendanceRequestTypeID = model.AttendanceRequestTypeId });
        }

        [HttpDelete("DeleteAttendanceRequestType/{id}")]
        public IActionResult DeleteAttendanceRequestType(long id)
        {
            AttendanceRequestType a = AttendanceRequestType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            AttendanceRequestType_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Flag Category
        [HttpGet("GetFlagCategories", Name = "GetFlagCategories")]
        public IEnumerable<FlagCategory> GetFlagCategories()
        {
            return FlagCategory_repo.GetAll().OrderByDescending(a=>a.FlagCategoryId);
        }

        [HttpGet("GetFlagCategory/{id}", Name = "GetFlagCategory")]
        public FlagCategory GetFlagCategory(long id) => FlagCategory_repo.GetFirst(a => a.FlagCategoryId == id);

        [HttpPost("AddFlagCategory", Name = "AddFlagCategory")]
        [ValidateModelAttribute]
        public IActionResult AddFlagCategory([FromBody]FlagCategory model)
        {
            FlagCategory_repo.Add(model);
            return new OkObjectResult(new { FlagCategoryID = model.FlagCategoryId });
        }

        [HttpPut("UpdateFlagCategory", Name = "UpdateFlagCategory")]
        [ValidateModelAttribute]
        public IActionResult UpdateFlagCategory([FromBody]FlagCategory model)
        {
            FlagCategory_repo.Update(model);
            return new OkObjectResult(new { FlagCategoryID = model.FlagCategoryId });
        }

        [HttpDelete("DeleteFlagCategory/{id}")]
        public IActionResult DeleteFlagCategory(long id)
        {
            FlagCategory a = FlagCategory_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            FlagCategory_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Flag Effect Type
        [HttpGet("GetFlagEffectTypes", Name = "GetFlagEffectTypes")]
        public IEnumerable<FlagEffectType> GetFlagEffectTypes()
        {
            return FlagEffectType_repo.GetAll().OrderByDescending(a=>a.FlagEffectTypeId);
        }

        [HttpGet("GetFlagEffectType/{id}", Name = "GetFlagEffectType")]
        public FlagEffectType GetFlagEffectType(long id) => FlagEffectType_repo.GetFirst(a => a.FlagEffectTypeId == id);

        [HttpPost("AddFlagEffectType", Name = "AddFlagEffectType")]
        [ValidateModelAttribute]
        public IActionResult AddFlagEffectType([FromBody]FlagEffectType model)
        {
            FlagEffectType_repo.Add(model);
            return new OkObjectResult(new { FlagEffectTypeID = model.FlagEffectTypeId });
        }

        [HttpPut("UpdateFlagEffectType", Name = "UpdateFlagEffectType")]
        [ValidateModelAttribute]
        public IActionResult UpdateFlagEffectType([FromBody]FlagEffectType model)
        {
            FlagEffectType_repo.Update(model);
            return new OkObjectResult(new { FlagEffectTypeID = model.FlagEffectTypeId });
        }

        [HttpDelete("DeleteFlagEffectType/{id}")]
        public IActionResult DeleteFlagEffectType(long id)
        {
            FlagEffectType a = FlagEffectType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            FlagEffectType_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Flag Type
        [HttpGet("GetFlagTypes", Name = "GetFlagTypes")]
        public IEnumerable<FlagType> GetFlagTypes()
        {
            return FlagType_repo.GetAll().OrderByDescending(a=>a.FlagTypeId);
        }

        [HttpGet("GetFlagType/{id}", Name = "GetFlagType")]
        public FlagType GetFlagType(long id) => FlagType_repo.GetFirst(a => a.FlagTypeId == id);

        [HttpPost("AddFlagType", Name = "AddFlagType")]
        [ValidateModelAttribute]
        public IActionResult AddFlagType([FromBody]FlagType model)
        {
            FlagType_repo.Add(model);
            return new OkObjectResult(new { FlagTypeID = model.FlagTypeId });
        }

        [HttpPut("UpdateFlagType", Name = "UpdateFlagType")]
        [ValidateModelAttribute]
        public IActionResult UpdateFlagType([FromBody]FlagType model)
        {
            FlagType_repo.Update(model);
            return new OkObjectResult(new { FlagTypeID = model.FlagTypeId });
        }

        [HttpDelete("DeleteFlagType/{id}")]
        public IActionResult DeleteFlagType(long id)
        {
            FlagType a = FlagType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            FlagType_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Flag Value
        [HttpGet("GetFlagValues", Name = "GetFlagValues")]
        public IEnumerable<FlagValue> GetFlagValues()
        {
            return FlagValue_repo.GetAll().OrderByDescending(a=>a.FlagValueId);
        }

        [HttpGet("GetFlagValue/{id}", Name = "GetFlagValue")]
        public FlagValue GetFlagValue(long id) => FlagValue_repo.GetFirst(a => a.FlagValueId == id);

        [HttpPost("AddFlagValue", Name = "AddFlagValue")]
        [ValidateModelAttribute]
        public IActionResult AddFlagValue([FromBody]FlagValue model)
        {
            FlagValue_repo.Add(model);
            return new OkObjectResult(new { FlagValueID = model.FlagValueId });
        }

        [HttpPut("UpdateFlagValue", Name = "UpdateFlagValue")]
        [ValidateModelAttribute]
        public IActionResult UpdateFlagValue([FromBody]FlagValue model)
        {
            FlagValue_repo.Update(model);
            return new OkObjectResult(new { FlagValueID = model.FlagValueId });
        }

        [HttpDelete("DeleteFlagValue/{id}")]
        public IActionResult DeleteFlagValue(long id)
        {
            FlagValue a = FlagValue_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            FlagValue_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Roster
        [HttpGet("GetRosters", Name = "GetRosters")]
        public IEnumerable<Roster> GetRosters()
        {
            return Roster_repo.GetAll().OrderByDescending(a=>a.RosterId);
        }

        [HttpGet("GetRoster/{id}", Name = "GetRoster")]
        public Roster GetRoster(long id) => Roster_repo.GetFirst(a => a.RosterId == id);

        [HttpPost("AddRoster", Name = "AddRoster")]
        [ValidateModelAttribute]
        public IActionResult AddRoster([FromBody]Roster model)
        {
            Roster_repo.Add(model);
            return new OkObjectResult(new { RosterID = model.RosterId });
        }

        [HttpPut("UpdateRoster", Name = "UpdateRoster")]
        [ValidateModelAttribute]
        public IActionResult UpdateRoster([FromBody]Roster model)
        {
            Roster_repo.Update(model);
            return new OkObjectResult(new { RosterID = model.RosterId });
        }

        [HttpDelete("DeleteRoster/{id}")]
        public IActionResult DeleteRoster(long id)
        {
            Roster a = Roster_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Roster_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Shift
        [HttpGet("GetShifts", Name = "GetShifts")]
        public IEnumerable<Shift> GetShifts()
        {
            return Shift_repo.GetAll(a => a.ShiftAttendanceFlags).OrderByDescending(b=>b.ShiftsId);
        }

        [HttpGet("GetShift/{id}", Name = "GetShift")]
        public Shift GetShift(long id) => Shift_repo.GetFirst(a => a.ShiftsId == id, b => b.ShiftAttendanceFlags);

        [HttpPost("AddShift", Name = "AddShift")]
        [ValidateModelAttribute]
        public IActionResult AddShift([FromBody]Shift model)
        {
            Shift_repo.Add(model);
            return new OkObjectResult(new { ShiftID = model.ShiftsId });
        }

        [HttpPut("UpdateShift", Name = "UpdateShift")]
        [ValidateModelAttribute]
        public IActionResult UpdateShift([FromBody]Shift model)
        {
            try
            {
                ShiftAttendanceFlag_repo.DeleteRange(ShiftAttendanceFlag_repo.GetAll().Where(a => a.ShiftId == model.ShiftsId));
                Shift_repo.Update(model);
                return new OkObjectResult(new { ShiftID = model.ShiftsId });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("DeleteShift/{id}")]
        public IActionResult DeleteShift(long id)
        {
            Shift a = Shift_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Shift_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region ShiftAttendanceFlag
        [HttpGet("GetShiftAttendanceFlags", Name = "GetShiftAttendanceFlags")]
        public IEnumerable<ShiftAttendanceFlag> GetShiftAttendanceFlags()
        {
            return ShiftAttendanceFlag_repo.GetAll().OrderByDescending(b => b.ShiftAttendanceFlagId);
        }

        [HttpGet("GetShiftAttendanceFlag/{id}", Name = "GetShiftAttendanceFlag")]
        public ShiftAttendanceFlag GetShiftAttendanceFlag(long id) => ShiftAttendanceFlag_repo.GetFirst(a => a.ShiftAttendanceFlagId == id);

        [HttpPost("AddShiftAttendanceFlag", Name = "AddShiftAttendanceFlag")]
        [ValidateModelAttribute]
        public IActionResult ShiftAttendanceFlag([FromBody]ShiftAttendanceFlag model)
        {
            ShiftAttendanceFlag_repo.Add(model);
            return new OkObjectResult(new { ShiftAttendanceFlagID = model.ShiftAttendanceFlagId });
        }

        [HttpPut("UpdateShiftAttendanceFlag", Name = "UpdateShiftAttendanceFlag")]
        [ValidateModelAttribute]
        public IActionResult UpdateShiftAttendanceFlag([FromBody]ShiftAttendanceFlag model)
        {
            ShiftAttendanceFlag_repo.Update(model);
            return new OkObjectResult(new { ShiftAttendanceFlagID = model.ShiftAttendanceFlagId });
        }

        [HttpDelete("DeleteShiftAttendanceFlag/{id}")]
        public IActionResult DeleteShiftAttendanceFlag(long id)
        {
            ShiftAttendanceFlag a = ShiftAttendanceFlag_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            ShiftAttendanceFlag_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Overtime Flag
        [HttpGet("GetOverTimeFlags", Name = "GetOverTimeFlags")]
        public IEnumerable<OverTimeFlag> GetOverTimeFlags()
        {
            return OverTimeFlag_repo.GetAll().OrderByDescending(a=>a.OvertimeFlagId);
        }

        [HttpGet("GetOverTimeFlag/{id}", Name = "GetOverTimeFlag")]
        public OverTimeFlag GetOverTimeFlag(long id) => OverTimeFlag_repo.GetFirst(a => a.OvertimeFlagId == id);

        [HttpPost("AddOverTimeFlag", Name = "AddOverTimeFlag")]
        [ValidateModelAttribute]
        public IActionResult AddOverTimeFlag([FromBody]OverTimeFlag model)
        {
            OverTimeFlag_repo.Add(model);
            return new OkObjectResult(new { OverTimeFlagID = model.OvertimeFlagId });
        }

        [HttpPut("UpdateOverTimeFlag", Name = "UpdateOverTimeFlag")]
        [ValidateModelAttribute]
        public IActionResult UpdateOverTimeFlag([FromBody]OverTimeFlag model)
        {
            OverTimeFlag_repo.Update(model);
            return new OkObjectResult(new { OverTimeFlagID = model.OvertimeFlagId });
        }

        [HttpDelete("DeleteOverTimeFlag/{id}")]
        public IActionResult DeleteOverTimeFlag(long id)
        {
            OverTimeFlag a = OverTimeFlag_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            OverTimeFlag_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Overtime Type
        [HttpGet("GetOverTimeTypes", Name = "GetOverTimeTypes")]
        public IEnumerable<OverTimeType> GetOverTimeTypes()
        {
            return OverTimeType_repo.GetAll().OrderByDescending(a=>a.OverTimeTypeId);
        }

        [HttpGet("GetOverTimeType/{id}", Name = "GetOverTimeType")]
        public OverTimeType GetOverTimeType(long id) => OverTimeType_repo.GetFirst(a => a.OverTimeTypeId == id);

        [HttpPost("AddOverTimeType", Name = "AddOverTimeType")]
        [ValidateModelAttribute]
        public IActionResult AddOverTimeType([FromBody]OverTimeType model)
        {
            OverTimeType_repo.Add(model);
            return new OkObjectResult(new { OverTimeTypeID = model.OverTimeTypeId });
        }

        [HttpPut("UpdateOverTimeType", Name = "UpdateOverTimeType")]
        [ValidateModelAttribute]
        public IActionResult UpdateOverTimeType([FromBody]OverTimeType model)
        {
            OverTimeType_repo.Update(model);
            return new OkObjectResult(new { OverTimeTypeID = model.OverTimeTypeId });
        }

        [HttpDelete("DeleteOverTimeType/{id}")]
        public IActionResult DeleteOverTimeType(long id)
        {
            OverTimeType a = OverTimeType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            OverTimeType_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Employee WorkingDay Ot
        [HttpGet("GetEmployeeWorkingDayOts", Name = "GetEmployeeWorkingDayOts")]
        public IEnumerable<EmployeeWorkingDayOt> GetEmployeeWorkingDayOts()
        {
            return EmployeeWorkingDayOt_repo.GetAll().OrderByDescending(a=>a.EmployeeWorkingDayOtId);
        }

        [HttpGet("GetEmployeeWorkingDayOt/{id}", Name = "GetEmployeeWorkingDayOt")]
        public EmployeeWorkingDayOt GetEmployeeWorkingDayOt(long id) => EmployeeWorkingDayOt_repo.GetFirst(a => a.EmployeeWorkingDayOtId == id);

        [HttpPost("AddEmployeeWorkingDayOt", Name = "AddEmployeeWorkingDayOt")]
        [ValidateModelAttribute]
        public IActionResult AddEmployeeWorkingDayOt([FromBody]EmployeeWorkingDayOt model)
        {
            EmployeeWorkingDayOt_repo.Add(model);
            return Ok(model.EmployeeWorkingDayOtId);
        }

        [HttpPut("UpdateEmployeeWorkingDayOt", Name = "UpdateEmployeeWorkingDayOt")]
        [ValidateModelAttribute]
        public IActionResult UpdateEmployeeWorkingDayOt([FromBody]EmployeeWorkingDayOt model)
        {
            EmployeeWorkingDayOt_repo.Update(model);
            return new OkObjectResult(new { EmployeeWorkingDayOtID = model.EmployeeWorkingDayOtId });
        }

        [HttpDelete("DeleteEmployeeWorkingDayOt/{id}")]
        public IActionResult DeleteEmployeeWorkingDayOt(long id)
        {
            EmployeeWorkingDayOt a = EmployeeWorkingDayOt_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            EmployeeWorkingDayOt_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Employee OffDay Ot
        [HttpGet("GetEmployeeOffDayOts", Name = "GetEmployeeOffDayOts")]
        public IEnumerable<EmployeeOffDayOt> GetEmployeeOffDayOts()
        {
            return EmployeeOffDayOt_repo.GetAll().OrderByDescending(a=>a.EmployeeOffDayOtId);
        }

        [HttpGet("GetEmployeeOffDayOt/{id}", Name = "GetEmployeeOffDayOt")]
        public EmployeeOffDayOt GetEmployeeOffDayOt(long id) => EmployeeOffDayOt_repo.GetFirst(a => a.EmployeeOffDayOtId == id);

        [HttpPost("AddEmployeeOffDayOt", Name = "AddEmployeeOffDayOt")]
        [ValidateModelAttribute]
        public IActionResult AddEmployeeOffDayOt([FromBody]EmployeeOffDayOt model)
        {
            EmployeeOffDayOt_repo.Add(model);
            return Ok(model.EmployeeOffDayOtId);
        }

        [HttpPut("UpdateEmployeeOffDayOt", Name = "UpdateEmployeeOffDayOt")]
        [ValidateModelAttribute]
        public IActionResult UpdateEmployeeOffDayOt([FromBody]EmployeeOffDayOt model)
        {
            EmployeeOffDayOt_repo.Update(model);
            return new OkObjectResult(new { EmployeeOffDayOtID = model.EmployeeOffDayOtId });
        }

        [HttpDelete("DeleteEmployeeOffDayOt/{id}")]
        public IActionResult DeleteEmployeeOffDayOt(long id)
        {
            EmployeeOffDayOt a = EmployeeOffDayOt_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            EmployeeOffDayOt_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Employee Incoming Ot
        [HttpGet("GetEmployeeIncomingOts", Name = "GetEmployeeIncomingOts")]
        public IEnumerable<EmployeeIncomingOt> GetEmployeeIncomingOts()
        {
            return EmployeeIncomingOt_repo.GetAll().OrderByDescending(a=>a.EmployeeIncomingOtId);
        }

        [HttpGet("GetEmployeeIncomingOt/{id}", Name = "GetEmployeeIncomingOt")]
        public EmployeeIncomingOt GetEmployeeIncomingOt(long id) => EmployeeIncomingOt_repo.GetFirst(a => a.EmployeeIncomingOtId == id);

        [HttpPost("AddEmployeeIncomingOt", Name = "AddEmployeeIncomingOt")]
        [ValidateModelAttribute]
        public IActionResult AddEmployeeIncomingOt([FromBody]EmployeeIncomingOt model)
        {
            EmployeeIncomingOt_repo.Add(model);
            return Ok(model.EmployeeIncomingOtId);
        }

        [HttpPut("UpdateEmployeeIncomingOt", Name = "UpdateEmployeeIncomingOt")]
        [ValidateModelAttribute]
        public IActionResult UpdateEmployeeIncomingOt([FromBody]EmployeeIncomingOt model)
        {
            EmployeeIncomingOt_repo.Update(model);
            return new OkObjectResult(new { EmployeeIncomingOtID = model.EmployeeIncomingOtId });
        }

        [HttpDelete("DeleteEmployeeIncomingOt/{id}")]
        public IActionResult DeleteEmployeeIncomingOt(long id)
        {
            EmployeeIncomingOt a = EmployeeIncomingOt_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            EmployeeIncomingOt_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Employee Outgoing Ot
        [HttpGet("GetEmployeeOutgoingOts", Name = "GetEmployeeOutgoingOts")]
        public IEnumerable<EmployeeOutgoingOt> GetEmployeeOutgoingOts()
        {
            return EmployeeOutgoingOt_repo.GetAll().OrderByDescending(a=>a.EmployeeOutgoingOtId);
        }

        [HttpGet("GetEmployeeOutgoingOt/{id}", Name = "GetEmployeeOutgoingOt")]
        public EmployeeOutgoingOt GetEmployeeOutgoingOt(long id) => EmployeeOutgoingOt_repo.GetFirst(a => a.EmployeeOutgoingOtId == id);

        [HttpPost("AddEmployeeOutgoingOt", Name = "AddEmployeeOutgoingOt")]
        [ValidateModelAttribute]
        public IActionResult AddEmployeeOutgoingOt([FromBody]EmployeeOutgoingOt model)
        {
            EmployeeOutgoingOt_repo.Add(model);
            return Ok(model.EmployeeOutgoingOtId);
        }

        [HttpPut("UpdateEmployeeOutgoingOt", Name = "UpdateEmployeeOutgoingOt")]
        [ValidateModelAttribute]
        public IActionResult UpdateEmployeeOutgoingOt([FromBody]EmployeeOutgoingOt model)
        {
            EmployeeOutgoingOt_repo.Update(model);
            return new OkObjectResult(new { EmployeeOutgoingOtID = model.EmployeeOutgoingOtId });
        }

        [HttpDelete("DeleteEmployeeOutgoingOt/{id}")]
        public IActionResult DeleteEmployeeOutgoingOt(long id)
        {
            EmployeeOutgoingOt a = EmployeeOutgoingOt_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            EmployeeOutgoingOt_repo.Delete(a);
            return Ok();
        }

        #endregion
    }
}
