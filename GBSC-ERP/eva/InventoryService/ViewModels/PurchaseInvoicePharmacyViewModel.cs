using ErpCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.ViewModels
{
    public class PurchaseInvoicePharmacyViewModel
    {
        public string InvoiceNumber { get; set; }
        public string GRNCode { get; set; }
        public DateTime? GRNDate { get; set; }
        public string GRNRemarks { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public double? TotalPayable { get; set; }
        public double? TotalQuantity { get; set; }
        public string VendorBillNumber { get; set; }

        public IEnumerable<GrnItem> GrnItems { get; set; }
    }
}
