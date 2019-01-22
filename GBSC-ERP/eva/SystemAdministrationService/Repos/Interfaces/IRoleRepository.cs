using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.ViewModels;

namespace SystemAdministrationService.Repos.Interfaces
{
    public interface IRoleRepository : IRepo<Role>
    {
        IEnumerable<RolesWithModulefeaturePermissionsViewModel> GetRolesByCompany(long companyId);

        IEnumerable<ModuleViewModel> GetModulesByRole(long roleId);

        long AddRole(SaveRoleviewModel model);

        long UpdateRole(SaveRoleviewModel model);
    }
}
