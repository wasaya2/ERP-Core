using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.ViewModels
{
    public class SectionAssignmentViewModel
    {
        public string Name { get; set; }

        public long UserId { get; set; }

        public long SubsectionId { get; set; }

        public bool IsAssigned { get; set; }
    }
}
