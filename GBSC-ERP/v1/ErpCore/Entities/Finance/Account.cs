using ErpCore.Entities.FinanceSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.Finance
{
    public class Account : BaseClass
    {
        public Account()
        {
            VoucherDetails = new HashSet<VoucherDetail>();
        }

        [Key]
        public long AccountId { get; set; }
        public string AccountCode { get; set; } //AutoGenerate based on Parent Account
        public string ParentAccountCode { get; set; } //SaveWhenAddingNewAccount
        public bool? IsGeneralOrDetail { get; set; } //True for General, False for Detail
        public long? AccountLevel { get; set; } //AutoGenerate based on Parent account
        public string Description { get; set; }
        public double? OpeningBalance { get; set; } //Only for detail accounts
        public double? CurrentBalance { get; set; } // Update when day end process is run

        public bool? IsBankAccount { get; set; } //True if this is a detail account and a bank account

        public long? FinancialYearId { get; set; }
        public FinancialYear FinancialYear { get; set; }

        public IEnumerable<VoucherDetail> VoucherDetails { get; set; }
    }
}
