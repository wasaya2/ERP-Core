using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.HimsSetup;
using HimsService.Repos.Base;


namespace HimsService.Repos.Interfaces
{
    public interface IPatientRepository : IRepo<Patient>
    {
        PatientVital GetLastestPatientVital(long patientid);
        //IEnumerable<Patient> SearchPatientById(long id);
        IEnumerable<Patient> SearchPatientByName(string name);
        IEnumerable<Patient> SearchPatientByMRN(string MRN);
        IEnumerable<Patient> SearchPatientByContact(string contact);

        IList<Diagnosis> GetLastestVisitDiagnos(long patientid);
        IList<Test> GetLatestVisitTests(long patientid);
        Patient GetPatientInvoicesWithDetailsByMRN(string mrn);
        Patient GetPatientInvoiceReturnsWithDetailsByMRN(string mrn);
        IEnumerable<PatientInvoice> GetPatientInvoicesWithDetailsByMRNandDate(string mrn, DateTime date);
        IEnumerable<PatientInvoiceReturn> GetPatientInvoiceReturnsWithDetailsByMRNandDate(string mrn, DateTime date);
    }


}
