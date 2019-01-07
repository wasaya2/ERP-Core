using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class AllowanceDeduction : BaseClass
    {
        public AllowanceDeduction()
        {
            Allowances = new HashSet<Allowance>();
        }

        [Key]
        public long AllowanceDeductionId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; } //Allowance or Deduction
        public double? FixedValue { get; set; }

        public string ValueExpressionPayment { get; set; }
        public string ValueExpressionPaymentFrom { get; set; } //Master Payroll or Monthly Payroll

        public string ValueExpressionForecast { get; set; }
        public string ValueExpressionForecastFrom { get; set; } //Master Payroll or Monthly Payroll

        public long? CalculationSequenceNumber { get; set; }
        public long? RepostNumber { get; set; }

        //Maybe select one from these three options so it should be a radio button? //public string IsProratedOrIsBaseAllowanceOrIsOneTimeAllowance {get;set;}
        public bool? IsProrated { get; set; }
        public bool? IsBaseAllowance { get; set; }
        public bool? IsOneTimeAllowance { get; set; }

        public string GlCodeAllowance { get; set; }
        public string GlCodeDeduction { get; set; }

        public string DefaultCostCenter { get; set; }
        public bool? IsGrossSalary { get; set; }

        public long? AllowanceCalculationTypeId { get; set; }
        public AllowanceCalculationType AllowanceCalculationType { get; set; }

        public IEnumerable<Allowance> Allowances { get; set; }
    }
}
