using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.ViewModels;

namespace SystemAdministrationService.Repos.Interfaces
{
    public interface IPermissionRepository : IRepo<Permission>
    {
        UserPermissionsViewModel GetFeaturePermissions(long UserId, long RoleId, long FeatureId);
    }
}
