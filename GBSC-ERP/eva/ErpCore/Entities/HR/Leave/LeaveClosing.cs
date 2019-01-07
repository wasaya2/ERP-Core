using ErpCore.Entities.HR.Leave.LeaveSetup;
using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave
{
    public class LeaveClosing : BaseClass
    {
        public LeaveClosing()
        {
            LeaveApprovals = new HashSet<LeaveApproval>();
        }

        [Key]
        public long LeaveClosingId { get; set; }

        public long? LeaveYearId { get; set; }
        public LeaveYear LeaveYear { get; set; }

        public long? DepartmentId { get; set; }
        public Department Department { get; set; }

        public long? GroupId { get; set; }
        public Group Group { get; set; }
        
        public IEnumerable<LeaveApproval> LeaveApprovals { get; set; }
    }
}
