using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class CustomerWarehouse
    {
        [Key]
        public long CustomerWarehouseId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public long? CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}
