using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PatientInvoiceItem : BaseClass
    {
        [Key]
        public long PatientInvoiceItemId { get; set; }
        public string Name { get; set; }
        public double? Quantity { get; set; }
        public double? GrossAmount { get; set; }
        public double? DiscountAmount { get; set; }
        public double? NetAmount { get; set; }

        public long? PackageId { get; set; }
        public Package Package { get; set; }

        public long? TestId { get; set; }
        public Test Test { get; set; }

        public long? PatientInvoiceId { get; set; }
        public PatientInvoice PatientInvoice { get; set; }
    }
}
