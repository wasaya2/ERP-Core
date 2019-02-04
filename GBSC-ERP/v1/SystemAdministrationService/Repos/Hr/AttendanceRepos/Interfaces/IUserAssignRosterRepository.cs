using ErpCore.Entities.HR.Attendance.AttendanceSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.Repos.Base;

namespace SystemAdministrationService.Repos.Hr.AttendanceRepos.Interfaces
{
    public interface IUserAssignRosterRepository : IRepo<UserAssignRoster>
    {
        IEnumerable<UserAssignRoster> GetAssignedRostersByUser(long userid, DateTime fromdate, DateTime todate);
    }
}
