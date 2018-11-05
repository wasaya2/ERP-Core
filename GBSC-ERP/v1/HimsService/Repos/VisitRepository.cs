using ErpCore.Entities;
using HimsService.Repos.Base;
using HimsService.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HimsService.Repos
{
    public class VisitRepository : RepoBase<Visit>, IVisitRepository
    {
        public IEnumerable<Visit> GetActiveVisits()
        {
          var cns = (from visit in Db.Visits
                     where visit.StartTime != null  && visit.EndTime == null

                     select new Visit
                     {
                       VisitId = visit.VisitId,
                       StartTime = visit.StartTime,
                       PatientId = visit.PatientId,
                       Patient = visit.Patient,
                       
                     }).ToList();

          return cns;
        }
    }
}
