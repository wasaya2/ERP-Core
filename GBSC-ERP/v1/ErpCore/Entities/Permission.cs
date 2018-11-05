using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class Permission : BaseClass
    {
        public Permission()
        {
        }

        [Key]
        public long PermissionId { get; set; }
        public string PermissionCode { get; set; }
        public string Attribute { get; set; }

        public long? FeatureId { get; set; }
        public Feature Feature { get; set; }
        
        public long? RoleId { get; set; }
        public Role Role { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
