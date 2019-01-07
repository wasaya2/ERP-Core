using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class FlagEffectType : BaseClass
    {
        public FlagEffectType()
        {
            AttendanceFlags = new HashSet<AttendanceFlag>();
        }

        [Key]
        public long FlagEffectTypeId { get; set; }
        public string Name { get; set; }
        public double? Value { get; set; }

        public IEnumerable<AttendanceFlag> AttendanceFlags { get; set; }
    }
}
