using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class Shift : BaseClass
    {
        public Shift()
        {
            AssignRosters = new HashSet<AssignRoster>();
            ShiftAttendanceFlags = new HashSet<ShiftAttendanceFlag>();
        }

        [Key]
        public long ShiftsId { get; set; }
        public string ShiftCode { get; set; } //AutoGenerate
        public string Duties { get; set; }
        public string Day { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Description { get; set; }

        public string ShiftTitle { get; set; }
        public DateTime? GraceTime { get; set; }
        public bool? IsMultiple { get; set; }
        public DateTime? OverTimeStartTime { get; set; } //HH:MM
        public double? MinimumOverTime { get; set; } //HH:MM
        public DateTime? InTimeShiftThreshold { get; set; } //Minutes
        public DateTime? OutTimeShiftThreshold { get; set; } //Minutes
        public double? ShiftHours { get; set; }
        public double? OverTimeRate { get; set; }

        public IEnumerable<ShiftAttendanceFlag> ShiftAttendanceFlags { get; set; }
        public IEnumerable<AssignRoster> AssignRosters { get; set; }
    }
}
