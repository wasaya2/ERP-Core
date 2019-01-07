using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.LoanSetup
{
    public class LoanType : BaseClass
    {
        public LoanType()
        {
            UserLoans = new HashSet<UserLoan>();
        }

        [Key]
        public long LoanTypeId { get; set; }
        public string Name { get; set; }
        public double? MinAmount { get; set; }
        public double? MaxAmount { get; set; }
        public long? MinPaymentPeriod { get; set; }
        public long? MaxPaymentPeriod { get; set; }
        public double? MinInstallment { get; set; }
        public double? MaxInstallment { get; set; }

        public IEnumerable<UserLoan> UserLoans { get; set; }
    }
}
