using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Models.JsonPostClasses
{
    public class JsonLocations
    {
        public LocationJson[] LocationJson { get; set; }
    }

    public class LocationJson
    {
        public long userid { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public DateTime? timestamp { get; set; }
    }

}
