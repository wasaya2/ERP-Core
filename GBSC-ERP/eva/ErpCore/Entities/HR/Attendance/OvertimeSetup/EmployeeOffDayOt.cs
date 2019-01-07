using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.OvertimeSetup
{
    public class EmployeeOffDayOt : BaseClass
    {
        [Key]
        public long EmployeeOffDayOtId { get; set; }

        public bool? IsIncludeOtOff { get; set; }
        public double? OffOtHours { get; set; }

        public long? OverTimeTypeId { get; set; }
        public OverTimeType OverTimeType { get; set; }

        public long? EmployeeOverTimeEntitlementId { get; set; }
        public EmployeeOverTimeEntitlement EmployeeOverTimeEntitlement { get; set; }
    }
}
