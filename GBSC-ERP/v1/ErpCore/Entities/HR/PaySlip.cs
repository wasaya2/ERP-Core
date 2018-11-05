using ErpCore.Entities.HR.Payroll;
using ErpCore.Entities.HR.Payroll.LoanSetup;
using ErpCore.Entities.HR.Payroll.PayrollSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR
{
    public class PaySlip : BaseClass
    {
        public PaySlip()
        {
            UserLoanPayslips = new HashSet<UserLoanPayslip>();
        }

        [Key]
        public long PaySlipid { get; set; }
        public DateTime? From { get; set; }
        public DateTime? Till { get; set; }
        public DateTime? PaymentDate { get; set; }
        public double? Hours { get; set; }
        public double? Days { get; set; }
        public double? GrossAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? PfDeductionAmount { get; set; }
        public double? LoanDeductionAmount { get; set; } //From UserLoanPayslip
        public double? NetAmount { get; set; }


        public long? MonthlyUserSalaryId { get; set; }
        public MonthlyUserSalary MonthlyUserSalary { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<UserLoanPayslip> UserLoanPayslips { get; set; }
    }
}
