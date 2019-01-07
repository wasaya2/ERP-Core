using ErpCore.Entities.HR.Payroll.PayrollAdmin;
using ErpCore.Entities.HR.Payroll.TaxSetup;
using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class UserSalary : BaseClass
    {
        public UserSalary()
        {
            MonthlyUserSalaries = new HashSet<MonthlyUserSalary>();
        }

        [Key]
        public long UserSalaryId { get; set; }
        public double? Salary { get; set; }

        public DateTime? SalaryDate { get; set; }
        public DateTime? SalaryMonth { get; set; }
        public DateTime? SalaryYear { get; set; }

        public IEnumerable<MonthlyUserSalary> MonthlyUserSalaries { get; set; }

        public long? IncomeTaxRuleId { get; set; } //Applicable on PayrollYear
        public IncomeTaxRule IncomeTaxRule { get; set; }

        public long? GroupId { get; set; } //Get Attendance from UserShifts in Rota and Basic Salary Structure with Allowances and Benefits
        public Group Group { get; set; } //Also get basic salary to be used to calculate gratuity.

        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
