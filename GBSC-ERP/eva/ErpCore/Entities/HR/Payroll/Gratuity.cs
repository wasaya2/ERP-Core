using ErpCore.Entities.HR.Payroll.PayrollSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll
{
    public class Gratuity : BaseClass
    {   //Calculate Gratuity based on total slary earned or by slabs. Choose one.
        public Gratuity()
        {
            UserSalaries = new HashSet<UserSalary>();
            GratuitySlabGratuities = new HashSet<GratuitySlabGratuity>();
        }

        [Key]
        public long UserGratuityId { get; set; }
        public double? TotalSalary { get; set; } //Add all user salaries from userSalary and save here
        public double? GratuityAmount { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public DateTime? From { get; set; } //Employment from to
        public DateTime? To { get; set; }

        public long? GratuityTypeId { get; set; }
        public GratuityType GratuityType { get; set; } //Pay gratuity based on total base salary or lastest base salary

        public long? LeavingReasonId { get; set; }
        public LeavingReason LeavingReason { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? FundSetupId { get; set; } //Get minimum Gratuity service period from here and check against From - To dates
        public FundSetup FundSetup { get; set; } //to see if employee is eligible for Gratuity

        public IEnumerable<UserSalary> UserSalaries { get; set; }
        public IEnumerable<GratuitySlabGratuity> GratuitySlabGratuities { get; set; }
    }
}
