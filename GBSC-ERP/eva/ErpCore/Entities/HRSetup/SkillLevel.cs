using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities.HRSetup
{
    public class SkillLevel : BaseClass
    {
        [Key]
        public long SkillLevelId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public long? UniversityId { get; set; }
        public University University { get; set; }
    }
}
