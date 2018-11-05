using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.HimsSetup;
using HimsService.Repos.Base;

namespace HimsService.Repos.Interfaces
{
    public interface IPatientVitalRepository  : IRepo<PatientVital>
    {

    //IQueryable<PatientVital> FirstOrDefault();

    }
}
