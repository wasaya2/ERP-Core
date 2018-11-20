using ErpCore.Entities;
using HimsService.Repos.Base;
using System.Collections.Generic;

namespace HimsService.Repos.Interfaces
{
    public interface IPatientInvoiceReturnRepository : IRepo<PatientInvoiceReturn>
    {
        IEnumerable<PatientInvoiceReturn> GetPatientInvoiceReturnsWithDetailsByPatientMRN(string mrn);
        PatientInvoiceReturn GetPatientInvoiceReturnWithDetailsByInvoiceNumber(string slipnumber);
    }
}
