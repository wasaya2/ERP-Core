using ErpCore.Entities.HR.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.Repos.Hr.AttendanceRepos.Interfaces;

namespace SystemAdministrationService.Repos.Hr.AttendanceRepos
{
  public class UserRosterAttendanceRepository : RepoBase<UserRosterAttendance>, IUserRosterAttendanceRepository
  {

    public IEnumerable<UserRosterAttendance> getUserAttendacesByDate(DateTime fromdate, DateTime todate)
    {
      //var x =  Table.Where(a => a.CheckInTime.Value.Date  == fromdate.Date  && a.CheckOutTime.Value.Date  == todate.Date ).ToList().OrderByDescending(a => a.AssignRosterId);
      //return x;
       return Table.Where(a => a.CheckInTime.Value.Date.ToString("MM/dd/yyyy") == fromdate.Date.ToString("MM/dd/yyyy") && a.CheckOutTime.Value.Date.ToString("MM/dd/yyyy") == todate.ToString("MM/dd/yyyy")).ToList().OrderByDescending(a => a.AssignRosterId);

    }
  }
}
