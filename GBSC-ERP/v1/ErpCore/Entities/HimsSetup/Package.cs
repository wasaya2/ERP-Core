using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    public class Package : BaseClass
    {
        [Key]
        public long PackageId { get; set; }
        public string PackageCode { get; set; }
        public string PackageName { get; set; }

    }
}
