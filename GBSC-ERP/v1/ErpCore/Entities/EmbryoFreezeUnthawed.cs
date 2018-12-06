using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class EmbryoFreezeUnthawed
    {
        [Key]
        public long EmbryoFreezeUnthawedId { get; set; }

        public DateTime? FreezeDate { get; set; }

        public long EmbryoNumber { get; set; }

        public string StrawId { get; set; }

        public string Drawer { get; set; }

        public string Cannister { get; set; }

        public string Can { get; set; }

        public string TopBottom { get; set; }

        public DateTime? DateCreated { get; set; }

        public long? CycleNo { get; set; }

        public long? ThawAssessmentId { get; set; }

        public long PatientId { get; set; }

        public Patient Patient { get; set; }

        public ThawAssessment ThawAssessment { get; set; }
    }
}
