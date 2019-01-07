using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HimsService.ViewModels
{
    public class ClinicalRecordViewModel
    {
        public long PatientClinicalRecordId { get; set; }

        public string PatientName { get; set; }

        public string Spouse { get; set; }

        public string Mrn { get; set; }

        public string Consultant { get; set; }

        public string TreatmentType { get; set; }

        public long? CycleNumber { get; set; }

        public long? TreatmentNumber { get; set; }
    }
}
