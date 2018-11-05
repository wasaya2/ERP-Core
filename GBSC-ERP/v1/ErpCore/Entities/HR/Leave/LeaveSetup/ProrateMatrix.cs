using ErpCore.Entities.HR.Leave.LeaveAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave.LeaveSetup
{
    public class ProrateMatrix : BaseClass
    {
        [Key]
        public long ProrateMatrixId { get; set; }
        public double? From { get; set; } //InDays
        public double? Till { get; set; } //InDays
        public double? Percentage { get; set; }

        public long? LeavePolicyId { get; set; }
        public LeavePolicy LeavePolicy { get; set; }

        public long? LeavePolicyEmployeeId { get; set; }
        public LeavePolicyEmployee LeavePolicyEmployee { get; set; }
    }
}
