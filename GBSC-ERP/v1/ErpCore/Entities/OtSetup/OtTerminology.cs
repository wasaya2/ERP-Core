using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.OtSetup
{
   public  class OtTerminology : BaseClass
    {
    [Key]
    public long  OtTerminologyId { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

  }
}
