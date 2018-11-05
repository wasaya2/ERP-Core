using ErpCore.Entities.HR.Attendance.AttendanceSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
    public class AssignRoster : BaseClass
    {
        public AssignRoster()
        {
            Users = new HashSet<User>();
            AssignRosterShifts = new HashSet<AssignRosterShift>();
            UserRosterAttendances = new HashSet<UserRosterAttendance>();
            AttendanceRequests = new HashSet<AttendanceRequest>();
        }

        [Key]
        public long AssignRosterId { get; set; }
        public string Description { get; set; }

        public bool? IsDefaultRoster { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        
        public long? RosterId { get; set; }
        public Roster Roster { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<AssignRosterShift> AssignRosterShifts { get; set; }
        public IEnumerable<UserRosterAttendance> UserRosterAttendances { get; set; }
        public IEnumerable<AttendanceRequest> AttendanceRequests { get; set; }
    }
}
