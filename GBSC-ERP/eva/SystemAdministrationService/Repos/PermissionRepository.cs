using ErpCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.Repos.Interfaces;
using SystemAdministrationService.ViewModels;

namespace SystemAdministrationService.Repos
{
    public class PermissionRepository : RepoBase<Permission>, IPermissionRepository
    {
        public UserPermissionsViewModel GetFeaturePermissions(long UserId, long RoleId, long FeatureId)
        {
            var _permissions = Db.Permissions.Where(p => p.FeatureId == FeatureId && p.RoleId == RoleId && p.UserId == UserId);

            return new UserPermissionsViewModel
            {
                Permissions = _permissions.ToList(),
                UserId = UserId,
                RoleId = RoleId,
                FeatureId = FeatureId
            };
        }
    }
}
