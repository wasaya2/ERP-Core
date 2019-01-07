using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PatientInvoiceReturnItem : BaseClass
    {
        [Key]
        public long PatientInvoiceReturnItemId { get; set; }

        public string Nature { get; set; }
        public double? UnitPrice { get; set; }
        public long? NameId { get; set; }
        public string Name { get; set; }

        public double? SaleQuantity { get; set; }
        public double? DiscountPercentage { get; set; }

        public double? SaleGrossAmount { get; set; }
        public double? SaleDiscountAmount { get; set; }
        public double? SaleNetAmount { get; set; }

        public double? ReturnQuantity { get; set; }
        public double? DiscountDeductionAmount { get; set; }
        public double? ReturnNetAmount { get; set; }

        public string Remarks { get; set; }

        public long? PatientInvoiceReturnId { get; set; }
        public PatientInvoiceReturn PatientInvoiceReturn { get; set; }
    }
}
