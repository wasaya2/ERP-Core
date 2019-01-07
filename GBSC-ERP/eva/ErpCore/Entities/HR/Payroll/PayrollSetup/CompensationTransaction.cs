using ErpCore.Entities.HR.Payroll.PayrollSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class CompensationTransaction : BaseClass
    {
        [Key]
        public long CompensationTransactionId { get; set; }
        public double? Amount { get; set; }
        public string Remarks { get; set; }
        public DateTime? Month { get; set; }
        public bool? IsTaxableIncome { get; set; } //If no then deduct tax on transaction


        public long? PayrollyearId { get; set; }
        public PayrollYear PayrollYear { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? AllowanceId { get; set; }
        public Allowance Allowance { get; set; }
         
        public long? PayrollTypeId { get; set; }
        public PayrollType PayrollType { get; set; }
    }
}
