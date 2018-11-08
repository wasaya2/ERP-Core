using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    public class Package : BaseClass
    {
        public Package()
        {
            PatientPackages = new HashSet<PatientPackage>();
        }

        [Key]
        public long PackageId { get; set; }
        public string PackageCode { get; set; }
        public string PackageName { get; set; }
        public double Charges { get; set; }
        public DateTime? EffectiveDate { get; set; }

        public IEnumerable<PatientPackage> PatientPackages { get; set; }
    }
}
