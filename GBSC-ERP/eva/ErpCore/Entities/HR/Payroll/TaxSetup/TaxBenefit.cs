using ErpCore.Entities.HR.Payroll.PayrollSetup;
using ErpCore.Entities.HR.Payroll.TaxSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.TaxSetup
{
    public class TaxBenefit : BaseClass
    {
        [Key]
        public long TaxBenefitId { get; set; }

        public DateTime? From { get; set; }
        public DateTime? Till { get; set; }
        public double? BaseAmount { get; set; }
        public double? Percentage { get; set; }
        public string Remarks { get; set; }
        public double? TaxableAmount { get; set; } //caluclate from base and percentage
        public double? PeriodTaxableAmount { get; set; } //calculate from somewhere

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public long? PayrollTypeId { get; set; }
        public PayrollType PayrollType { get; set; }

        public long? TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }

        public long? BenefitId { get; set; }
        public Benefit Benefit { get; set; }
    }
}
