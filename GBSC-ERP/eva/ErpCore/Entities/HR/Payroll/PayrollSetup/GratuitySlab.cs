using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class GratuitySlab : BaseClass
    {
        public GratuitySlab()
        {
            GratuitySlabGratuities = new HashSet<GratuitySlabGratuity>();
        }

        [Key]
        public long? GratuitySlabId { get; set; }
        public string Title { get; set; }

        public long? EmploymentDaysFrom { get; set; } //Ex....Pay gratuity at rate 0.5% for first 100 days, then change to 1 from 100 to 500 days
        public long? EmploymentDaysTill { get; set; }

        public double? MultiplicationFactor { get; set; }

        public IEnumerable<GratuitySlabGratuity> GratuitySlabGratuities { get; set; }
    }
}
