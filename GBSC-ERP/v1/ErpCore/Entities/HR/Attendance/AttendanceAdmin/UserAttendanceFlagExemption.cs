using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceAdmin
{
    public class UserAttendanceFlagExemption
    {
        public long? AttendanceFlagExemptionId { get; set; }
        public AttendanceFlagExemption AttendanceFlagExemption { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
