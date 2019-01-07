using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    [Table("Medicine")]
    public class Medicine : BaseClass
    {
        public long MedicineId { get; set; }

        public string Name { get; set; }

        public string Dose { get; set; }

        public string Unit { get; set; }
    }
}
