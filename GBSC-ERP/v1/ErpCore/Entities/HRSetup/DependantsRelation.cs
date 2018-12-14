using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HRSetup
{
    public class DependantsRelation : BaseClass
    {

        [Key]
        public long DependantsRelationId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
         
    }
}
