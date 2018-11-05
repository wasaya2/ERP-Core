using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class Customer : BaseClass
    {
        public Customer()
        {
            SalesOrders = new HashSet<SalesOrder>();
        }

        [Key]
        public long CustomerId { get; set; }
        public DateTime? RegDate { get; set; }
        //public string RegCity { get; set; }
        public string CRN { get; set; }//AutoGenerate
        public string Status { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Email { get; set; }
        public string Nature { get; set; }
        public string ContactName { get; set; }
        public string Cnic { get; set; }
        public string ContactNumber { get; set; }

        public bool? IsChargeBardana { get; set; }
        public bool? IsShowReceivables { get; set; }
        public bool? IsBedDebt { get; set; }
        public bool? IsShowDn { get; set; }
        public bool? IsSecurityDeposit { get; set; }
        public bool? IsHeadQuater { get; set; }
        public bool? IsBranch { get; set; }

        public double? CreditDays { get; set; }
        public double? CreditLimit { get; set; }
        public double? AgreedInvestment { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string LandlineNumber { get; set; }
        public string MobilerNumber { get; set; }
        public string FaxNumber { get; set; }
        
        public string GroupName { get; set; }
        public long? StNumber { get; set; }
        public string Ntn { get; set; }
        
        public long? SalesPersonId { get; set; }
        public SalesPerson SalesPerson { get; set; }

        public long? CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }

        public long? ModeOfPaymentId { get; set; }
        public ModeOfPayment ModeOfPayment { get; set; }

        public IEnumerable<SalesOrder> SalesOrders { get; set; }
    }
}
