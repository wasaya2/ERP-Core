using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.Finance
{
    public class FinanceSalesInvoiceDetail
    {
        [Key]
        public long FinanceSalesInvoiceDetailId { get; set; }
        public string ItemDescription { get; set; }
        public double? Amount { get; set; }

        public long? FinanceSalesInvoiceId { get; set; }
        public FinanceSalesInvoice FinanceSalesInvoice { get; set; }

    }
}
