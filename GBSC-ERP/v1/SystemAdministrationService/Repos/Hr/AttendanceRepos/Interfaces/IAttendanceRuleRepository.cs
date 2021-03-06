﻿using ErpCore.Entities.HR.Attendance.AttendanceAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.Repos.Base;

namespace SystemAdministrationService.Repos.Hr.AttendanceRepos.Interfaces
{
    public interface IAttendanceRuleRepository :IRepo<AttendanceRule>
    {
    }
}
