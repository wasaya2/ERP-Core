using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    public class ReferenceRange : BaseClass
    {
        [Key]
        public long ReferenceRangeId { get; set; }
        public string RefRange { get; set; }

        public long? BioChemistryTestDetailsId { get; set; }
        public BioChemistryTestDetails BioChemistryTestDetails { get; set; }
    }
}
