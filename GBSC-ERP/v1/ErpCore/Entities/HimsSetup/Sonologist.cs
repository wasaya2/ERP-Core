using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
  public class Sonologist : BaseClass
    {
    [Key]
    public long SonologistId { get; set; }
    public string Name { get; set; }
  }
}
