using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrackerService.ViewModels
{
    public class AssignedSubsectionsViewModel
    {
        public long SubsectionId { get; set; }

        public string Name { get; set; }

        public bool IsAssigned { get; set; }

        public long UserId { get; set; }
    }
}
