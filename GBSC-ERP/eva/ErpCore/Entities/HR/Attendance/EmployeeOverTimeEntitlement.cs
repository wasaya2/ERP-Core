using ErpCore.Entities.HR.Attendance.OvertimeSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance
{
    public class EmployeeOverTimeEntitlement : BaseClass
    {
        [Key]
        public long EmployeeOverTimeEntitlementId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public long? EmployeeWorkingDayOtId { get; set; }
        public EmployeeWorkingDayOt EmployeeWorkingDayOt { get; set; }

        public long? EmployeeOffDayOtId { get; set; }
        public EmployeeOffDayOt EmployeeOffDayOt { get; set; }

        public long? EmployeeIncomingOtId { get; set; }
        public EmployeeIncomingOt EmployeeIncomingOt { get; set; }

        public long? EmployeeOutgoingOtId { get; set; }
        public EmployeeOutgoingOt EmployeeOutgoingOt { get; set; }
        
        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
