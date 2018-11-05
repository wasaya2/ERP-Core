using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities
{
    public class Module : BaseClass
    {
        public Module()
        {
            RoleModules = new HashSet<RoleModule>();

            Features = new HashSet<Feature>();
        }

        public long ModuleId { get; set; }
        public string Name { get; set; }
        
        public IEnumerable<Feature> Features { get; set; }

        public IEnumerable<RoleModule> RoleModules { get; set; }
    }
}
