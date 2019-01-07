
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.TaxSetup
{
    public class TaxAdjustmentReason : BaseClass
    {
        public TaxAdjustmentReason()
        {
            TaxAdjustments = new HashSet<TaxAdjustment>();
            TaxableIncomeAdjustments = new HashSet<TaxableIncomeAdjustment>();
        }

        [Key]
        public long taxAdjustmentReasonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public IEnumerable<TaxAdjustment> TaxAdjustments { get; set; }
        public IEnumerable<TaxableIncomeAdjustment> TaxableIncomeAdjustments { get; set; }
    }
}
