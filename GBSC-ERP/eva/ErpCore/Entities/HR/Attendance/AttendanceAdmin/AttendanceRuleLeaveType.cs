using ErpCore.Entities.HR.Leave.LeaveSetup;
using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceAdmin
{
    public class AttendanceRuleLeaveType : BaseClass
    {
        public long? AttendanceRuleId { get; set; }
        public AttendanceRule AttendanceRule { get; set; }

        public long? LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}
