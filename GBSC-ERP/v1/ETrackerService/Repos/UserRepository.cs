using ErpCore.Entities;
using eTrackerInfrastructure.Repos.Base;
using eTrackerInfrastructure.Repos.Interfaces;
using eTrackerInfrastructure.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eTrackerInfrastructure.Repos
{
    public class UserRepository : RepoBase<User>, IUserRepository
    {

        public string AssignSubsections(IList<SectionAssignmentViewModel> model)
        {
            try
            {
                foreach (var item in model)
                {
                    var subsection = Context.Subsections.FirstOrDefault(m => m.SubsectionId == item.SubsectionId);
                    if (subsection != null)
                    {
                        if (subsection.UserId != null && item.UserId == subsection.UserId && !item.IsAssigned)
                        {
                            subsection.UserId = null;
                        }
                        else
                        {
                            subsection.UserId = item.UserId;
                        }

                        Context.Subsections.Update(subsection);
                    }
                }

                Context.SaveChanges();
                return "Subsections assigned";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

        }

        public bool CnicExists(string cnic)
        {
            return Table.FirstOrDefault(u => u.CNIC == cnic) != null ? true : false;
        }

        public IList<User> GetAllUsersWithRelationships()
        {
            return Table.Include(u => u.Distributor).ThenInclude(u => u.Territory).ToList();
        }

        //public IdentityUserViewModel GetIdentityInfo(string id)
        //{
        //    try
        //    {
        //        var usersWithRoles = (from user in Table
        //                              join userrole in Context.UserRoles on user.Identity.Id equals userrole.UserId
        //                              join role in Context.Roles on userrole.RoleId equals role.Id
        //                              where user.IdentityId == id
        //                              select new IdentityUserViewModel
        //                              {
        //                                  Id = user.IdentityId,
        //                                  UserName = user.Identity.UserName,
        //                                  Email = user.Identity.Email,
        //                                  Role = role.Name
        //                              }).FirstOrDefault();

        //        return usersWithRoles;
        //    }
        //    catch (System.Exception e)
        //    {

        //        throw;
        //    }

        //}

        public IList<User> GetSalesUsers()
        {

            return Table.Where(u => u.DistributorId > 0)
                .OrderByDescending(u=>u.UserId)
                .Include(u => u.Distributor)
                .ThenInclude(d => d.Territory)
                .ToList();
        }

        public User GetUserByIdentityId(string id) => Table.FirstOrDefault(u => u.IdentityId == id);


    }
}
