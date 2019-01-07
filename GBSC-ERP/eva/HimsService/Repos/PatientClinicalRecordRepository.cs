using ErpCore.Entities;
using ErpInfrastructure.Data;
using HimsService.Repos.Base;
using HimsService.Repos.Interfaces;
using HimsService.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HimsService.Repos
{
    public static class NullSafeGetter
    {
        public static T GetValueOrDefault<T>(this IDataRecord row, string fieldName)
        {
            int ordinal = row.GetOrdinal(fieldName);
            return row.GetValueOrDefault<T>(ordinal);
        }

        public static T GetValueOrDefault<T>(this IDataRecord row, int ordinal)
        {
            return (T)(row.IsDBNull(ordinal) ? default(T) : row.GetValue(ordinal));
        }

    }

    public class PatientClinicalRecordRepository : RepoBase<PatientClinicalRecord>, IPatientClinicalRecordRepository
    {
        public IList<ClinicalRecordViewModel> SearchClinicalRecords(string patientname, string spousename, string mrn, long? cyclenumber, long? treatmentnumber)
        {
            try
            {
                var records = new List<ClinicalRecordViewModel>();

                var commandText = $"Select * from fn_SearchClinicalRecords('{patientname}','{spousename}','{mrn}','{cyclenumber}','{treatmentnumber}')";

                using (var context = new ApplicationDbContext())
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = commandText;
                        context.Database.OpenConnection();
                        using (var result = command.ExecuteReader())
                        {
                            if (result.HasRows)
                            {
                                while (result.Read())
                                {

                                    records.Add(new ClinicalRecordViewModel
                                    {
                                        Consultant = result.GetValueOrDefault<string>(0),
                                        TreatmentType = result.GetValueOrDefault<string>(1),
                                        Mrn = result.GetValueOrDefault<string>(2),
                                        PatientName = result.GetValueOrDefault<string>(3),
                                        Spouse = result.GetValueOrDefault<string>(4),
                                        TreatmentNumber = result.GetInt64(5),
                                        CycleNumber = result.GetInt32(6),
                                        PatientClinicalRecordId = result.GetInt64(7)
                                    });

                                }
                            }
                        }
                    }
                }

                return records;

            }
            catch (Exception e)
            {

                throw;
            }


        }
    }
}
