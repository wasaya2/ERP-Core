using ErpCore.Entities.HR.Attendance.AttendanceAdmin;
using ErpCore.Entities.HR.Leave;
using ErpCore.Entities.HR.Leave.LeaveSetup;
using ErpCore.Entities.HR.Payroll.PayrollSetup;
using ErpCore.Entities.HR.Payroll.TaxSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities.HRSetup
{
    public class Group : BaseClass
    {
        public Group()
        {
            Users = new HashSet<User>();
            LeavePolicies = new HashSet<LeavePolicy>();
            LeaveClosings = new HashSet<LeaveClosing>();
            AttendanceRules = new HashSet<AttendanceRule>();
            UserSalaries = new HashSet<UserSalary>();
            TaxableIncomeAdjustments = new HashSet<TaxableIncomeAdjustment>();
        }

        [Key]
        public long GroupId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ConfirmDueDays { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<LeavePolicy> LeavePolicies { get; set; }
        public IEnumerable<LeaveClosing> LeaveClosings { get; set; }
        public IEnumerable<AttendanceRule> AttendanceRules { get; set; }

        public long? SalaryStructureId { get; set; }
        public SalaryStructure SalaryStructure { get; set; }

        public IEnumerable<UserSalary> UserSalaries { get; set; }
        public IEnumerable<TaxableIncomeAdjustment> TaxableIncomeAdjustments { get; set; }
    }
}
