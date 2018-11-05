using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    public class Test : BaseClass
    {
        public Test()
        {
            AppointmentTests = new HashSet<AppointmentTest>();
        }
        [Key]
        public long TestId { get; set; }
        public string TestCode { get; set; }
        public string TestName { get; set; }
        public double? Charges { get; set; }
        public double? Days { get; set; }

        public bool? IsLMP { get; set; }
        public bool? IsLabTest { get; set; }

        public long? TestTypeId { get; set; }
        public TestType TestType { get; set; }

        public long? TestCategoryId { get; set; }
        public TestCategory TestCategory { get; set; }

        public IEnumerable<AppointmentTest> AppointmentTests { get; set; }

        //public long? PatientInvoiceItemId { get; set; }
        //public PatientInvoiceItem PatientInvoiceItem { get; set; }
    }
}
