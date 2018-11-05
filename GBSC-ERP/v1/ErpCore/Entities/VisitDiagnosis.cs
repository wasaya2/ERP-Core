using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class VisitDiagnosis
    {
        [Key]
        public long VisitDiagnosisId { get; set; }

        public long? DiagnosisId { get; set; }

        public Diagnosis Diagnosis { get; set; }

        public long? VisitId { get; set; }

        public Visit Visit { get; set; }
    }
}
