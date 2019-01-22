using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAdministrationService.ViewModels
{
    public class RolesWithModulefeaturePermissionsViewModel
    {
        public long RoleId { get; set; }

        public string RoleName { get; set; }

        public List<ModuleViewModel> RoleModules { get; set; }

        public List<FeatureViewModel> RoleFeatures { get; set; }

        public List<PermissionViewModel> RolePermissions { get; set; }

    }

    public class ModuleViewModel
    {
        public long ModuleId { get; set; }

        public string ModuleName { get; set; }

    }

    public class FeatureViewModel
    {
        public long FeatureId { get; set; }

        public string FeatureName { get; set; }
    }

    public class PermissionViewModel
    {
        public long? FeatureId { get; set; }

        public long PermissionId { get; set; }

        public string PermissionName { get; set; }
    }

}

