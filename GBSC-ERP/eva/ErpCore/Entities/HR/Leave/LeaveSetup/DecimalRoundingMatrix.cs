using ErpCore.Entities.HR.Leave.LeaveAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave.LeaveSetup
{
    public class DecimalRoundingMatrix : BaseClass
    {
        [Key]
        public long DecimalRoundingMatrixId { get; set; }
        public double? FromRange { get; set; }
        public double? TillRange { get; set; }
        public double? Effect { get; set; }

        public long? LeavePolicyId { get; set; }
        public LeavePolicy LeavePolicy { get; set; }

        public long? LeavePolicyEmployeeId { get; set; }
        public LeavePolicyEmployee LeavePolicyEmployee { get; set; }
    }
}
