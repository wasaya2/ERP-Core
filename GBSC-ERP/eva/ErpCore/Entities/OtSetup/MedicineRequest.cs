using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities.OtSetup
{
    public  class MedicineRequest : BaseClass
    {
      public long MedicineRequestId { get; set; }
      public string  Name { get; set; }
      public string Abbr { get; set; }

  }
}
