using ErpCore.Entities.FinanceSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.Finance
{
    public class ProcessedAccountsLedger : BaseClass
    {
        [Key]
        public long ProcessedAccountsLedgerId { get; set; }

        public long? AccountId { get; set; } //Transferred from Accounts table on year end process. Useful for accurate history as accountId holds

        public long? FinancialYearId { get; set; }  //Same as the FinancialYearId in Account

        public string AccountCode { get; set; } //AutoGenerate based on Parent Account
        public string ParentAccountCode { get; set; } //SaveWhenAddingNewAccount
        public bool? IsGeneralOrDetail { get; set; } //True for General, False for Detail
        public long? AccountLevel { get; set; } //AutoGenerate based on Parent account
        public string Description { get; set; }

        public bool? IsBankAccount { get; set; }

        public double? OpeningBalance { get; set; } //Only for detail accounts
        public double? TotalCredit { get; set; }
        public double? TotalDebit { get; set; }
        public double? ClosingBalance { get; set; } // Update when year end process is run

        //public bool? IsBankAccount { get; set; } //True if this is a detail account and a bank account
    }
}
