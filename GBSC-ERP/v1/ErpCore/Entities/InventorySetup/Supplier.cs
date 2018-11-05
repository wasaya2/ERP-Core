using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class Supplier : BaseClass
    {
        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            //GRNs = new HashSet<GRN>();
            //PurchaseInvoices = new HashSet<PurchaseInvoice>();
        }

        [Key]
        public long SupplierId { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string LandlineNumber { get; set; }
        public string MobilerNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Nature { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string GlAccount { get; set; }

        public IEnumerable<PurchaseOrder> PurchaseOrders { get; set; }
        //public IEnumerable<GRN> GRNs { get; set; }
        //public IEnumerable<PurchaseInvoice> PurchaseInvoices { get; set; }
    }
}
