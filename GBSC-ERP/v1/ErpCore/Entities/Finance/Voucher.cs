using ErpCore.Entities.FinanceSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.Finance
{
    public class Voucher : BaseClass
    {
        public Voucher()
        {
            VoucherDetails = new HashSet<VoucherDetail>();
        }

        [Key]
        public long VoucherId { get; set; }
        public string VoucherCode { get; set; }
        public DateTime? Date { get; set; }
        public string ChequeNumber { get; set; }
        public string Description { get; set; }

        public double? TotalCreditAmount { get; set; }
        public double? TotalDebitAmount { get; set; }

        public bool? IsFinal { get; set; } //Can't be updated once true

        public long? FinancialYearId { get; set; }
        public FinancialYear FinancialYear { get; set; }

        //public long? DepartmentId { get; set; }
        //public Department Department { get; set; }

        public long? VoucherTypeId { get; set; }
        public VoucherType VoucherType { get; set; }

        public IEnumerable<VoucherDetail> VoucherDetails { get; set; }
    }
}
