using ErpCore.Entities.HR.Attendance.AttendanceSetup;
using ErpCore.Entities.HR.Leave.LeaveAdmin;
using ErpCore.Entities.HR.Payroll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance
{
    public class UserRosterAttendance : BaseClass
    {
        public UserRosterAttendance()
        {
            OfficialVisitEntries = new HashSet<OfficialVisitEntry>();
            UserRosterAttendanceAttendanceFlags = new HashSet<UserRosterAttendanceAttendanceFlag>();
        }

        [Key]
        public long UserRosterAttendanceId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public bool? IsPresent { get; set; }
        public bool? IsOnLeave { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public double? HoursWorked { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? AssignRosterId { get; set; }
        public AssignRoster AssignRoster { get; set; }

        public long? MonthlyUserSalaryId { get; set; }
        public MonthlyUserSalary MonthlyUserSalary { get; set; }
        
        public long? LeavePolicyEmployeeId { get; set; }
        public LeavePolicyEmployee LeavePolicyEmployee { get; set; }

        public IEnumerable<OfficialVisitEntry> OfficialVisitEntries { get; set; }
        public IEnumerable<UserRosterAttendanceAttendanceFlag> UserRosterAttendanceAttendanceFlags { get; set; }
    }
}
