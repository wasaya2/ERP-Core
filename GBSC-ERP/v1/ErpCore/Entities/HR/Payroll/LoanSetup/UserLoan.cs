using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.LoanSetup
{
    public class UserLoan : BaseClass
    {
        public UserLoan()
        {
            UserLoanPayslips = new HashSet<UserLoanPayslip>();
        }

        [Key]
        public long UserLoanId { get; set; }
        public double? Amount { get; set; }
        public double? Installment { get; set; } //PerMonth
        public double? PaidTillNow { get; set; } //updated with every payslip
        public double? AmountLeft { get; set; }
        public double? LastPaidAmount { get; set; }
        public double? DeductionPercent { get; set; } //% of salary after taxes and everything
        public DateTime? StartMonth { get; set; }
        public DateTime? EndMonth { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public bool? IsPaid { get; set; }

        public bool? IsLoanStop { get; set; }
        public DateTime? LoanStopFrom { get; set; }
        public DateTime? LoanStopTill { get; set; }

        public long? LoanTypeId { get; set; }
        public LoanType LoanType { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<UserLoanPayslip> UserLoanPayslips { get; set; }
    }
}
