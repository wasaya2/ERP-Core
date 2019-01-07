using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class Comission : BaseClass
    {
        public Comission()
        {
            SalesOrderItems = new HashSet<SalesOrderItem>();
        }

        [Key]
        public long ComissionId { get; set; }
        public string Name { get; set; }
        public double? Percentage { get; set; }

        public IEnumerable<SalesOrderItem> SalesOrderItems { get; set; }
    }
}
