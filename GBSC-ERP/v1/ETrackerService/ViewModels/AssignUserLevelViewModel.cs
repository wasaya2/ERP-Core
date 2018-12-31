using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrackerService.ViewModels
{
    public class AssignUserLevelViewModel
    {
        public string UserLevel { get; set; }

        public long UserId { get; set; }

        public long SectionId { get; set; }

        public long[] RegionIds { get; set; }

        public long[] CityIds { get; set; }

        public long[] AreaIds { get; set; }

        public long[] TerritoryIds { get; set; }
    }
}
