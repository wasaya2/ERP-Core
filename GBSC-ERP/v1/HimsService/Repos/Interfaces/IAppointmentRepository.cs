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
        IList<Appointment> GetConsultantAndAppointmentdate(long id, DateTime date);
        List<Appointment> GetDataByTentativedate(DateTime date);
        Appointment GetAppointmentDetails(long id);
        IEnumerable<Appointment> GetFinalizedAppointmentsByPatientIdAndMonthYear(long patid, DateTime date);
    }
}
