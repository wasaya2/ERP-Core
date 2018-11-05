using ErpCore.Entities;
using HimsService.Repos.Base;
using HimsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HimsService.Repos.Interfaces
{
    public interface IPatientClinicalRecordRepository : IRepo<PatientClinicalRecord>
    {
        IList<ClinicalRecordViewModel> SearchClinicalRecords(string patientname, string spousename, string mrn, long? cyclenumber, long? treatmentnumber);

    }
}
