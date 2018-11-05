using ErpCore.Entities.HR.Attendance.AttendanceSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance
{
    public class AttendanceRequest : BaseClass
    {
        [Key]
        public long AttendanceRequestId { get; set; }
        public DateTime? RequestDate { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsSubmitted { get; set; }
        public bool? IsRejected { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? AttendanceRequestTypeId { get; set; }
        public AttendanceRequestType AttendanceRequestType { get; set; }

        public long? AssignRosterId { get; set; }
        public AssignRoster AssignRoster { get; set; }

        public long? AttendanceRequestApproverId { get; set; }
        public AttendanceRequestApprover AttendanceRequestApprover { get; set; }
    }
}
