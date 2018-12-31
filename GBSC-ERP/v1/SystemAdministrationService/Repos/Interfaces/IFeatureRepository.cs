using ErpCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.ViewModels;

namespace SystemAdministrationService.Repos.Interfaces
{
    public interface IFeatureRepository : IRepo<Feature>
    {
        IEnumerable<FeaturesAndPermissionViewModel> GetFeaturesByRoleId(long RoleId);
    }
}
