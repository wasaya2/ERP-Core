using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class ReturnReason : BaseClass
    {
        [Key]
        public long ReturnReasonId { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
    }
}
