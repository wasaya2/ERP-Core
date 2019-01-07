using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class ShiftAttendanceFlag
    {
        [Key]
        public long ShiftAttendanceFlagId { get; set; } 
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public string NoOfHours { get; set; }

        public long? ShiftId { get; set; }
        public Shift Shift { get; set; }

        public long? AttendanceFlagId { get; set; }
        public AttendanceFlag AttendanceFlag { get; set; }

        public long? FlagTypeId { get; set; }
        public FlagType FlagType { get; set; }
    }
}
