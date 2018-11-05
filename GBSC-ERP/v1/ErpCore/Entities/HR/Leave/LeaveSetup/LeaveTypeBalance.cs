using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave.LeaveSetup
{
    public class LeaveTypeBalance : BaseClass
    {
        [Key]
        public long LeaveTypeBalanceId { get; set; }
        public double? BalanceValue { get; set; }

        public long? LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
