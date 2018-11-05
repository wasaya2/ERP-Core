using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.HimsSetup;
using HimsService.Repos.Base;
using HimsService.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace HimsService.Repos
{

    public class PatientRepository : RepoBase<Patient>, IPatientRepository
    {

    public PatientVital GetLastestPatientVital(long patientid)
    {
      IEnumerable<Visit> visit = Db.Visits.Where(a => a.PatientId == patientid).Include(a => a.PatientVital).OrderByDescending(c => c.VisitId);
      // long? visitid = visit.FirstOrDefault().PatientVitalId;
      PatientVital pv = visit.Where(b => b.PatientVital != null).Select(a => a.PatientVital).FirstOrDefault();
      //long pvid = pv.PatientVitalId;
      //foreach (Visit vis in visit)
      //{ }

 

      return pv;
    }


    public IList<Diagnosis> GetLastestVisitDiagnos(long patientid) {
      //Patient vs = Table.Where(b => b.PatientId == patientid).FirstOrDefault();
      Visit vist = Db.Visits.Where(x => x.PatientId == patientid).Include(n => n.VisitDiagnoses).OrderByDescending(z=>z.VisitId).FirstOrDefault();
      IList<VisitDiagnosis> dig = Db.VisitDiagnoses.Where(a => a.VisitId == vist.VisitId).Include(d => d.Diagnosis).ToList();

      IList<Diagnosis> ad = new List<Diagnosis>();
      foreach(VisitDiagnosis av in dig)
      {
        ad.Add(av.Diagnosis);
      }
      return ad;
    }


    public IList<Test> GetLatestVisitTests(long patientid)
    {
      Visit vist = Db.Visits.Where(x => x.PatientId == patientid).Include(n => n.VisitTests).OrderByDescending(z => z.VisitId).FirstOrDefault();
      IList<VisitTest> dig = Db.VisitTests.Where(a => a.VisitId == vist.VisitId).Include(d => d.Test).ToList();

      IList<Test> ad = new List<Test>();
      foreach (VisitTest av in dig)
      {
        ad.Add(av.Test);
      }
      return ad;
    }

    //public IEnumerable<Patient> SearchPatientById(long id)
    //{
    //  var pat = from Patient in Db.Patients
    //            where Patient.PatientId == id
    //            select Patient;
    //  return pat.ToList();
    //}

    public IEnumerable<Patient> SearchPatientByName(string name)
    {
      var pat = from Patient in Db.Patients
                where Patient.FirstName == name
                select Patient;
      return pat.ToList();
    }

    public IEnumerable<Patient> SearchPatientByMRN(string MRN)
    {
      var pat = from Patient in Db.Patients
                where Patient.MRN == MRN
                select Patient;
      return pat.ToList();
    }

    public IEnumerable<Patient> SearchPatientByContact(string contact)
    {
      var pat = from Patient in Db.Patients
                where Patient.PhoneNumber == contact
                select Patient;
      return pat.ToList();
    }



  }
}
