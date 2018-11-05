using ErpCore.Entities.HR.Leave.LeaveAdmin;
using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave
{
    public class LeaveRequest : BaseClass
    {
        public LeaveRequest()
        {
            LeaveRequestDetails = new HashSet<LeaveRequestDetail>();
        }

        [Key]
        public long LeaveRequestId { get; set; }
        public string LeaveRequestCode { get; set; }
        public DateTime? RequestDate { get; set; }
        public double? TotalLeaveValue { get; set; } //Add TotalLeaveDetailValue from all details and put here
        public string FilePath { get; set; }
        public string FileName { get; set; }

        public bool? IsApproved { get; set; } //True once the request is approved by approver, else rejected

        public long? LeaveApprovalId { get; set; }
        public LeaveApproval LeaveApproval { get; set; }

        public long? UserId { get; set; } //Check which leave opneing were approved for each user
        public User User { get; set; }

        public IEnumerable<LeaveRequestDetail> LeaveRequestDetails { get; set; }
         
        public long? LeaveOpeningId { get; set; } //Leave requested against which leave opening
        public LeaveOpening LeaveOpening { get; set; }
    }
}
