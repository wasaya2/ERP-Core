using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.HR.Leave;
using ErpCore.Entities.HR.Leave.LeaveAdmin;
using ErpCore.Filters;
using Microsoft.AspNetCore.Mvc;
using SystemAdministrationService.Repos.Hr.LeaveRepos.Interfaces; 
using SystemAdministrationService.Repos.Interfaces;

namespace SystemAdministrationService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LeaveController : Controller
    {

        private ILeaveRequestRepository LeaveRequest_repo;
        private ILeaveRequestDetailRepository LeaveRequestDetail_repo;
        private ILeaveOpeningRepository LeaveOpening_repo;
        private ILeaveOpeningDetailRepository LeaveOpeningDetail_repo;
        private ILeavePolicyEmployeeRepository LeavePolicyEmployee_repo;
        private ILeaveApprovalRepository LeaveApproval_repo; 
        private ILeaveClosingRepository LeaveClosing_repo; 

        public LeaveController(
             ILeaveRequestRepository repo1,
             ILeaveRequestDetailRepository repo2,
             ILeaveOpeningRepository repo3,
             ILeaveOpeningDetailRepository repo4,
             ILeavePolicyEmployeeRepository repo5, 
             ILeaveApprovalRepository repo6,
             ILeaveClosingRepository repo7
             )
        {
            LeaveRequest_repo = repo1;
            LeaveRequestDetail_repo = repo2; 
            LeaveOpening_repo = repo3;
            LeaveOpeningDetail_repo = repo4;
            LeavePolicyEmployee_repo = repo5;
            LeaveApproval_repo = repo6; 
            LeaveClosing_repo = repo7; 

        }

        #region Leave Request
        [HttpGet("GetLeaverequests", Name = "GetLeaverequests")]
        public IEnumerable<LeaveRequest> GetLeaverequests()
        {
            return LeaveRequest_repo.GetAll(a=>a.LeaveRequestDetails).OrderByDescending(a => a.LeaveRequestId);
        }

        [HttpGet("GetLeaverequest/{id}", Name = "GetLeaverequest")]
        public LeaveRequest GetLeaverequest(long id) => LeaveRequest_repo.GetFirst(a => a.LeaveRequestId == id, b => b.LeaveRequestDetails);

        [HttpPost("AddLeaverequest", Name = "AddLeaverequest")]
        [ValidateModelAttribute]
        public IActionResult AddLeaverequest([FromBody]LeaveRequest model)
        {
            model.RequestDate = DateTime.Now;
            LeaveRequest_repo.Add(model);
            return new OkObjectResult(new { LeaverequestID = model.LeaveRequestId });
        }

        [HttpPut("UpdateLeaverequest", Name = "UpdateLeaverequest")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaverequest([FromBody]LeaveRequest model)
        {
            try
            {
                LeaveRequestDetail_repo.DeleteRange(LeaveRequestDetail_repo.GetAll().Where(a => a.LeaveRequestId == model.LeaveRequestId));
                LeaveRequest_repo.Update(model);
            return new OkObjectResult(new { LeaverequestID = model.LeaveRequestId });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("DeleteLeaverequest/{id}")]
        public IActionResult DeleteLeaverequest(long id)
        {
            LeaveRequest a = LeaveRequest_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveRequest_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Leave Request Detail

        [HttpGet("GetLeaveRequestDetails", Name = "GetLeaveRequestDetails")]
        public IEnumerable<LeaveRequestDetail> GetLeaveRequestDetails()
        {
            return LeaveRequestDetail_repo.GetAll().OrderByDescending(a => a.LeaveRequestDetailId);
        }

        [HttpGet("GetLeaveRequestDetail/{id}", Name = "GetLeaveRequestDetail")]
        public LeaveRequestDetail GetLeaveRequestDetail(long id) => LeaveRequestDetail_repo.GetFirst(a => a.LeaveRequestDetailId == id);

        [HttpPost("AddLeaveRequestDetail", Name = "AddLeaveRequestDetail")]
        [ValidateModelAttribute]
        public IActionResult AddLeaveRequestDetail([FromBody]LeaveRequestDetail model)
        {
            LeaveRequestDetail_repo.Add(model);
            return new OkObjectResult(new { LeaveRequestDetailID = model.LeaveRequestDetailId });
        }

        [HttpPut("UpdateLeaveRequestDetail", Name = "UpdateLeaveRequestDetail")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveRequestDetail([FromBody]LeaveRequestDetail model)
        {
            LeaveRequestDetail_repo.Update(model);
            return new OkObjectResult(new { LeaveRequestDetailID = model.LeaveRequestDetailId });
        }

        [HttpDelete("DeleteLeaveRequestDetail/{id}")]
        public IActionResult DeleteLeaveRequestDetail(long id)
        {
            LeaveRequestDetail a = LeaveRequestDetail_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveRequestDetail_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Leave Opening
        [HttpGet("GetLeaveOpenings", Name = "GetLeaveOpenings")]
        public IEnumerable<LeaveOpening> GetLeaveOpenings()
        {
            return LeaveOpening_repo.GetAll(a => a.LeaveOpeningDetails).OrderByDescending(a => a.LeaveOpeningId);
        }

        [HttpGet("GetLeaveOpening/{id}", Name = "GetLeaveOpening")]
        public LeaveOpening GetLeaveOpening(long id) => LeaveOpening_repo.GetFirst(a => a.LeaveOpeningId == id,b=> b.LeaveOpeningDetails);

        [HttpPost("AddLeaveOpening", Name = "AddLeaveOpening")]
        [ValidateModelAttribute]
        public IActionResult AddLeaveOpening([FromBody]LeaveOpening model)
        {
            LeaveOpening_repo.Add(model);
            return new OkObjectResult(new { LeaveOpeningID = model.LeaveOpeningId });
        }

        [HttpPut("UpdateLeaveOpening", Name = "UpdateLeaveOpening")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveOpening([FromBody]LeaveOpening model)
        {
            try
            {
                LeaveOpeningDetail_repo.DeleteRange(LeaveOpeningDetail_repo.GetAll().Where(a => a.LeaveOpeningId == model.LeaveOpeningId));
                LeaveOpening_repo.Update(model);
            return new OkObjectResult(new { LeaveOpeningID = model.LeaveOpeningId });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("DeleteLeaveOpening/{id}")]
        public IActionResult DeleteLeaveOpening(long id)
        {
            LeaveOpening a = LeaveOpening_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveOpening_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Leave Opening Detail
        [HttpGet("GetLeaveOpeningDetails", Name = "GetLeaveOpeningDetails")]
        public IEnumerable<LeaveOpeningDetail> GetLeaveOpeningDetails()
        {
            return LeaveOpeningDetail_repo.GetAll().OrderByDescending(a => a.LeaveOpeningDetailId);
        }

        [HttpGet("GetLeaveOpeningDetail/{id}", Name = "GetLeaveOpeningDetail")]
        public LeaveOpeningDetail GetLeaveOpeningDetail(long id) => LeaveOpeningDetail_repo.GetFirst(a => a.LeaveOpeningDetailId == id);

        [HttpPost("AddLeaveOpeningDetail", Name = "AddLeaveOpeningDetail")]
        [ValidateModelAttribute]
        public IActionResult AddLeaveOpeningDetail([FromBody]LeaveOpeningDetail model)
        {
            LeaveOpeningDetail_repo.Add(model);
            return new OkObjectResult(new { LeaveOpeningDetailID = model.LeaveOpeningDetailId });
        }

        [HttpPut("UpdateLeaveOpeningDetail", Name = "UpdateLeaveOpeningDetail")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveOpeningDetail([FromBody]LeaveOpeningDetail model)
        {
            LeaveOpeningDetail_repo.Update(model);
            return new OkObjectResult(new { LeaveOpeningDetailID = model.LeaveOpeningDetailId });
        }

        [HttpDelete("DeleteLeaveOpeningDetail/{id}")]
        public IActionResult DeleteLeaveOpeningDetail(long id)
        {
            LeaveOpeningDetail a = LeaveOpeningDetail_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveOpeningDetail_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Leave Policy Employee
        [HttpGet("GetLeavePolicyEmployees", Name = "GetLeavePolicyEmployees")]
        public IEnumerable<LeavePolicyEmployee> GetLeavePolicyEmployees()
        {
            return LeavePolicyEmployee_repo.GetAll().OrderByDescending(a=>a.LeavePolicyEmployeeWiseId);
        }

        [HttpGet("GetLeavePolicyEmployee/{id}", Name = "GetLeavePolicyEmployee")]
        public LeavePolicyEmployee GetLeavePolicyEmployee(long id) => LeavePolicyEmployee_repo.GetFirst(a => a.LeavePolicyEmployeeWiseId == id);

        [HttpPost("AddLeavePolicyEmployee", Name = "AddLeavePolicyEmployee")]
        [ValidateModelAttribute]
        public IActionResult AddLeavePolicyEmployee([FromBody]LeavePolicyEmployee model)
        {
            LeavePolicyEmployee_repo.Add(model);
            return new OkObjectResult(new { LeavePolicyEmployeeID = model.LeavePolicyEmployeeWiseId });
        }

        [HttpPut("UpdateLeavePolicyEmployee", Name = "UpdateLeavePolicyEmployee")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeavePolicyEmployee([FromBody]LeavePolicyEmployee model)
        {
            LeavePolicyEmployee_repo.Update(model);
            return new OkObjectResult(new { LeavePolicyEmployeeID = model.LeavePolicyEmployeeWiseId });
        }

        [HttpDelete("DeleteLeavePolicyEmployee/{id}")]
        public IActionResult DeleteLeavePolicyEmployee(long id)
        {
            LeavePolicyEmployee a = LeavePolicyEmployee_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeavePolicyEmployee_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region LeaveApproval

        [HttpGet("GetLeaveApprovals", Name = "GetLeaveApprovals")]
        public IEnumerable<LeaveApproval> GetLeaveApprovals()
        {
            return LeaveApproval_repo.GetAll().OrderByDescending(a=>a.LeaveApprovalId);
        }

        [HttpGet("GetLeaveApproval/{id}", Name = "GetLeaveApproval")]
        public LeaveApproval GetLeaveApproval(long id) => LeaveApproval_repo.GetFirst(a => a.LeaveApprovalId == id);

        [HttpPost("AddLeaveApproval", Name = "AddLeaveApproval")]
        [ValidateModelAttribute]
        public IActionResult AddLeaveApproval([FromBody]LeaveApproval model)
        {
            LeaveApproval_repo.Add(model);
            return new OkObjectResult(new { LeaveApprovalID = model.LeaveApprovalId });
        }

        [HttpPut("UpdateLeaveApproval", Name = "UpdateLeaveApproval")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveApproval([FromBody]LeaveApproval model)
        {
            LeaveApproval_repo.Update(model);
            return new OkObjectResult(new { LeaveApprovalID = model.LeaveApprovalId });
        }

        [HttpDelete("DeleteLeaveApproval/{id}")]
        public IActionResult DeleteLeaveApproval(long id)
        {
            LeaveApproval a = LeaveApproval_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveApproval_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region Leave Closing
        [HttpGet("GetLeaveClosings", Name = "GetLeaveClosings")]
        public IEnumerable<LeaveClosing> GetLeaveClosings()
        {
            return LeaveClosing_repo.GetAll().OrderByDescending(a=>a.LeaveClosingId);
        }

        [HttpGet("GetLeaveClosing/{id}", Name = "GetLeaveClosing")]
        public LeaveClosing GetLeaveClosing(long id) => LeaveClosing_repo.GetFirst(a => a.LeaveClosingId == id);

        [HttpPost("AddLeaveClosing", Name = "AddLeaveClosing")]
        [ValidateModelAttribute]
        public IActionResult AddLeaveClosing([FromBody]LeaveClosing model)
        {
            LeaveClosing_repo.Add(model);
            return new OkObjectResult(new { LeaveClosingID = model.LeaveClosingId });
        }

        [HttpPut("UpdateLeaveClosing", Name = "UpdateLeaveClosing")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveClosing([FromBody]LeaveClosing model)
        {
            LeaveClosing_repo.Update(model);
            return new OkObjectResult(new { LeaveClosingID = model.LeaveClosingId });
        }

        [HttpDelete("DeleteLeaveClosing/{id}")]
        public IActionResult DeleteLeaveClosing(long id)
        {
            LeaveClosing a = LeaveClosing_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeaveClosing_repo.Delete(a);
            return Ok();
        }

        #endregion
    }
}