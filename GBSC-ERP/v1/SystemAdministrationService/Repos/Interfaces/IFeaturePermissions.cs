using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.ViewModels;

namespace SystemAdministrationService.Repos.Interfaces
{
    public interface IFeaturePermissions
    {
        UserPermissionsViewModel GetFeaturePermissions(long UserId, long RoleId, long FeatureId);
    }
}
