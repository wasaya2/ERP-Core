using ErpCore.Entities.HR.Attendance;
using ErpCore.Entities.HR.Payroll.PayrollAdmin;
using ErpCore.Entities.HR.Payroll.PayrollSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll
{
    public class MonthlyUserSalary : BaseClass
    {
        public MonthlyUserSalary()
        {
            UserRosterAttendances = new HashSet<UserRosterAttendance>();
        }

        [Key]
        public long MonthlyUserSalaryId { get; set; }

        public DateTime? MonthStartDate { get; set; }
        public DateTime? MonthEndDate { get; set; }
        public long? TotalWorkingDaysInMonth { get; set; }
        public long? PresentDays { get; set; }
        public long? LeaveDays { get; set; }
        public long? AbsentDays { get; set; }
        public double? OvertimeHours { get; set; }

        public bool? IsStopped { get; set; }
        public DateTime? StopFrom { get; set; }
        public DateTime? StopTill { get; set; }

        public long? StopSalaryId { get; set; } //If salary for this month is stopped
        public StopSalary StopSalary { get; set; }

        public long? UserSalaryId { get; set; }
        public UserSalary UserSalary { get; set; }
        
        public long? PfPaymentId { get; set; }
        public PfPayment PfPayment { get; set; }

        public IEnumerable<UserRosterAttendance> UserRosterAttendances { get; set; } //DailyAttendance record

        public long? PayslipId { get; set; }
        public PaySlip PaySlip { get; set; }

        public long? PayrollId { get; set; }
        public ErpCore.Entities.HR.Payroll.PayrollSetup.Payroll Payroll { get; set; }
    }
}
