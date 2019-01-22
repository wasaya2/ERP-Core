using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class PackType : BaseClass
    {
        public PackType()
        {
            SalesOrderItems = new HashSet<SalesOrderItem>();
        }

        [Key]
        public long PackTypeId { get; set; }

        public string Name { get; set; }

        public string PackTypeCode { get; set; }

        public double? EquivalentBasicUnit { get; set; } // Ex. How many liters in one pouch

        public IEnumerable<SalesOrderItem> SalesOrderItems { get; set; }
    }
}
