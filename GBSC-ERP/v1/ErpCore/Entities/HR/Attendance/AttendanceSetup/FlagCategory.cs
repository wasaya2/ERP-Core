using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class FlagCategory : BaseClass
    {
        public FlagCategory()
        {
            AttendanceFlags = new HashSet<AttendanceFlag>();
        }

        [Key]
        public long FlagCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<AttendanceFlag> AttendanceFlags { get; set; }
    }
}
