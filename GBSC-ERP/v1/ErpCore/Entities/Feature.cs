using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class Feature : BaseClass
    {
        public Feature()
        {
            Permissions = new HashSet<Permission>();
            RoleFeatures = new HashSet<RoleFeature>();
        }

        [Key]
        public long FeatureId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        
        public long? ModuleId { get; set; }
        public Module Module { get; set; }

        public IEnumerable<Permission> Permissions { get; set; }

        public IEnumerable<RoleFeature> RoleFeatures { get; set; }
    }
}
