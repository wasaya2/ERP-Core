using ErpCore.Entities.HR.Payroll.TaxSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class Benefit : BaseClass
    {
        public Benefit()
        {
            TaxBenefits = new HashSet<TaxBenefit>();
            MasterPayrollDetails = new HashSet<MasterPayrollDetails>();
            SalaryStructureDetails = new HashSet<SalaryStructureDetail>();
        }

        [Key]
        public long BenefitId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<TaxBenefit> TaxBenefits { get; set; }
        public IEnumerable<MasterPayrollDetails> MasterPayrollDetails { get; set; }
        public IEnumerable<SalaryStructureDetail> SalaryStructureDetails { get; set; }
    }
}
