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
    public class RoleRepository : RepoBase<Role>, IRoleRepository
    {
        public IEnumerable<RolesWithModulefeaturePermissionsViewModel> GetRolesByCompany(long companyId)
        {
            var roles = Table.Where(r => r.CompanyId == companyId).Select(r => new RolesWithModulefeaturePermissionsViewModel
            {
                RoleId = r.RoleId,
                RoleName = r.Name,
                RoleModules = (from module in Db.RoleModules
                               where module.RoleId == r.RoleId
                               select new ModuleViewModel
                               {
                                   ModuleId = module.ModuleId,
                                   ModuleName = module.Module.Name
                               }).ToList(),
                RoleFeatures = (from feature in Db.Features
                                join rolefeature in Db.RoleFeatures on feature.FeatureId equals rolefeature.FeatureId
                                where rolefeature.RoleId == r.RoleId
                                select new FeatureViewModel { FeatureId = feature.FeatureId, FeatureName = feature.Name }).ToList(),
                RolePermissions = (from permission in Db.Permissions
                                   where permission.RoleId == r.RoleId
                                   select new PermissionViewModel
                                   {
                                       FeatureId = permission.FeatureId,
                                       PermissionId = permission.PermissionId,
                                       PermissionName = permission.Attribute
                                   }).ToList()
            }).ToList();

            return roles;
        }

        public IEnumerable<ModuleViewModel> GetModulesByRole(long roleId)
        {
            var modules = (from module in Db.RoleModules
                           where module.RoleId == roleId
                           select new ModuleViewModel
                           {
                               ModuleId = module.ModuleId,
                               ModuleName = module.Module.Name
                           }).ToList();

            return modules;
        }

        public long AddRole(SaveRoleviewModel model)
        {
            var permissions = new List<Permission>();
            foreach (var permission in model.rolePermissions)
            {
                permissions.Add(new Permission
                {
                    Attribute = permission.permissionName,
                    FeatureId = permission.featureId,
                    RoleId = model.RoleId
                });
            }

            var roleFeatures = new List<RoleFeature>();
            foreach (var roleFeature in model.roleFeatures)
            {
                roleFeatures.Add(new RoleFeature
                {
                    FeatureId = roleFeature.featureId,
                    RoleId = model.RoleId
                });
            }

            var roleModules = new List<RoleModule>();
            foreach (var roleModule in model.roleModules)
            {
                roleModules.Add(new RoleModule
                {
                    RoleId = model.RoleId,
                    ModuleId = roleModule.moduleId
                });
            }

            Context.Permissions.AddRange(permissions);
            Context.RoleFeatures.AddRange(roleFeatures);
            Context.RoleModules.AddRange(roleModules);

            SaveChanges();

            return model.RoleId;
        }

        public long UpdateRole(SaveRoleviewModel model)
        {
            var permissions = new List<Permission>();
            var roleFeatures = Db.RoleFeatures.Where(r => r.RoleId == model.RoleId);

            foreach (var feature in roleFeatures)
            {
                var permissions_temp = Db.Permissions.Where(f => f.FeatureId == feature.FeatureId && f.RoleId == model.RoleId).ToList();
                permissions.AddRange(permissions_temp);
            }

            var roleModules = Db.RoleModules.Where(r => r.RoleId == model.RoleId).ToList();

            Context.Permissions.RemoveRange(permissions);
            Context.RoleFeatures.RemoveRange(roleFeatures);
            Context.RoleModules.RemoveRange(roleModules);

            SaveChanges();

            var role = Find(model.RoleId);
            if (role != null)
            {
                role.Name = model.roleName;
                Update(role);
            }

            var roleId = AddRole(model);

            return roleId;
        }
    }
}
