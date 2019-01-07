using ErpCore.Entities.FinanceSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.Finance
{
    public class TransactionAccount : BaseClass
    {
        [Key]
        public long TransactionAccountId { get; set; }

        public long? AccountId { get; set; } //Transferred from Accounts table on year end process. Useful for accurate history as accountId holds

        public long? FinancialYearId { get; set; } //Same as the FinancialYearId in Account

        public string AccountCode { get; set; } //AutoGenerate based on Parent Account
        public string ParentAccountCode { get; set; } //SaveWhenAddingNewAccount
        public long? AccountLevel { get; set; }
        public string Description { get; set; }

        public long? TotalTransactionsAgainstThisAccount { get; set; }
        public double? OpeningBalance { get; set; } //Only for detail accounts
        public double? TotalCredit { get; set; }
        public double? TotalDebit { get; set; }
        public double? CurrentBalance { get; set; } // Update when day end process is run i.e. All the vouchers are posted.
    }
}
