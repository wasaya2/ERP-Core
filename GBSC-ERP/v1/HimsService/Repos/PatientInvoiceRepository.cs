using ErpCore.Entities;
using HimsService.Repos.Base;
using HimsService.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HimsService.Repos
{
    public class PatientInvoiceRepository : RepoBase<PatientInvoice>, IPatientInvoiceRepository
    {
        public PatientInvoice GetPatientInvoiceWithDetailsBySlipNumberForReturn(string slipnumber)
        {
            return Table.Where(a => a.SlipNumber != null && a.SlipNumber == slipnumber).Include(a => a.PatientInvoiceItems).Include(a => a.Patient).Include("Patient.Partner").FirstOrDefault();
        }
    }
}
