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
                return Table.Where(a => a.TentativeTime.Value.Date == date.Date && a.PatientId == patid).Include(a => a.Consultant).Include(a => a.Patient).Include(a => a.VisitNature);
            }

            public IEnumerable<Appointment> GetFinalizedAppointmentsByDateAndPatientID(DateTime date, long patid)
            {
                return Table.Where(a => a.TentativeTime.Value.Date == date.Date && a.PatientId == patid && a.IsFinalAppointment == true).Include(a => a.Consultant).Include(a => a.Patient).Include(a => a.VisitNature);
            }

            public Appointment GetAppointmentDetails(long id)
            {
                return Table.Where(a => a.AppointmentId == id).Include(a => a.Consultant).Include(a => a.VisitNature).Include(a => a.PatientInvoice).Include("PatientInvoice.PatientInvoiceItems").Include(a => a.Patient).Include("Patient.Partner").Include("Patient.PatientPackage").FirstOrDefault();
            }

            public IEnumerable<Appointment> GetFinalizedAppointmentsByPatientIdAndMonthYear(long patid, DateTime date)
            {
                return Table.Where(a => a.PatientId == patid && a.IsFinalAppointment == true && a.FinalTime != null && a.AppointmentDate.Value.Month == date.Month && a.AppointmentDate.Value.Year == date.Year).Include(a => a.Consultant).Include(a => a.VisitNature).Include(a => a.PatientInvoice).Include("PatientInvoice.PatientInvoiceItems").Include(a => a.Patient).Include("Patient.Partner").Include("Patient.PatientPackage");
            }

    public IList<Appointment> GetConsultantAndAppointmentdate(long id, DateTime date)
    {
      var b = Table.Where(a => a.ConsultantId == id && a.AppointmentDate.Value.Date == date.Date).ToList();
      return b;
      //var cns = (from consultant in Db.Consultants
      //             where consultant.ConsultantId == id
      //             join appointment in Db.Appointments on consultant.ConsultantId equals appointment.ConsultantId
      //             where appointment.AppointmentDate.Value.Date == date.Date
      //             select new Appointment
      //             {
      //                   AppointmentId = appointment.AppointmentId,
      //                   PatientType = appointment.PatientType,
      //                   TentativeTime = appointment.TentativeTime,
      //                   FinalTime = appointment.FinalTime,
      //                   AppointmentDate = appointment.AppointmentDate,
      //                   TimeIn = appointment.TimeIn,
      //                   TimeOut = appointment.TimeOut,
      //                   VisitStatus = appointment.VisitStatus,
      //                   VisitNature = appointment.VisitNature,
      //                   VisitNatureId = appointment.VisitNatureId,
      //                   IsFinalAppointment = appointment.IsFinalAppointment,
      //                   AppointmentDay = appointment.AppointmentDay,
      //                   Remarks = appointment.Remarks,
      //                   PatientId = appointment.PatientId,
      //                   ConsultantId = appointment.ConsultantId,
      //                   IsCancelled = appointment.IsCancelled,
      //             }).ToList();

      //             return cns;

      //  from appointment in Db.Appointments where appointment.ConsultantId == id
      //  join consultant in Db.Consultants on appointment.Consultant equals consultant.ConsultantId


      //           /*
      //            *join rolefeatures in Db.RoleFeatures on user.RoleID equals rolefeatures.RoleId
      //                          join features in Db.Features on rolefeatures.FeatureId equals features.FeatureId
      //            *
      //            * */
      //var app = (from Appointment in Db.Appointments
      //                    where Appointment.ConsultantId == id && Appointment.TentativeTime.Value.Date == date.Date
      //                    select new Appointment
      //                    {
      //                      ConsultantId = Appointment.ConsultantId,
      //                      TentativeTime = Appointment.TentativeTime,
      //                    }).ToList();

    }

    public List<Appointment> GetDataByTentativedate(DateTime date)
    {
      var cns = (from appointment in Db.Appointments
                 where appointment.TentativeTime.Value.Date == date.Date
                 select new Appointment
                 {
                   AppointmentId = appointment.AppointmentId,
                   PatientType = appointment.PatientType,
                   TentativeTime = appointment.TentativeTime,
                   FinalTime = appointment.FinalTime,
                   TimeIn = appointment.TimeIn,
                   TimeOut = appointment.TimeOut,
                   VisitStatus = appointment.VisitStatus,
                   VisitNature = appointment.VisitNature,
                   IsFinalAppointment = appointment.IsFinalAppointment,
                   VisitNatureId = appointment.VisitNatureId,
                   AppointmentDay = appointment.AppointmentDay,
                   AppointmentDate = appointment.AppointmentDate,
                   Remarks = appointment.Remarks,
                   PatientId = appointment.PatientId,
                   ConsultantId = appointment.ConsultantId,
                   IsCancelled = appointment.IsCancelled,
                 }).ToList();

      return cns;

    }


  }
}
