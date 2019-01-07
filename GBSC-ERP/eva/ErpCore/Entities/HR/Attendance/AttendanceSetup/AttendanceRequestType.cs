using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class AttendanceRequestType : BaseClass
    {
        public AttendanceRequestType()
        {
            AttendanceRequests = new HashSet<AttendanceRequest>();
        }

        [Key]
        public long AttendanceRequestTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<AttendanceRequest> AttendanceRequests { get; set; }
    }
}
