using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.HRSetup;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.ViewModels;

namespace SystemAdministrationService.Repos.Interfaces
{
    public interface IUserRepository : IRepo<User>
    {
        List<UserFeaturesViewModel> GetUserFeatures(long userid);
        List<UserModulesViewModel> GetUserModules(long id);
 
        UserFeaturesAndModulesViewModel GetUserFeaturesAndModules(long id);

        bool UpdateUserLanguages(long UserId, IList<UserLanguage> Langs);
        bool UpdateUserWorkExperience(long UserId, IList<WorkExperience> WrEx);
        bool UpdateUserRelations(long UserId, IList<Relation> Rltn);
        bool UpdateUserUniversity(long UserId, IList<University> UsUn);
        bool UpdateUserBank(long UserId, Bank bank);
        bool UpdateCostCenter(long UserId, long CostCenterId);
        bool UpdateUserCompany(long UserId, long UserCompanyId);
        bool UpdateGroup(long UserId, long GroupId);
        bool UpdateReligion(long UserId, long ReligionId);
        bool UpdateDepartment(long UserId, long DepartmentId);
        bool UpdateRole(long UserId, long RoleId);
    }
}
