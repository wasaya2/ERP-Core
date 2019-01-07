using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class Units : BaseClass
    {
        public Units()
        {
        }
        
        [Key]
        public long UnitId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; } //Kg or Liter or pcs

    }
}
