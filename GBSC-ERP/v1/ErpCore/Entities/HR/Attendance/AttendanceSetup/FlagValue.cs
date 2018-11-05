using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class FlagValue : BaseClass
    {
        public FlagValue()
        {
            AttendanceFlags = new HashSet<AttendanceFlag>();
        }

        [Key]
        public long FlagValueId { get; set; }
        public double? Value { get; set; }
        public string Name { get; set; }

        public IEnumerable<AttendanceFlag> AttendanceFlags { get; set; }
    }
}
