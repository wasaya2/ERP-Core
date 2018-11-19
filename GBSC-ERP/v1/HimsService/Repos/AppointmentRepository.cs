using ErpCore.Entities;
using ErpCore.Entities.HimsSetup;
using HimsService.Repos.Base;
using HimsService.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HimsService.Repos
{
      public class AppointmentRepository : RepoBase<Appointment>, IAppointmentRepository
      {

            public IEnumerable<Appointment> GetAppointmentsByDateAndPatientID(DateTime date, long patid)
            {
                return Table.Where(a => a.TentativeTime != null && a.TentativeTime.Value.Date == date.Date && a.PatientId == patid).Include(a => a.Consultant).Include(a => a.Patient).Include(a => a.VisitNature);
            }

            public IEnumerable<Appointment> GetFinalizedAppointmentsByDateAndPatientID(DateTime date, long patid)
            {
                return Table.Where(a => a.TentativeTime != null && a.TentativeTime.Value.Date == date.Date && a.PatientId == patid && a.IsFinalAppointment == true).Include(a => a.Consultant).Include(a => a.Patient).Include(a => a.VisitNature);
            }

            public IEnumerable<Appointment> GetFinalizedAppointmentsByDateAndMRN(DateTime date, string mrn)
            {
                long patid = Db.Patients.FirstOrDefault(a => a.MRN != null && a.MRN == mrn).PatientId;
                return Table.Where(a => a.TentativeTime.Value.Date == date.Date && a.PatientId == patid && a.IsFinalAppointment == true).Include(a => a.Consultant).Include(a => a.Patient).Include(a => a.VisitNature);
            }

            public IEnumerable<Appointment> GetFinalizedAppointmentsByMRN(string mrn)
            {
                long patid = Db.Patients.FirstOrDefault(a => a.MRN != null && a.MRN == mrn).PatientId;
                return Table.Where(a => a.PatientId == patid && a.IsFinalAppointment == true).Include(a => a.Consultant).Include(a => a.Patient).Include(a => a.VisitNature).OrderByDescending(a => a.AppointmentId);
            }

            public Appointment GetAppointmentDetails(long id)
            {
                return Table.Where(a => a.AppointmentId == id).Include(a => a.Consultant).Include(a => a.VisitNature).Include(a => a.PatientInvoice).Include("PatientInvoice.PatientInvoiceItems").Include(a => a.Patient).Include("Patient.Partner").Include("Patient.PatientPackage").FirstOrDefault();
            }

            public IEnumerable<Appointment> GetFinalizedAppointmentsByPatientIdAndMonthYear(long patid, DateTime date)
            {
                return Table.Where(a => a.PatientId == patid && a.IsFinalAppointment == true && a.FinalTime != null && a.AppointmentDate != null && a.AppointmentDate.Value.Month == date.Month && a.AppointmentDate.Value.Year == date.Year).Include(a => a.Consultant).Include(a => a.VisitNature).Include(a => a.PatientInvoice).Include("PatientInvoice.PatientInvoiceItems").Include(a => a.Patient).Include("Patient.Partner").Include("Patient.PatientPackage");
            }

            public IEnumerable<Appointment> GetConsultantAndAppointmentdate(long id, DateTime date)
            {
              return Table.Where(a => a.ConsultantId == id && a.AppointmentDate != null && a.AppointmentDate.Value.Date == date.Date).ToList().OrderByDescending(a => a.AppointmentId);
            }

            public IEnumerable<Appointment> GetDataByTentativedate(DateTime date)
            {
                return Table.Where(a => a.TentativeTime != null && a.TentativeTime.Value.Date == date.Date).OrderByDescending(a => a.AppointmentId);
            }


    }
}
