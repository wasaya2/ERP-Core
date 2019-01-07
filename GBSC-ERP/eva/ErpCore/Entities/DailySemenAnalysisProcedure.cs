using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities
{
  public  class DailySemenAnalysisProcedure  
    {


    public long? ProcedureId { get; set; }
    public Procedure Procedure { get; set; }

    public long? DailySemenAnalysisId { get; set; }
    public DailySemenAnalysis DailySemenAnalysis { get; set; }

  }
}
