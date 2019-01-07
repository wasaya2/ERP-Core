using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.LoanSetup
{
    public class UserLoanPayslip : BaseClass
    {
        public long? UserLoanId { get; set; }
        public UserLoan UserLoan { get; set; }

        public long? PayslipId { get; set; }
        public PaySlip PaySlip { get; set; }
    }
}
