using ErpCore.Entities.HR.Payroll.PayrollSetup;
using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.TaxSetup
{
    public class TaxableIncomeAdjustment : BaseClass
    {
        [Key]
        public long TaxableIncomeAdjustmentId { get; set; }

        public double? AddAmount { get; set; }
        public double? DeductAmount { get; set; }
        public string Remarks { get; set; }

        public string FilePath { get; set; }
        public string FileName { get; set; }

        public long? GroupId { get; set; }
        public Group Group { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }

        public long? PayrollTypeId { get; set; }
        public PayrollType PayrollType { get; set; }

        public long? TaxAdjustmentReasonId { get; set; }
        public TaxAdjustmentReason TaxAdjustmentReason { get; set; }
    }
}
