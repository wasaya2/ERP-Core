using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.FinanceSetup
{
    public class SecondSubAccount : BaseClass
    {
        public SecondSubAccount()
        {
            DetailAccounts = new HashSet<DetailAccount>();
        }

        [Key]
        public long SecondSubAccountId { get; set; }
        public string SecondSubAccountCode { get; set; }
        public string Name { get; set; }

        public long? SubAccountId { get; set; }
        public SubAccount SubAccount { get; set; }

        public IEnumerable<DetailAccount> DetailAccounts { get; set; }
    }
}
