using ErpCore.Entities.FinanceSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.Finance
{
    public class PostedVoucher : BaseClass
    {
        [Key]
        public long PostedVoucherId { get; set; }

        public long VoucherId { get; set; }
        public string VoucherCode { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }

        public double? TotalCreditAmount { get; set; }
        public double? TotalDebitAmount { get; set; }

        public long? FinancialYearId { get; set; } //Same as FinancialYearID in Voucher
        public long? VoucherTypeId { get; set; }
    }
}
