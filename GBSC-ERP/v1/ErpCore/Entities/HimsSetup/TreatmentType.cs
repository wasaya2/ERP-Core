using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    [Table("TreatmentType")]
    public class TreatmentType : BaseClass
    {
        public long TreatmentTypeId { get; set; }

        public string Name { get; set; }

        public string Abbrv { get; set; }

        public string CycleType { get; set; }
    }
}
