using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PatientPackage : BaseClass
    {
        [Key]
        public long PatientPackageId { get; set; }

        public DateTime? LastPaymentDate { get; set; }
        public double? LastPaidAmount { get; set; }

        public double? TotalPrice { get; set; }
        public double? TotalAmountPaid { get; set; }
        public double? TotalBalance { get; set; }

        public long? PatientId { get; set; }
        public Patient Patient { get; set; }

        public long? PackageId { get; set; }
        public Package Package { get; set; }
    }
}
