using ErpCore.Entities.FinanceSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.Finance
{
    public class VoucherDetail
    {
        [Key]
        public long VoucherDetailId { get; set; }

        public string DepartmentName { get; set; }
        public double? CreditAmount { get; set; }
        public double? DebitAmount { get; set; }
        public string UniqueName { get; set; }
        public string Description { get; set; }
        public string ChequeNUmber { get; set; }

        public long? DetailAccountId { get; set; }
        public DetailAccount DetailAccount { get; set; }

        public double? AccountBalanceAmountBeforePosting { get; set; }
        public double? AccountBalanceAmountAfterPosting { get; set; }

        public long? VoucherId { get; set; }
        public Voucher Voucher { get; set; }

        public long? AccountId { get; set; }
        public Account Account { get; set; }
    }
}
