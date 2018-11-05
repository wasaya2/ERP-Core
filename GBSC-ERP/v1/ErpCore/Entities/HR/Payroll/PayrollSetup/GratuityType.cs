using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class GratuityType : BaseClass
    {
        public GratuityType()
        {
            Gratuities = new HashSet<Gratuity>();
        }

        [Key]
        public long GratuityTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Gratuity> Gratuities { get; set; }
    }
}
