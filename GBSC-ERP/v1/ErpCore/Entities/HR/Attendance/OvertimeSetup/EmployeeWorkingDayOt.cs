using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.OvertimeSetup
{
    public class EmployeeWorkingDayOt : BaseClass
    {
        [Key]
        public long EmployeeWorkingDayOtId { get; set; }

        public bool? IsIncludeOtWorking { get; set; }
        public double? WokingOtHours { get; set; }

        public long? OverTimeTypeId { get; set; }
        public OverTimeType OverTimeType { get; set; }

        public long? EmployeeOverTimeEntitlementId { get; set; }
        public EmployeeOverTimeEntitlement EmployeeOverTimeEntitlement { get; set; }
    }
}
