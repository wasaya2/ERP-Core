using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class SalesPerson : BaseClass
    {
        public SalesPerson()
        {
            Customers = new HashSet<Customer>();
            SalesOrders = new HashSet<SalesOrder>();
        }

        [Key]
        public long SalesPersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Occupation { get; set; }
        public string NIC { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Remarks { get; set; }
        public string ResidenceAddress { get; set; }
        public string OfficeAddress { get; set; }
        public string OfficeTel { get; set; }
        public string ForeignAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public long? DistributorId { get; set; }
        public Distributor Distributor { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<SalesOrder> SalesOrders { get; set; }
    }
}
