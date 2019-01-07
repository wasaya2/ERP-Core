using ErpCore.Entities.FinanceSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.Finance
{
    public class FinancePurchaseReturn
    {
        public FinancePurchaseReturn()
        {
            FinancePurchaseReturnDetails = new HashSet<FinancePurchaseReturnDetail>();
        }

        [Key]
        public long FinancePurchaseReturnId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string BillNumber { get; set; }
        public double? CreditDays { get; set; }
        public string VoucherNumber { get; set; }
        public string InvoceNumber { get; set; }

        public double? Expenses { get; set; }
        public double? GstAmount { get; set; }
        public double? GstPercentage { get; set; }
        public double? DiscountAmount { get; set; }
        public double? DiscountPercentage { get; set; }
        public double? TaxPercentage { get; set; }
        public double? TaxAmount { get; set; }
        public double? WithholdingTaxPercentage { get; set; }
        public double WihtholdingTaxAmount { get; set; }

        public double? TotalAmount { get; set; }

        //public long? PurchaseReturnId { get; set; } //Use this to link with InventorySystemService
        //public PurchaseReturn PurchaseReturn { get; set; }

        public long? FinancePurchaseInvoiceId { get; set; }
        public FinancePurchaseInvoice FinancePurchaseInvoice { get; set; }

        public long? DetailAccountId { get; set; }
        public DetailAccount DetailAccount { get; set; }

        public IEnumerable<FinancePurchaseReturnDetail> FinancePurchaseReturnDetails { get; set; }
    }
}
