using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class BankAdviceTemplate : BaseClass
    {
        public BankAdviceTemplate()
        {
            PayrollBanks = new HashSet<PayrollBank>();
        }

        [Key]
        public long BankAdviceTemplateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<PayrollBank> PayrollBanks { get; set; }
    }
}
