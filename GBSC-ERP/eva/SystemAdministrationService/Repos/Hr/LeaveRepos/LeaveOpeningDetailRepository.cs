using ErpCore.Entities.HR.Leave.LeaveAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.Repos.Hr.LeaveRepos.Interfaces; 

namespace SystemAdministrationService.Repos.Hr.LeaveRepos
{
    public class LeaveOpeningDetailRepository : RepoBase<LeaveOpeningDetail>, ILeaveOpeningDetailRepository
    {
    }
}
