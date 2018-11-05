using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class EmbryoFreezeThawed : BaseClass
    {
        [Key]
        public long EmbryoFreezeThawedId { get; set; }

        public string StrawId { get; set; }

        public string Drawer { get; set; }

        public string Cannister { get; set; }

        public string Can { get; set; }

        public string TopBottom { get; set; }

        public long? ThawAssessmentId { get; set; }

        public ThawAssessment ThawAssessment { get; set; }

    }
}
