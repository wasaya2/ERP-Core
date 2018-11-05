using ErpCore.Entities.HR.Payroll.PayrollAdmin;
using ErpCore.Entities.HR.Payroll.TaxSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class PayrollType : BaseClass
    {
        public PayrollType()
        {
            StopSalaries = new HashSet<StopSalary>();
            CompensationTransactions = new HashSet<CompensationTransaction>();
            MasterPayrollDetails = new HashSet<MasterPayrollDetails>();
            SalaryStructures = new HashSet<SalaryStructure>();
            TaxableIncomeAdjustments = new HashSet<TaxableIncomeAdjustment>();
            TaxBenefits = new HashSet<TaxBenefit>();
            TaxAdjustments = new HashSet<TaxAdjustment>();
        }

        [Key]
        public long PayrollTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<StopSalary> StopSalaries { get; set; }
        public IEnumerable<CompensationTransaction> CompensationTransactions { get; set; }
        public IEnumerable<MasterPayrollDetails> MasterPayrollDetails { get; set; }
        public IEnumerable<SalaryStructure> SalaryStructures { get; set; }
        public IEnumerable<TaxableIncomeAdjustment> TaxableIncomeAdjustments { get; set; }
        public IEnumerable<TaxBenefit> TaxBenefits { get; set; }
        public IEnumerable<TaxAdjustment> TaxAdjustments { get; set; }
    }
}
