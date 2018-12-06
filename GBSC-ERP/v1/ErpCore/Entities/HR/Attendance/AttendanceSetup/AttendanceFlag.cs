using ErpCore.Entities.HR.Attendance.AttendanceAdmin;
using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class AttendanceFlag : BaseClass
    {
        public AttendanceFlag()
        {
            AttendanceRules = new HashSet<AttendanceRule>();
            UserRosterAttendanceAttendanceFlags = new HashSet<UserRosterAttendanceAttendanceFlag>();
            AttendanceFlagExemptions = new HashSet<AttendanceFlagExemption>();
            ShiftAttendanceFlags = new HashSet<ShiftAttendanceFlag>();
        }

        [Key]
        public long AttendanceFlagId { get; set; }
        public string Title { get; set; } 
        //public string EffectedBy { get; set; } //Count(Days) or Hours 
        public string FlagDayType { get; set; } //FullDay or HalfDay
        public bool? IsActive { get; set; }

        public long? FlagValueId { get; set; }
        public FlagValue FlagValue { get; set; }

        public long? FlagCategoryId { get; set; }
        public FlagCategory FlagCategory { get; set; }

        public long? FlagTypeId { get; set; }
        public FlagType FlagType { get; set; }

        public long? FlagEffectTypeId { get; set; }
        public FlagEffectType FlagEffectType { get; set; }

        public IEnumerable<AttendanceRule> AttendanceRules { get; set; }
        public IEnumerable<UserRosterAttendanceAttendanceFlag> UserRosterAttendanceAttendanceFlags { get; set; }
        public IEnumerable<AttendanceFlagExemption> AttendanceFlagExemptions { get; set; }
        public IEnumerable<ShiftAttendanceFlag> ShiftAttendanceFlags { get; set; }
    }
}
