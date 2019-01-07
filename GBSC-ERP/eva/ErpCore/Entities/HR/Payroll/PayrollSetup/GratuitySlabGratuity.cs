using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class GratuitySlabGratuity : BaseClass
    {
        [Key]
        public long GratuitySlabGratuityId { get; set; }
        public double? SlabAmount { get; set; } //Amount from this slab

        public long? GratuitySlabId { get; set; }
        public GratuitySlab GratuitySlab { get; set; }

        public long? GratuityId { get; set; }
        public Gratuity Gratuity { get; set; }
    }
}
