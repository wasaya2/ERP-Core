using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class FundSetup : BaseClass
    {
        [Key]
        public long FundSetupId { get; set; }

        //PF
        public double? PfEmployerContribution { get; set; } //%age
        public double? PfEmployeeContribution { get; set; } //%age
        public double? TaxableAmountLimit { get; set; }

        //Gratuity
        public long? MinServicePeriod { get; set; }
        public string ApplicableFrom { get; set; } // Confirmation or Joining (Hardcode)

        //SESSI
        public double? SessiMinimumSalary { get; set; }
        public double? SessiEmployerContribution { get; set; }
        public double? SessiEmployeeContribution { get; set; }

        //PESSI
        public double? PessiMinimumSalary { get; set; }
        public double? PessiEmployerContribution { get; set; }
        public double? PessiEmployeeContribution { get; set; }

        //IESSI
        public double? IessiMinimumSalary { get; set; }
        public double? IessiEmployerContribution { get; set; }
        public double? IessiEmployeeContribution { get; set; }

        //EOBI
        public double? EobiMinimumSalary { get; set; }
        public double? EobiEmployerContribution { get; set; }
        public double? EobiEmployeeContribution { get; set; }
        public double? MaximumContribution { get; set; }
        public long? ExemptAge { get; set; }

        public long? PayrollYearId { get; set; }
        public PayrollYear PayrollYear { get; set; }
    }
}
