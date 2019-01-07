using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class FlagType : BaseClass
    {
        public FlagType()
        {
            AttendanceFlags = new HashSet<AttendanceFlag>();
            ShiftAttendanceFlags = new HashSet<ShiftAttendanceFlag>();
        }

        [Key]
        public long FlagTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<AttendanceFlag> AttendanceFlags { get; set; }
        public IEnumerable<ShiftAttendanceFlag> ShiftAttendanceFlags { get; set; }
    }
}
