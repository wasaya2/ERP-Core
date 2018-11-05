using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HRSetup
{
    public class WorkExperience : BaseClass
    {
        [Key]
        public long? WorkExperienceId { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public string Description { get; set; }
        
        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
