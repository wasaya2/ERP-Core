using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
   public class Procedure : BaseClass
    {

      [Key]
      public long ProcedureId { get; set; }
      public string ProcedureCode { get; set; }
      public string ProcedureName { get; set; }

    }
}
