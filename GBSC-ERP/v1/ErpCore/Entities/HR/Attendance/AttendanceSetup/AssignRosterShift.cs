using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class AssignRosterShift : BaseClass
    {
        public long? AssignRosterId { get; set; }
        public AssignRoster AssignRoster { get; set; }

        public long? ShiftId { get; set; }
        public Shift Shift { get; set; }
    }
}
