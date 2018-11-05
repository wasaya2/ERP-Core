using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class ModeOfPayment : BaseClass
    {
        public ModeOfPayment()
        {
            SalesOrders = new HashSet<SalesOrder>();
            Customers = new HashSet<Customer>();
        }

        [Key]
        public long ModeOfPaymentId { get; set; }
        public string Name { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<SalesOrder> SalesOrders { get; set; }
    }
}
