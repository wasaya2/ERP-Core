using ErpCore.Entities.HR.Attendance.AttendanceSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceAdmin
{
    public class AttendanceFlagExemption : BaseClass
    {
        public AttendanceFlagExemption()
        {
            UserAttendanceFlagExemptions = new HashSet<UserAttendanceFlagExemption>();
        }

        [Key]
        public long AttendanceFlagExemptionId { get; set; }
        public DateTime? Date { get; set; }
        public string Remarks { get; set; }

        public long? AttendanceFlagId { get; set; }
        public AttendanceFlag AttendanceFlag { get; set; }

        public long? FlagTypeId { get; set; }
        public FlagType FlagType { get; set; }

        public IEnumerable<UserAttendanceFlagExemption> UserAttendanceFlagExemptions { get; set; }
    }
}
