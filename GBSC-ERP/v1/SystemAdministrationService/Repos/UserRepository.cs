using ErpCore.Entities;
using ErpCore.Entities.HRSetup;
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
    public class UserRepository : RepoBase<User>, IUserRepository
    {
        public List<UserFeaturesViewModel> GetUserFeatures(long userid)
        {
            User usr = Table.Find(userid);
            if(usr == null)
            {
                return null;
            }
            var userfeatures = (from user in Db.Users where user.UserId == userid
                                join rolefeatures in Db.RoleFeatures on user.RoleId equals rolefeatures.RoleId
                                join features in Db.Features on rolefeatures.FeatureId equals features.FeatureId
                                select new UserFeaturesViewModel
                                {
                                    UserId = user.UserId,
                                    Feature = features.Name,
                                    FeatureCode = features.Code
                                }).ToList();

            return userfeatures;
        }
        

        public List<UserModulesViewModel> GetUserModules(long id)
        {
            User usr = Table.Find(id);
            if (usr == null)
            {
                return null;
            }
            var usermodules = (from user in Db.Users where user.UserId == id
                               join rolemodules in Db.RoleModules on user.RoleId equals rolemodules.RoleId
                               join modules in Db.Modules on rolemodules.ModuleId equals modules.ModuleId
                               select new UserModulesViewModel
                               {
                                   UserId = user.UserId,
                                   ModuleName = modules.Name
                               }).ToList();

            return usermodules;
        }

        public UserFeaturesAndModulesViewModel GetUserFeaturesAndModules(long id)
        {
            User usr = Table.Find(id);
            if (usr == null)
            {
                return null;
            }
            IEnumerable<string> features = GetUserFeatures(id).Select(a => a.Feature);
            IEnumerable<string> modules = GetUserModules(id).Select(b => b.ModuleName);

            UserFeaturesAndModulesViewModel ufam = new UserFeaturesAndModulesViewModel
            {
                UserId = id,
                Features = features.ToList(),
                Modules = modules.ToList()
            };

            return ufam;
        }

        public bool UpdateUserLanguages(long userId, IList<UserLanguage> langs)
        {
            User usr = Table.Find(userId);
            if (usr == null)
            {
                return false;
            }
            var userLangs = Context.UserLanguages.Where(u => u.UserId == userId).ToList();

            if ( userLangs == null)
            {
                return false;
            }

            Context.UserLanguages.RemoveRange(userLangs);
            Context.UserLanguages.AddRange(langs);
            Context.SaveChanges();
            return true;
        }

        public bool UpdateUserWorkExperience(long UserId, IList<WorkExperience> WrEx)
        {
            User usr = Table.Find(UserId);
            if (usr == null)
            {
                return false;
            }
            var WrkExp = Context.WorkExperiences.Where(u => u.UserId == UserId).ToList();

            if (WrkExp == null)
            {
                return false;
            }

            Context.WorkExperiences.RemoveRange(WrkExp);
            Context.WorkExperiences.AddRange(WrEx);
            Context.SaveChanges();
            return true;
        }

        public bool UpdateUserRelations(long UserId, IList<Relation> Rltn)
        {
            User usr = Table.Find(UserId);
            if (usr == null)
            {
                return false;
            }
            var relation = Context.Relations.Where(u => u.UserId == UserId).ToList();

            if (relation == null)
            {
                return false;
            }

            Context.Relations.RemoveRange(relation);
            Context.Relations.AddRange(Rltn);
            Context.SaveChanges();
            return true;
        }

        public bool UpdateUserUniversity(long UserId, IList<University> UsUn)
        {
            User usr = Table.Find(UserId);
            if (usr == null)
            {
                return false;
            }
            var UsrUni = Context.Universities.Where(u => u.UserId == UserId).ToList();

            if (UsrUni == null)
            {
                return false;
            }

            Context.Universities.RemoveRange(UsrUni);
            Context.Universities.AddRange(UsUn);
            Context.SaveChanges();
            return true;
        }

        public bool UpdateUserBank(long UserId, Bank bank)
        {
            User usr = Table.Find(UserId);
            if (usr == null)
            {
                return false;
            }
            Bank userbank = Context.Banks.FirstOrDefault(a => a.UserId == UserId);
            
            if(userbank == null)
            {
                return false;
            }

            Context.Banks.Remove(userbank);
            Context.Banks.Add(bank);
            Context.SaveChanges();
            return true;
        }
        

        public bool UpdateCostCenter(long UserId, long CostCenterId)
        {
            User user = Table.Find(UserId);
            if (user == null)
            {
                return false;
            }
            user.CostCenterId = CostCenterId;
            Update(user);
            return true;
        }

        public bool UpdateUserCompany(long UserId, long UserCompanyId)
        {
            User user = Table.Find(UserId);
            if (user == null)
            {
                return false;
            }
            user.UserCompanyId = UserCompanyId;
            Update(user);
            return true;
        }


        
        public bool UpdateGroup(long UserId, long GroupId)
        {
            User user = Table.Find(UserId);
            if (user == null)
            {
                return false;
            }
            user.GroupId = GroupId;
            Update(user);
            return true;
        }
        

        public bool UpdateReligion(long UserId, long ReligionId)
        {
            User user = Table.Find(UserId);
            if (user == null)
            {
                return false;
            }
            user.ReligionId = ReligionId;
            Update(user);
            return true;
        }
        
        public bool UpdateDepartment(long UserId, long DepartmentId)
        {
            User user = Table.Find(UserId);
            if (user == null)
            {
                return false;
            }
            user.DepartmentId = DepartmentId;
            Update(user);
            return true;
        }

        public bool UpdateRole(long UserId, long RoleId)
        {
            User user = Table.Find(UserId);
            if (user == null)
            {
                return false;
            }
            user.RoleId = RoleId;
            Update(user);
            return true;
        }



  }
}
