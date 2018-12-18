using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class DailySemenAnalysis : BaseClass
      {

        public DailySemenAnalysis()
        {
           DailySemenAnalysisProcedures = new HashSet<DailySemenAnalysisProcedure>();
        }

        [Key]
        public long DailySemenAnalysisId { get; set; }
        public string Timein { get; set; }
        public string Timeout { get; set; }
        public double Payment { get; set; }
        public string Remarks { get; set; }

        public long? PatientId { get; set; }
        public Patient Patient { get; set; }

        public long? ConsultantId { get; set; }
        public Consultant Consultant { get; set; }

        public IEnumerable<DailySemenAnalysisProcedure> DailySemenAnalysisProcedures { get; set; } 




  }
}
