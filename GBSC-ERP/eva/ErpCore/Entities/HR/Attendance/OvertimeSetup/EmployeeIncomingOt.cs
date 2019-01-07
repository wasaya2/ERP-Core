using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.OvertimeSetup
{
    public class EmployeeIncomingOt : BaseClass
    {
        [Key]
        public long EmployeeIncomingOtId { get; set; }

        public bool? IsIncludeOtIncoming { get; set; }
        public double? IncomingOtHours { get; set; }

        public long? OverTimeTypeId { get; set; }
        public OverTimeType OverTimeType { get; set; }

        public long? EmployeeOverTimeEntitlementId { get; set; }
        public EmployeeOverTimeEntitlement EmployeeOverTimeEntitlement { get; set; }
    }
}
