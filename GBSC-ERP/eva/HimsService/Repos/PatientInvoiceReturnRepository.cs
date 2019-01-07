using ErpCore.Entities;
using HimsService.Repos.Base;
using HimsService.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HimsService.Repos
{
    public class PatientInvoiceReturnRepository : RepoBase<PatientInvoiceReturn>, IPatientInvoiceReturnRepository
    {
        public IEnumerable<PatientInvoiceReturn> GetPatientInvoiceReturnsWithDetailsByPatientMRN(string mrn)
        {
            try
            {
                long patid = Db.Patients.FirstOrDefault(a => a.MRN == mrn).PatientId;
                return Table.Where(a => a.PatientId != null && a.PatientId == patid).Include(a => a.Patient).Include(a => a.PatientInvoice).Include(a => a.PatientInvoiceReturnItems).ToList().OrderByDescending(a => a.ReturnDate);
            }
            catch(NullReferenceException)
            {
                return null;
            }
        }

        public PatientInvoiceReturn GetPatientInvoiceReturnWithDetailsByInvoiceNumber(string slipnumber)
        {
            try
            {
                long invid = Db.PatientInvoices.FirstOrDefault(a => a.SlipNumber == slipnumber).PatientInvoiceId;
                return Table.Where(a => a.PatientInvoiceId != null && a.PatientInvoiceId == invid).Include(a => a.Patient).Include(a => a.PatientInvoice).Include(a => a.PatientInvoiceReturnItems).ToList().FirstOrDefault();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}
