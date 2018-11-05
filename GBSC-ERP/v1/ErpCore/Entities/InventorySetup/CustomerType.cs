using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class CustomerType : BaseClass
    {
        public CustomerType()
        {
            CustomerAccounts = new HashSet<CustomerAccount>();
            CustomerBanks = new HashSet<CustomerBank>();
            CustomerPricePickLevels = new HashSet<CustomerPricePickLevel>();
            Customers = new HashSet<Customer>();
            CustomerWarehouses = new HashSet<CustomerWarehouse>();
        }

        [Key]
        public long CustomerTypeId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string LandlineNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }

        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        
        public IEnumerable<CustomerAccount> CustomerAccounts { get; set; }
        public IEnumerable<CustomerBank> CustomerBanks { get; set; }
        
        public IEnumerable<CustomerPricePickLevel> CustomerPricePickLevels { get; set; }
        public IEnumerable<CustomerWarehouse> CustomerWarehouses { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}
