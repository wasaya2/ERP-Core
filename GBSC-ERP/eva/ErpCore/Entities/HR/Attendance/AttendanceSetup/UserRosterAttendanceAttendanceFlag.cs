using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
   public class UserRosterAttendanceAttendanceFlag 
    {
        public long? AttendanceFlagId { get; set; }
        public AttendanceFlag AttendanceFlag { get; set; }

        public long? UserRosterAttendanceId { get; set; }
        public UserRosterAttendance UserRosterAttendance { get; set; }
    }
}
