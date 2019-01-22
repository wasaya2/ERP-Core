using ErpCore.Entities.Finance;
using ErpCore.Entities.FinanceSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceService.ViewModels
{
    public class UnpostedVoucherViewModel
    {
        public long? UnpostedVoucherId { get; set; }

        public long? CompanyId { get; set; }
        public long VoucherId { get; set; }
        public string VoucherCode { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }

        public double? TotalCreditAmount { get; set; }
        public double? TotalDebitAmount { get; set; }

        public long? FinancialYearId { get; set; } //Same as FinancialYearID in Voucher
        public FinancialYear FinancialYear { get; set; }

        public long? VoucherTypeId { get; set; }
        public VoucherType VoucherType { get; set; }

        public IEnumerable<VoucherDetail> VoucherDetails { get; set; }

        public bool? Posted { get; set; }
    }
}
