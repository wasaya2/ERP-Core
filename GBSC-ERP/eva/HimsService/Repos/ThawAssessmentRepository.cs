using ErpCore.Entities;
using HimsService.Repos.Base;
using HimsService.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HimsService.Repos
{
    public class ThawAssessmentRepository : RepoBase<ThawAssessment>, IThawAssessmentRepository
    {
        public void removeThawAssessmentThawDetails(long thawAssessmentId)
        {
            var unthawed = Db.EmbryoFreezeUnthaweds.Where(c => c.ThawAssessmentId == thawAssessmentId).ToList();
            var thawed = Db.EmbryoFreezeThaweds.Where(c => c.ThawAssessmentId == thawAssessmentId).ToList();

            Db.EmbryoFreezeThaweds.RemoveRange(thawed);
            Db.EmbryoFreezeUnthaweds.RemoveRange(unthawed);

            Db.SaveChanges();
        }

        public void AddThawedUnthawed(List<EmbryoFreezeThawed> thawed, List<EmbryoFreezeUnthawed> unthawed)
        {
            Db.EmbryoFreezeThaweds.AddRange(thawed);
            Db.EmbryoFreezeUnthaweds.AddRange(unthawed);
            Db.SaveChanges();
        }

        public IEnumerable<EmbryoFreezeUnthawed> GetFrozonEmbryos(long PatientId)
        {
            return Db.EmbryoFreezeUnthaweds.Where(c => c.PatientId == PatientId).ToList();
        }

        public IEnumerable<EmbryoFreezeThawed> GetThawedEmbryos(long PatientId)
        {
            return Db.EmbryoFreezeThaweds.Where(c => c.PatientId == PatientId).ToList();
        }

        public void RemoveFrozenEmbryo(long EmbryoFreezeUnthawedId)
        {
            var embryo = Db.EmbryoFreezeUnthaweds.Find(EmbryoFreezeUnthawedId);
            if (embryo != null)
                Db.EmbryoFreezeUnthaweds.Remove(embryo);
            Db.SaveChanges();
        }

        public void AddThawedEmbryo(EmbryoFreezeThawed embryo)
        {
            try
            {
                Db.EmbryoFreezeThaweds.Add(embryo);
                Db.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void UpdateThawedEmbryos(IList<EmbryoFreezeThawed> embryos)
        {
            foreach (var embryo in embryos)
            {
                try
                {
                    Db.EmbryoFreezeThaweds.Update(embryo);
                    Db.SaveChanges();
                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }
    }
}
