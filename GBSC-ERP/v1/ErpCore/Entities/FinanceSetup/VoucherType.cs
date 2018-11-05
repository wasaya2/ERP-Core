using ErpCore.Entities.Finance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.FinanceSetup
{
    public class VoucherType : BaseClass
    {
        public VoucherType()
        {
            Vouchers = new HashSet<Voucher>();
        }

        [Key]
        public long VoucherTypeId { get; set; }
        public string VoucherCode { get; set; }
        public string Name { get; set; }

        public IEnumerable<Voucher> Vouchers { get; set; }
    }
}
