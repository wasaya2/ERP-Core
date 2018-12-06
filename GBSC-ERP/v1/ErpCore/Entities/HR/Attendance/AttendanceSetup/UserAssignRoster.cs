using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class UserAssignRoster
    {
        public long? UserId { get; set; }
        public User User { get; set; }

        public long? AssignRosterId { get; set; }
        public AssignRoster AssignRoster { get; set; }

    }
}
