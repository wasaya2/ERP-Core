using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    public class BioChemistryTest : BaseClass
    {
        public BioChemistryTest()
        {
            BioChemistryTestDetails = new HashSet<BioChemistryTestDetails>();
        }

        [Key]
        public long BioChemistryTestId { get; set; }
        public string Description { get; set; }

        public IEnumerable<BioChemistryTestDetails> BioChemistryTestDetails { get; set; }
    }
}
