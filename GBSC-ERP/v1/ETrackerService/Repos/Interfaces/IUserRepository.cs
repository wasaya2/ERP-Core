using ErpCore.Entities;
using eTrackerInfrastructure.Repos.Base;
using eTrackerInfrastructure.ViewModels;
using ETrackerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Repos.Interfaces
{
    public interface IUserRepository : IRepo<User>
    {
        string AssignSubsections(IList<SectionAssignmentViewModel> model);

        void ClearAssignments(long UserId);

        IEnumerable<UsersViewModel> GetUsers(long userId);

        User GetUserByIdentityId(string id);

        IList<User> GetAllUsersWithRelationships();

        IList<User> GetSalesUsers();

        bool CnicExists(string cnic);
    }
}
