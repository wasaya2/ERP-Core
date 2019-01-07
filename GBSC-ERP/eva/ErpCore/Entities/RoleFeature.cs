using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities
{
    public class RoleFeature
    {
        public long RoleId { get; set; }
        public Role Role { get; set; }

        public long FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
