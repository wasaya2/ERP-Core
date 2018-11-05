using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    public class TestType : BaseClass
    {
        [Key]
        public long TestTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
