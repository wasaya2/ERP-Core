using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class SalaryStructure : BaseClass
    {
        public SalaryStructure()
        {
            SalaryStructureDetails = new HashSet<SalaryStructureDetail>();
        }

        [Key]
        public long SalaryStructureId { get; set; }
        public string Title { get; set; }

        public bool? IsHourlyPay { get; set; } //Monthly or hourly pay
        public double? PerHourPay { get; set; }

        public double? MinimumSalary { get; set; } //PerMonth BaseSalary
        public double? MaximumSalary { get; set; } //PerMonth baseSalary

        public long? GroupId { get; set; }
        public Group Group { get; set; }
        
        public long? PayrollTypeId { get; set; }
        public PayrollType PayrollType { get; set; }

        public IEnumerable<SalaryStructureDetail> SalaryStructureDetails { get; set; }
    }
}
