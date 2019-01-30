using ErpCore.Entities.HimsSetup;
using ErpCore.Entities.OtSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public  class OtPatientCase : BaseClass
    {
        [Key]
        public long OtPatientCaseId { get; set; }
        public DateTime OtPatientCaseDate { get; set; }
        public string DateNature { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
      
        public long?  PatientId { get; set; }
        public Patient Patient { get; set; }

        public long? OtProcedureId { get; set; }
        public OtProcedure OtProcedure { get; set; }

        public long? SurgeonId { get; set; }
        public Consultant Surgeon { get; set; }

        public long? DoneById { get; set; }
        public Consultant DoneBy { get; set; }

        public string Other { get; set; }
        public string AnesthesiaType { get; set; }
        public string Anestetic { get; set; }
        public string ScrubAssistant { get; set; }
        public string OtAssistant { get; set; }
        public string Nurse { get; set; }
        public string Remarks { get; set; }
    }
}
