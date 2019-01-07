using ErpCore.Entities.HR.Leave;
using ErpCore.Entities.HR.Leave.LeaveAdmin;
using ErpCore.Entities.HR.Leave.LeaveSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave
{
    public class LeaveApproval : BaseClass
    {
        [Key]
        public long LeaveApprovalId { get; set; }
        public string Name { get; set; }
        public bool? IsApproved { get; set; }

        public long? LeaveRequestId { get; set; }
        public LeaveRequest LeaveRequest { get; set; }

        public long? LeaveApproverId { get; set; }
        public LeaveApprover LeaveApprover { get; set; }
    }
}
