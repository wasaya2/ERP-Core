using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.OvertimeSetup
{
    public class EmployeeOutgoingOt : BaseClass
    {
        [Key]
        public long EmployeeOutgoingOtId { get; set; }

        public bool? IsIncludeOtOutgoing { get; set; }
        public double? OutgoingOtHours { get; set; }

        public long? OverTimeTypeId { get; set; }
        public OverTimeType OverTimeType { get; set; }

        public long? EmployeeOverTimeEntitlementId { get; set; }
        public EmployeeOverTimeEntitlement EmployeeOverTimeEntitlement { get; set; }
    }
}
