using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities
{
    public class ThawAssessment : BaseClass
    {
        public long ThawAssessmentId { get; set; }

        public DateTime? CreateDate { get; set; }

        public IEnumerable<EmbryoFreezeThawed> EmbryoFreezeThaweds { get; set; }

        public IEnumerable<EmbryoFreezeUnthawed> EmbryoFreezeUnthaweds { get; set; }

        public long? TvopuId { get; set; }

        public long? PatientClinicalRecordId { get; set; }

        public Tvopu Tvopu { get; set; }

        public PatientClinicalRecord PatientClinicalRecord { get; set; }

    }
}
