using ErpCore.Entities.HR.Payroll.PayrollSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities.HRSetup
{
    public class Bank : BaseClass
    {
        public Bank()
        {
            MasterPayrolls = new HashSet<MasterPayroll>();
            PayrollBanks = new HashSet<PayrollBank>();
        }
        

        [Key]
        public long? BankId { get; set; }
        public string BankTitle { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingCode { get; set; }
        public string BankCode { get; set; }
        public string SwiftCode { get; set; }
        public string Branch { get; set; }
        public bool? IsActive { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<MasterPayroll> MasterPayrolls { get; set; }
        public IEnumerable<PayrollBank> PayrollBanks { get; set; }
    }
}
