using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ErpCore.Entities.HR.Payroll.TaxSetup
{
    public class TaxRelief : BaseClass
    {
        [Key]
        public long TaxReliefId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? Till { get; set; }
        public string TaxType { get; set; }//PercentageAmount
        public double? Value { get; set; }
        public string ApplicabaleTo { get; set; }//Male, Female or Both

        public long? IncomeTaxRuleId { get; set; }
        public IncomeTaxRule IncomeTaxRule { get; set; }
    }
}
