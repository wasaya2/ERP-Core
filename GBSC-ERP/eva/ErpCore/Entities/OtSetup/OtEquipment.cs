using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.OtSetup
{
   public class OtEquipment : BaseClass
    {
    [Key]
    public long OtEquipmentId { get; set; }
    public string Name { get; set; }
    public string Abbr { get; set; }


  }
}
