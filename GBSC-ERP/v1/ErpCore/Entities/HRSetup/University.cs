using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities.HRSetup
{
    public class University : BaseClass
    {
        public University()
        {
            SkillLevels = new HashSet<SkillLevel>();
        }
        [Key]
        public long UniversityId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? TimeFrom { get; set; }
        public DateTime? TimeTo { get; set; }
        public string Grade { get; set; }
        public string Courses { get; set; }

        public long? DegreeId { get; set; }
        public Degree Degree { get; set; }

        public IEnumerable<SkillLevel> SkillLevels { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
