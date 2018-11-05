using ErpCore.Entities.HR.Attendance.OvertimeSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance
{
    public class OverTimeEntitlement : BaseClass
    { 
        [Key]
        public long OverTimeEntitlementId { get; set; }
        public DateTime? EffectiveDate { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? OverTimeTypeId { get; set; }
        public OverTimeType OverTimeType { get; set; }
    }
}
