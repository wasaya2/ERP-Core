using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.FinanceSetup
{
    public class SubAccount : BaseClass
    {
        public SubAccount()
        {
            SecondSubAccounts = new HashSet<SecondSubAccount>();
        }

        [Key]
        public long SubAccountId { get; set; }
        public string SubAccountCode { get; set; }
        public string Name { get; set; }

        public long? MasterAccountId { get; set; }
        public MasterAccount MasterAccount { get; set; }

        public IEnumerable<SecondSubAccount> SecondSubAccounts { get; set; }
    }
}
