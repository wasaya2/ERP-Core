using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class SalaryStructureDetail : BaseClass
    {
        [Key]
        public long SalaryStructureDetailId { get; set; }

        public double? Value { get; set; } //if calculation is %age then show this
        public string Formula { get; set; } //if calculation is formula, then save in this

        public long? SalaryCalculationTypeId { get; set; }
        public SalaryCalculationType SalaryCalculationType { get; set; }

        public bool? IsAllowanceOrBenefit { get; set; }

        public long? BenefitId { get; set; }
        public Benefit Benefit { get; set; }

        public long? AllowanceDeductionId { get; set; }
        public AllowanceDeduction AllowanceDeduction { get; set; }

        public long? SalaryStructureId { get; set; }
        public SalaryStructure SalaryStructure { get; set; }
    }
}
