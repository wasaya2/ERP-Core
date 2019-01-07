using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class Roster : BaseClass
    {
        public Roster()
        {
            AssignRosters = new HashSet<AssignRoster>();
        }

        [Key]
        public long RosterId { get; set; }
        public string Name { get; set; }

        public IEnumerable<AssignRoster> AssignRosters { get; set; }
    }
}
