using ErpCore.Entities;
using HimsService.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HimsService.Repos.Interfaces
{
    public interface IThawAssessmentRepository : IRepo<ThawAssessment>
    {
        void removeThawAssessmentThawDetails(long thawAssessmentId);

        void AddThawedUnthawed(List<EmbryoFreezeThawed> thawed, List<EmbryoFreezeUnthawed> unthawed);

        void RemoveFrozenEmbryo(long EmbryoFreezeUnthawedId);

        void AddThawedEmbryo(EmbryoFreezeThawed embryo);

        void UpdateThawedEmbryos(IList<EmbryoFreezeThawed> embryos);

        IEnumerable<EmbryoFreezeUnthawed> GetFrozonEmbryos(long PatientId);

        IEnumerable<EmbryoFreezeThawed> GetThawedEmbryos(long PatientId);
    }
}
