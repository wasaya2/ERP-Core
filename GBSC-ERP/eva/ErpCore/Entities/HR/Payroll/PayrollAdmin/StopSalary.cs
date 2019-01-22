using ErpCore.Entities.HR.Payroll.PayrollSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollAdmin
{
    public class StopSalary : BaseClass
    {
        public StopSalary()
        {
            MonthlyUserSalaries = new HashSet<MonthlyUserSalary>();
            UserStopSalaries = new HashSet<UserStopSalary>();
        }

        [Key]
        public long StopSalaryId { get; set; }

        public string Action { get; set; } //Stop or Terminate
        public DateTime? From { get; set; }
        public DateTime? Till { get; set; }
        public string Remarks { get; set; }

        public long? PayrollTypeId { get; set; }
        public PayrollType PayrollType { get; set; }

        public IEnumerable<MonthlyUserSalary> MonthlyUserSalaries { get; set; }
        public IEnumerable<UserStopSalary> UserStopSalaries { get; set; }
    }
}
