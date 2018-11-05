using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.FinanceSetup
{
    public class MasterAccount : BaseClass
    {
        public MasterAccount()
        {
            SubAccounts = new HashSet<SubAccount>();
        }

        [Key]
        public long MasterAccountId { get; set; }
        public string MasterAccountCode { get; set; }
        public string Name { get; set; }

        public IEnumerable<SubAccount> SubAccounts { get; set; }
    }
}
