using ErpCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAdministrationService.ViewModels
{
    public class UserPermissionsViewModel
    {
        public List<Permission> Permissions { get; set; }

        public long RoleId { get; set; }

        public long UserId { get; set; }

        public long FeatureId { get; set; }
    }
}
