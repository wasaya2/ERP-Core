using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class BioChemistryTestOutsider
    {
        public BioChemistryTestOutsider()
        {
            BioChemistryTestDetails = new HashSet<BioChemistryTestDetails>();
        }

        [Key]
        public long BioChemistryTestOutsiderId { get; set; }

        public DateTime? CollectionDate { get; set; }

        public DateTime? LMP { get; set; }

        public string Days { get; set; }

        public bool? IsRandom { get; set; }

        public long? PatientId { get; set; }

        public Patient Patient { get; set; }

        public long? ConsultantId { get; set; }

        public Consultant Consultant { get; set; }

        public string Others { get; set; }

        public IEnumerable<BioChemistryTestDetails> BioChemistryTestDetails { get; set; }
    }
}
