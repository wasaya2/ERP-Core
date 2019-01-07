using ErpCore.Entities.HR.Payroll.PayrollSetup;
using ErpCore.Entities.HR.Payroll.TaxSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR
{
    public class TaxAdjustment :BaseClass
    {
        [Key]
        public long TaxAdjustmentId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string AdjustmentType { get; set; } //Percentage or Amount
        public double? InvestmentAmount { get; set; }
        public string Remarks { get; set; }

        public string FilePath { get; set; }
        public string FileName { get; set; }
        
        public long? TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? TaxAdjustmentReasonId { get; set; }
        public TaxAdjustmentReason TaxAdjustmentReason { get; set; }

        public long? PayrollTypeId { get; set; }
        public PayrollType PayrollType { get; set; }
    }
}
