using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.Finance
{
    public class FinancePurchaseInvoiceDetail
    {
        [Key]
        public long FinancePurchaseInvoiceDetailId { get; set; }
        public string ItemDescription { get; set; }
        public double? Amount { get; set; }

        public long? FinancePurchaseInvoiceId { get; set; }
        public FinancePurchaseInvoice FinancePurchaseInvoice { get; set; }
    }
}
