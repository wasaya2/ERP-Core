using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class PfPayment : BaseClass
    {
        public PfPayment()
        {
            MonthlyUserSalaries = new HashSet<MonthlyUserSalary>();
        }

        [Key]
        public long PfPaymentId { get; set; }
        public bool? IsEmployerContribution { get; set; }
        public bool? IsEmployeeContribution { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? LastAddedDate { get; set; }

        public double? LastestEmployeePfContribution { get; set; } //Update with every payslip
        public double? TotalEmployeePfContribution { get; set; } // Latest + Total
        public double? LatestEmployerPfContribution { get; set; } //Calcule as %age from FundSetup from LastestEmployeePfContribution
        public double? TotalEmployerPfContribution { get; set; } //Lastest + total

        public double? LastestTotalPfAmount { get; set; } //total employee + total employer

        public IEnumerable<MonthlyUserSalary> MonthlyUserSalaries { get; set; }

        public long? LeavingReasonId { get; set; }
        public LeavingReason LeavingReason { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? FundSetupId { get; set; }
        public FundSetup FundSetup { get; set; }
    }
}
