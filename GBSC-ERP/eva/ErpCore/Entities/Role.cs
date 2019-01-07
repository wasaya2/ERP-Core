using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class Role : BaseClass
    {
        public Role()
        {
            Users = new HashSet<User>();
            RoleModules = new HashSet<RoleModule>();
            RoleFeatures = new HashSet<RoleFeature>();
            Permissions = new HashSet<Permission>();
        }

        [Key]
        public long RoleId { get; set; }
        public string Name { get; set; }

        public long? DepartmentId { get; set; }
        public Department Department { get; set; }

        public IEnumerable<Permission> Permissions { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<RoleModule> RoleModules { get; set; }
        public IEnumerable<RoleFeature> RoleFeatures { get; set; }
    }
}
