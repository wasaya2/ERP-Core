using ErpCore.Entities;
using HimsService.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HimsService.Repos.Interfaces
{
    public interface IAppointmentRepository : IRepo<Appointment>
    {
        IEnumerable<Appointment> GetAppointmentsByDateAndPatientID(DateTime date, long patid);
        IEnumerable<Appointment> GetFinalizedAppointmentsByDateAndPatientID(DateTime date, long patid);
        IEnumerable<Appointment> GetFinalizedAppointmentsByDateAndMRN(DateTime date, string mrn);
        IEnumerable<Appointment> GetFinalizedAppointmentsByMRN(string mrn);
        IEnumerable<Appointment> GetConsultantAndAppointmentdate(long id, DateTime date);
        IEnumerable<Appointment> GetDataByTentativedate(DateTime date);
        Appointment GetAppointmentDetails(long id);
        IEnumerable<Appointment> GetFinalizedAppointmentsByPatientIdAndMonthYear(long patid, DateTime date);
    }
}
