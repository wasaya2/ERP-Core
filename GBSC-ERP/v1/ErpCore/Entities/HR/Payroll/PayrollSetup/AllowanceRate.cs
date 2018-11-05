using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class AllowanceRate : BaseClass
    {
        [Key]
        public long AllowanceRateId { get; set; }
        public long? AllowanceRateValue { get; set; }
        public DateTime? EffectiveDate { get; set; }

        public long? AllowanceId { get; set; }
        public Allowance Allowance { get; set; }
    }
}
