using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance
{
    public class OfficialVisitEntry : BaseClass
    {
        [Key]
        public long OfficialVisitEntryId { get; set; }
        public string Remarks { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? UserRosterAttendanceId { get; set; }
        public UserRosterAttendance UserRosterAttendance { get; set; }
    }
}
