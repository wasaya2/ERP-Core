using ErpCore.Entities.HR.Payroll.PayrollSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.TaxSetup
{
    public class IncomeTaxRule : BaseClass
    {
        public IncomeTaxRule()
        {
            TaxSchedules = new HashSet<TaxSchedule>();
            TaxReliefs = new HashSet<TaxRelief>();
            UserSalaries = new HashSet<UserSalary>();
        }

        [Key]
        public long IncomeTaxRuleId { get; set; }

        public string PersonalExemption { get; set; }
        public double? TaxLimit { get; set; }
        public double? AgeLimit { get; set; }
        public double? ExemptPercentage { get; set; }
        public double? TaxRebatePercentage { get; set; }
        public double? TaxRebateAmount { get; set; }

        public long? PayrollYearId { get; set; }
        public PayrollYear PayrollYear { get; set; }

        public IEnumerable<UserSalary> UserSalaries { get; set; }
        public IEnumerable<TaxSchedule> TaxSchedules { get; set; }
        public IEnumerable<TaxRelief> TaxReliefs { get; set; }
    }
}
