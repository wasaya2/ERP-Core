using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAdministrationService.ViewModels
{
    public class SaveRoleviewModel
    {
        public long CompanyId { get; set; }
        public long RoleId { get; set; }
        public string roleName { get; set; }
        public Rolepermission[] rolePermissions { get; set; }
        public Rolefeature[] roleFeatures { get; set; }
        public Rolemodule[] roleModules { get; set; }

    }

    public class Rolepermission
    {
        public string permissionName { get; set; }
        public long featureId { get; set; }
    }

    public class Rolefeature
    {
        public long featureId { get; set; }
    }

    public class Rolemodule
    {
        public long moduleId { get; set; }
    }
}
