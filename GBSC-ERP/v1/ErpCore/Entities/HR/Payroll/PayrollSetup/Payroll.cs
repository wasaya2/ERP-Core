using ErpCore.Entities.HR.Payroll;
using ErpCore.Entities.HR.Payroll.PayrollSetup;
using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class Payroll : BaseClass
    {
        public Payroll()
        {
            MonthlyUserSalaries = new HashSet<MonthlyUserSalary>();
        }

        [Key]
        public long PayrollId { get; set; }
        public double? MonthlySalary { get; set; }
        public double? HourlySalary { get; set; }
        public string IncrementInterval { get; set; }
        public double? IncrementPercentage { get; set; }
        
        public IEnumerable<MonthlyUserSalary> MonthlyUserSalaries { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? MasterPayrollId { get; set; }
        public MasterPayroll MasterPayroll { get; set; }
    }
}
