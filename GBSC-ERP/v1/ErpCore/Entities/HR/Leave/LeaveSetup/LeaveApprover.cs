using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave.LeaveSetup
{
    public class LeaveApprover : BaseClass
    {
        public LeaveApprover()
        {
            LeaveApprovals = new HashSet<LeaveApproval>();
        }

        [Key]
        public long LeaveApproverId { get; set; }
        public string Name { get; set; }
        public long? UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<LeaveApproval> LeaveApprovals { get; set; }
    }
}
