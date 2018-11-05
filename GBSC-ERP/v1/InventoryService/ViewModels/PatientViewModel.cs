using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryService.ViewModels
{
    class PatientViewModel
    {
        public long PatientId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PatientName { get; set; }

    }
}
