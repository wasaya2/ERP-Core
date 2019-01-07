using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    public class Diagnosis : BaseClass
    {
        public Diagnosis()
        {
          //VisitDiagnosis = new HashSet<VisitDiagnosis>();
        }

        [Key]
        public long DiagnosisId { get; set; }
        public string Name { get; set; }
        public string Symptoms { get; set; }

        //public long? PatientId { get; set; }

        //public IEnumerable<VisitDiagnosis> VisitDiagnosis { get; set; }
    }
}
