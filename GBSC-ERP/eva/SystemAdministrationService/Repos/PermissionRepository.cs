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
        public IList<string> GetFeaturePermissions(long UserId, string feature, string module)
        {
            var permissions = (from _user in Db.Users
                               join _roleFeature in Db.RoleFeatures on _user.RoleId equals _roleFeature.RoleId
                               join _feature in Db.Features on _roleFeature.FeatureId equals _feature.FeatureId
                               join _module in Db.Modules on _feature.ModuleId equals _module.ModuleId
                               join _permission in Db.Permissions on _roleFeature.FeatureId equals _permission.FeatureId
                               where _user.UserId == UserId && _feature.Name == feature && _module.Name == module && _permission.RoleId == _roleFeature.RoleId
                               select _permission.Attribute).ToList();

            return permissions;
        }
    }
}
