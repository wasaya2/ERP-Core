using ErpCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.Repos.Interfaces;
using SystemAdministrationService.ViewModels;

namespace SystemAdministrationService.Repos
{
    public class FeatureRepository : RepoBase<Feature>, IFeatureRepository
    {
        public IEnumerable<FeaturesAndPermissionViewModel> GetFeaturesByRoleId(long RoleId)
        {
            var rolefeatures = Db.RoleFeatures.Include(f=>f.Feature).ThenInclude(f=>f.Permissions).Where(r => r.RoleId == RoleId);

            var featurespermissions = new List<FeaturesAndPermissionViewModel>();

            foreach (var rolefeature in rolefeatures)
            {
                featurespermissions.Add(new FeaturesAndPermissionViewModel
                {
                    FeatureName = rolefeature.Feature.Name,
                    Permissions = rolefeature.Feature.Permissions.Select(f => f.Attribute)
                });
            }

            return featurespermissions;
        }

      
    }
}
