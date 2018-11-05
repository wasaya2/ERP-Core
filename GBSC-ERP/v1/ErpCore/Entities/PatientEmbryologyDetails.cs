using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PatientEmbryologyDetails : BaseClass
    {
        [Key]
        public long PatientEmbryologyDetailsId { get; set; }

        public int? EggNumber { get; set; }

        public string OocyteExam { get; set; }

        public long? SpermConcentration { get; set; }

        public string FertCheck { get; set; }

        public string TwentyFourHourCheck { get; set; }

        public string D2Check { get; set; }

        public string D3Check { get; set; }

        public string D4Check { get; set; }

        public string D5Check { get; set; }

        public string D6Check { get; set; }

        public string Fate { get; set; }

        public bool? Check { get; set; }

        public long? PaientEmbryologyId { get; set; }

        public PatientEmbryology PatientEmbryology { get; set; }
    }
}
