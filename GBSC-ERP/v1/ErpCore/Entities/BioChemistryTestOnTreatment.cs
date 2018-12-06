using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class BioChemistryTestOnTreatment : BaseClass
    {
        public BioChemistryTestOnTreatment()
        {
            BioChemistryTestDetails = new HashSet<BioChemistryTestDetails>();
        }

        [Key]
        public long BioChemistryTestOnTreatmentId { get; set; }

        public DateTime? CollectionDate { get; set; }

        public DateTime? LMP { get; set; }

        public bool? IsRandom { get; set; }

        public string Other { get; set; }

        public string RefRange { get; set; }

        public IEnumerable<BioChemistryTestDetails> BioChemistryTestDetails { get; set; }

        public long? PatientClinicalRecordId { get; set; }

        public PatientClinicalRecord PatientClinicalRecord { get; set; }
    }
}
