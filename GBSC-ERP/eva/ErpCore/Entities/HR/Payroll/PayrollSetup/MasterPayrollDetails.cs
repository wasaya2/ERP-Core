using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class MasterPayrollDetails : BaseClass
    {
        [Key]
        public long MasterPayrollDetailsId { get; set; }
        public double Value { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }

        public long? AllowanceId { get; set; }
        public Allowance Allowance { get; set; }

        public long? FrequencyId { get; set; }
        public Frequency Frequency { get; set; }

        public long? PayrollTypeId { get; set; }
        public PayrollType PayrollType { get; set; }
    }
}
