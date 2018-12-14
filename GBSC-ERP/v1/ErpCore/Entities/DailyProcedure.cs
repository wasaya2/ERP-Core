using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class DailyProcedure : BaseClass
    {

        [Key]
        public long DailyProcedureId { get; set; }
        public string  Nature { get; set; }
        public DateTime Time { get; set; }
        public string ProcedureType { get; set; }
        public string DoneByNature { get; set; }
        public string Remarks { get; set; }

        public long? PatientId { get; set; }
        public Patient Patient { get; set; }

        public long? AssignedConsultantId { get; set; }
        public Consultant AssignedConsultant { get; set; }
    
        public long? ProcedureId { get; set; }
        public Procedure Procedure { get; set; }
    
        public long? PerformedByConsultantId { get; set; }
        public Consultant PerformedByConsultant { get; set; }
 
    }
}
