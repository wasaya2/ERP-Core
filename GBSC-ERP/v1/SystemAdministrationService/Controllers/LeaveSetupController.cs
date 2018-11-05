using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.HR.Leave.LeaveSetup;
using ErpCore.Filters;
using Microsoft.AspNetCore.Mvc;
using SystemAdministrationService.Repos.Hr.LeaveRepos.Interfaces;
using SystemAdministrationService.Repos.Interfaces;

namespace SystemAdministrationService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LeaveSetupController : Controller
    {
        private ILeaveDayTypeRepository LeaveDayType_repo;
        private ILeaveEligibilityRepository LeaveEligibility_repo;
        private ILeavePolicyRepository LeavePolicy_repo;
        private ILeavePurposeRepository LeavePurpose_repo;
        private ILeaveTypeRepository LeaveType_repo;
        private ILeaveYearRepository LeaveYear_repo;
        private IProrateMatrixRepository ProrateMatrix_repo;
        private IDecimalRoundingMatrixRepository DecimalRoundingMatrix_repo;
        private ILeaveSubTypeRepository LeaveSubType_repo;
        private ILeaveTypeBalanceRepository LeaveTypeBalance_repo;
        private ILeaveApproverRepository LeaveApprover_repo;
        private IUserRepository user_repo;

        public LeaveSetupController(
             ILeaveDayTypeRepository repo1,
             ILeaveEligibilityRepository repo2,
             ILeavePolicyRepository repo3,
             ILeavePurposeRepository repo4,
             ILeaveTypeRepository repo5,
             ILeaveYearRepository repo6,
             IDecimalRoundingMatrixRepository repo7,
             IProrateMatrixRepository repo8,
             ILeaveSubTypeRepository repo9,
             ILeaveTypeBalanceRepository repo10,
             ILeaveApproverRepository repo11,
             IUserRepository repo12

             )
        {
            LeaveDayType_repo = repo1;
            LeaveEligibility_repo = repo2;
            LeavePolicy_repo = repo3;
            LeavePurpose_repo = repo4;
            LeaveType_repo = repo5;
            LeaveYear_repo = repo6;
            DecimalRoundingMatrix_repo = repo7;
            ProrateMatrix_repo = repo8;
            LeaveSubType_repo = repo9;
            LeaveTypeBalance_repo = repo10;
            LeaveApprover_repo = repo11;
            user_repo = repo12;

        }

        #region Leave Day Type
        [HttpGet("GetLeaveDayTypes", Name = "GetLeaveDayTypes")]
        public IEnumerable<LeaveDayType> GetLeaveDayTypes()
        {
            return LeaveDayType_repo.GetAll();
        }

        [HttpGet("GetLeaveDayType/{id}", Name = "GetLeaveDayType")]
        public LeaveDayType GetLeaveDayType(long id) => LeaveDayType_repo.GetFirst(a => a.LeaveDayTypeId == id);

        [HttpPost("AddLeaveDayType", Name = "AddLeaveDayType")]
        [ValidateModelAttribute]
        public IActionResult AddLeaveDayType([FromBody]LeaveDayType model)
        {
            LeaveDayType_repo.Add(model);
            return new OkObjectResult(new { LeaveDayTypeID = model.LeaveDayTypeId });
        }

        [HttpPut("UpdateLeaveDayType", Name = "UpdateLeaveDayType")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveDayType([FromBody]LeaveDayType model)
        {
            LeaveDayType_repo.Update(model);
            return new OkObjectResult(new { LeaveDayTypeID = model.LeaveDayTypeId });
        }

        [HttpDelete("DeleteLeaveDayType/{id}")]
        public IActionResult DeleteLeaveDayType(long id)
        {
            LeaveDayType a = LeaveDayType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveDayType_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Leave Eligibility
        [HttpGet("GetLeaveEligibilities", Name = "GetLeaveEligibilities")]
        public IEnumerable<LeaveEligibility> GetLeaveEligibilities()
        {
            return LeaveEligibility_repo.GetAll();
        }

        [HttpGet("GetLeaveEligibility/{id}", Name = "GetLeaveEligibility")]
        public LeaveEligibility GetLeaveEligibility(long id) => LeaveEligibility_repo.GetFirst(a => a.LeaveEligibilityId == id);

        [HttpPost("AddLeaveEligibility", Name = "AddLeaveEligibility")]
        [ValidateModelAttribute]
        public IActionResult AddLeaveEligibility([FromBody]LeaveEligibility model)
        {
            LeaveEligibility_repo.Add(model);
            return new OkObjectResult(new { LeaveEligibilityID = model.LeaveEligibilityId });
        }

        [HttpPut("UpdateLeaveEligibility", Name = "UpdateLeaveEligibility")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveEligibility([FromBody]LeaveEligibility model)
        {
            LeaveEligibility_repo.Update(model);
            return new OkObjectResult(new { LeaveEligibilityID = model.LeaveEligibilityId });
        }

        [HttpDelete("DeleteLeaveEligibility/{id}")]
        public IActionResult DeleteLeaveEligibility(long id)
        {
            LeaveEligibility a = LeaveEligibility_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveEligibility_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Leave Policy
        [HttpGet("GetLeavePolicies", Name = "GetLeavePolicies")]
        public IEnumerable<LeavePolicy> GetLeavePolicies()
        {
            return LeavePolicy_repo.GetAll();
        }

        [HttpGet("GetLeavePolicy/{id}", Name = "GetLeavePolicy")]
        public LeavePolicy GetLeavePolicy(long id) => LeavePolicy_repo.GetFirst(a => a.LeavePolicyId == id);

        [HttpPost("AddLeavePolicy", Name = "AddLeavePolicy")]
        [ValidateModelAttribute]
        public IActionResult AddLeavePolicy([FromBody]LeavePolicy model)
        {
            LeavePolicy_repo.Add(model);
            return new OkObjectResult(new { LeavePolicyID = model.LeavePolicyId });
        }

        [HttpPut("UpdateLeavePolicy", Name = "UpdateLeavePolicy")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeavePolicy([FromBody]LeavePolicy model)
        {
            LeavePolicy_repo.Update(model);
            return new OkObjectResult(new { LeavePolicyID = model.LeavePolicyId });
        }

        [HttpDelete("DeleteLeavePolicy/{id}")]
        public IActionResult DeleteLeavePolicy(long id)
        {
            LeavePolicy a = LeavePolicy_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeavePolicy_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Leave Purpose
        [HttpGet("GetLeavePurposes", Name = "GetLeavePurposes")]
        public IEnumerable<LeavePurpose> GetLeavePurposes()
        {
            return LeavePurpose_repo.GetAll();
        }

        [HttpGet("GetLeavePurpose/{id}", Name = "GetLeavePurpose")]
        public LeavePurpose GetLeavePurpose(long id) => LeavePurpose_repo.GetFirst(a => a.LeavePurposeId == id);

        [HttpPost("AddLeavePurpose", Name = "AddLeavePurpose")]
        [ValidateModelAttribute]
        public IActionResult AddLeavePurpose([FromBody]LeavePurpose model)
        {
            LeavePurpose_repo.Add(model);
            return new OkObjectResult(new { LeavePurposeID = model.LeavePurposeId });
        }

        [HttpPut("UpdateLeavePurpose", Name = "UpdateLeavePurpose")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeavePurpose([FromBody]LeavePurpose model)
        {
            LeavePurpose_repo.Update(model);
            return new OkObjectResult(new { LeavePurposeID = model.LeavePurposeId });
        }

        [HttpDelete("DeleteLeavePurpose/{id}")]
        public IActionResult DeleteLeavePurpose(long id)
        {
            LeavePurpose a = LeavePurpose_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeavePurpose_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Leave Type
        [HttpGet("GetLeaveTypes", Name = "GetLeaveTypes")]
        public IEnumerable<LeaveType> GetLeaveTypes()
        {
            return LeaveType_repo.GetAll();
        }

        [HttpGet("GetLeaveType/{id}", Name = "GetLeaveType")]
        public LeaveType GetLeaveType(long id) => LeaveType_repo.GetFirst(a => a.LeaveTypeId == id);

        [HttpPost("AddLeaveType", Name = "AddLeaveType")]
        [ValidateModelAttribute]
        public IActionResult AddLeaveType([FromBody]LeaveType model)
        {
            LeaveType_repo.Add(model);
            return new OkObjectResult(new { LeaveTypeID = model.LeaveTypeId });
        }

        [HttpPut("UpdateLeaveType", Name = "UpdateLeaveType")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveType([FromBody]LeaveType model)
        {
            LeaveType_repo.Update(model);
            return new OkObjectResult(new { LeaveTypeID = model.LeaveTypeId });
        }

        [HttpDelete("DeleteLeaveType/{id}")]
        public IActionResult DeleteLeaveType(long id)
        {
            LeaveType a = LeaveType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveType_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Leave Sub Type
        [HttpGet("GetLeaveSubTypes", Name = "GetLeaveSubTypes")]
        public IEnumerable<LeaveSubType> GetLeaveSubTypes()
        {
            return LeaveSubType_repo.GetAll();
        }

        [HttpGet("GetLeaveSubType/{id}", Name = "GetLeaveSubType")]
        public LeaveSubType GetLeaveSubType(long id) => LeaveSubType_repo.GetFirst(a => a.LeaveSubTypeId == id);

        [HttpPost("AddLeaveSubType", Name = "AddLeaveSubType")]
        [ValidateModelAttribute]
        public IActionResult AddLeaveSubType([FromBody]LeaveSubType model)
        {
            LeaveSubType_repo.Add(model);
            return new OkObjectResult(new { LeaveSubTypeID = model.LeaveSubTypeId });
        }

        [HttpPut("UpdateLeaveSubType", Name = "UpdateLeaveSubType")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveSubType([FromBody]LeaveSubType model)
        {
            LeaveSubType_repo.Update(model);
            return new OkObjectResult(new { LeaveSubTypeID = model.LeaveSubTypeId });
        }

        [HttpDelete("DeleteLeaveSubType/{id}")]
        public IActionResult DeleteLeaveSubType(long id)
        {
            LeaveSubType a = LeaveSubType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveSubType_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Leave Type Balance
        [HttpGet("GetLeaveTypeBalances", Name = "GetLeaveTypeBalances")]
        public IEnumerable<LeaveTypeBalance> GetLeaveTypeBalances()
        {
            return LeaveTypeBalance_repo.GetAll();
        }

        [HttpGet("GetLeaveTypeBalance/{id}", Name = "GetLeaveTypeBalance")]
        public LeaveTypeBalance GetLeaveTypeBalance(long id) => LeaveTypeBalance_repo.GetFirst(a => a.LeaveTypeBalanceId == id);

        [HttpPost("AddLeaveTypeBalance", Name = "AddLeaveTypeBalance")]
        [ValidateModelAttribute]
        public IActionResult AddLeaveTypeBalance([FromBody]LeaveTypeBalance model)
        {
            LeaveTypeBalance_repo.Add(model);
            return new OkObjectResult(new { LeaveTypeBalanceID = model.LeaveTypeBalanceId });
        }

        [HttpPut("UpdateLeaveTypeBalance", Name = "UpdateLeaveTypeBalance")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveTypeBalance([FromBody]LeaveTypeBalance model)
        {
            LeaveTypeBalance_repo.Update(model);
            return new OkObjectResult(new { LeaveTypeBalanceID = model.LeaveTypeBalanceId });
        }

        [HttpDelete("DeleteLeaveTypeBalance/{id}")]
        public IActionResult DeleteLeaveTypeBalance(long id)
        {
            LeaveTypeBalance a = LeaveTypeBalance_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveTypeBalance_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Leave Year
        [HttpGet("GetLeaveYears", Name = "GetLeaveYears")]
        public IEnumerable<LeaveYear> GetLeaveYears()
        {
            return LeaveYear_repo.GetAll();
        }

        [HttpGet("GetLeaveYear/{id}", Name = "GetLeaveYear")]
        public LeaveYear GetLeaveYear(long id) => LeaveYear_repo.GetFirst(a => a.LeaveYearId == id);

        [HttpPost("AddLeaveYear", Name = "AddLeaveYear")]
        [ValidateModelAttribute]
        public IActionResult AddLeaveYear([FromBody]LeaveYear model)
        {
            LeaveYear_repo.Add(model);
            return new OkObjectResult(new { LeaveYearID = model.LeaveYearId });
        }

        [HttpPut("UpdateLeaveYear", Name = "UpdateLeaveYear")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveYear([FromBody]LeaveYear model)
        {
            LeaveYear_repo.Update(model);
            return new OkObjectResult(new { LeaveYearID = model.LeaveYearId });
        }

        [HttpDelete("DeleteLeaveYear/{id}")]
        public IActionResult DeleteLeaveYear(long id)
        {
            LeaveYear a = LeaveYear_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveYear_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Prorate Matrix
        [HttpGet("GetProrateMatrixs", Name = "GetProrateMatrixs")]
        public IEnumerable<ProrateMatrix> GetProrateMatrixs()
        {
            return ProrateMatrix_repo.GetAll();
        }

        [HttpGet("GetProrateMatrix/{id}", Name = "GetProrateMatrix")]
        public ProrateMatrix GetProrateMatrix(long id) => ProrateMatrix_repo.GetFirst(a => a.ProrateMatrixId == id);

        [HttpPost("AddProrateMatrix", Name = "AddProrateMatrix")]
        [ValidateModelAttribute]
        public IActionResult AddProrateMatrix([FromBody]ProrateMatrix model)
        {
            ProrateMatrix_repo.Add(model);
            return new OkObjectResult(new { ProrateMatrixID = model.ProrateMatrixId });
        }

        [HttpPut("UpdateProrateMatrix", Name = "UpdateProrateMatrix")]
        [ValidateModelAttribute]
        public IActionResult UpdateProrateMatrix([FromBody]ProrateMatrix model)
        {
            ProrateMatrix_repo.Update(model);
            return new OkObjectResult(new { ProrateMatrixID = model.ProrateMatrixId });
        }

        [HttpDelete("DeleteProrateMatrix/{id}")]
        public IActionResult DeleteProrateMatrix(long id)
        {
            ProrateMatrix a = ProrateMatrix_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            ProrateMatrix_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Decimal Rouding Matrix
        [HttpGet("GetDecimalRoundingMatrixs", Name = "GetDecimalRoundingMatrixs")]
        public IEnumerable<DecimalRoundingMatrix> GetDecimalRoundingMatrixs()
        {
            return DecimalRoundingMatrix_repo.GetAll();
        }

        [HttpGet("GetDecimalRoundingMatrix/{id}", Name = "GetDecimalRoundingMatrix")]
        public DecimalRoundingMatrix GetDecimalRoundingMatrix(long id) => DecimalRoundingMatrix_repo.GetFirst(a => a.DecimalRoundingMatrixId == id);

        [HttpPost("AddDecimalRoundingMatrix", Name = "AddDecimalRoundingMatrix")]
        [ValidateModelAttribute]
        public IActionResult AddDecimalRoundingMatrix([FromBody]DecimalRoundingMatrix model)
        {
            DecimalRoundingMatrix_repo.Add(model);
            return new OkObjectResult(new { DecimalRoundingMatrixID = model.DecimalRoundingMatrixId });
        }

        [HttpPut("UpdateDecimalRoundingMatrix", Name = "UpdateDecimalRoundingMatrix")]
        [ValidateModelAttribute]
        public IActionResult UpdateDecimalRoundingMatrix([FromBody]DecimalRoundingMatrix model)
        {
            DecimalRoundingMatrix_repo.Update(model);
            return new OkObjectResult(new { DecimalRoundingMatrixID = model.DecimalRoundingMatrixId });
        }

        [HttpDelete("DeleteDecimalRoundingMatrix/{id}")]
        public IActionResult DeleteDecimalRoundingMatrix(long id)
        {
            DecimalRoundingMatrix a = DecimalRoundingMatrix_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            DecimalRoundingMatrix_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region LeaveApprover

        [HttpGet("GetLeaveApprovers", Name = "GetLeaveApprovers")]
        public IEnumerable<LeaveApprover> GetLeaveApprovers()
        {
            return LeaveApprover_repo.GetAll();
        }

        //[HttpGet("GetLeaveApproversNames", Name = "GetLeaveApproversNames")]
        //public IEnumerable<string> GetLeaveApproversNames()
        //{
        //    IEnumerable<LeaveApprover> las = LeaveApprover_repo.GetAll();
        //    IList<string> Names = new List<string>();
        //    foreach(LeaveApprover la in las)
        //    {
        //        Names.Add(la.Name);
        //    }
        //    return Names;
        //}

        [HttpGet("GetLeaveApprover/{id}", Name = "GetLeaveApprover")]
        public LeaveApprover GetLeaveApprover(long id) => LeaveApprover_repo.GetFirst(a => a.LeaveApproverId == id);

        [HttpPost("AddLeaveApprover", Name = "AddLeaveApprover")]
        [ValidateModelAttribute]
        public IActionResult AddLeaveApprover([FromBody]LeaveApprover model)
        {
            User user = user_repo.GetFirst(a => a.UserId == model.UserId);
            model.Name = user.FirstName;
            LeaveApprover_repo.Add(model);
            return new OkObjectResult(new { LeaveApproverID = model.LeaveApproverId });
        }

        [HttpPut("UpdateLeaveApprover", Name = "UpdateLeaveApprover")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveApprover([FromBody]LeaveApprover model)
        {
            LeaveApprover_repo.Update(model);
            return new OkObjectResult(new { LeaveApproverID = model.LeaveApproverId });
        }

        [HttpDelete("DeleteLeaveApprover/{id}")]
        public IActionResult DeleteLeaveApprover(long id)
        {
            LeaveApprover a = LeaveApprover_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveApprover_repo.Delete(a);
            return Ok();
        }
        #endregion
    }
}