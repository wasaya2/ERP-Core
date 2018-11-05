using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class Tax : BaseClass
    {
        public Tax()
        {
            SalesOrders = new HashSet<SalesOrder>();
        }

        [Key]
        public long TaxId { get; set; }
        public string Name { get; set; }
        public double? Percentage { get; set; }


        public IEnumerable<SalesOrder> SalesOrders { get; set; }
    }
}
