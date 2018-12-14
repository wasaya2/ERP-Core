using ErpCore.Entities;
using eTrackerInfrastructure.Repos.Base;
using eTrackerInfrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Repos.Interfaces
{
    public interface IUserRepository : IRepo<User>
    {
        string AssignSubsections(IList<SectionAssignmentViewModel> model);

        //IdentityUserViewModel GetIdentityInfo(string id);

        User GetUserByIdentityId(string id);

        IList<User> GetAllUsersWithRelationships();

        IList<User> GetSalesUsers();

        bool CnicExists(string cnic);
    }
}
