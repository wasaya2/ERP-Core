using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class AttendanceRequestApprover : BaseClass
    {
        public AttendanceRequestApprover()
        {
            AttendanceRequests = new HashSet<AttendanceRequest>();
        }

        [Key]
        public long AttendanceRequestApproverId { get; set; }
        public string Name { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<AttendanceRequest> AttendanceRequests { get; set; }
    }
}
