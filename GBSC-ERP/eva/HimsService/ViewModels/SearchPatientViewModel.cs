using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HimsService.ViewModels
{
    public class SearchPatientViewModel
    {
    public long? PatientId { get; set; }
    public string Name { get; set; }
    public string MRN { get; set; }
    public string Contact { get; set; }
    }
}
