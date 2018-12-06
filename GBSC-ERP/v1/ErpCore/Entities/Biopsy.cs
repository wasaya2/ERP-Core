using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class Biopsy : BaseClass
    {
        [Key]
        public long BiopsyId { get; set; }

        public string BiopsyType { get; set; }

        public string Collectionnumber { get; set; }

        public DateTime? CollectionDate { get; set; }

        public string ProcedureNumber { get; set; } //Autogenerate

        public string Rmarks { get; set; }

        public DateTime? PesaTime { get; set; }

        public string PesaLeft { get; set; }

        public string PesaRight { get; set; }

        public string PesaResult { get; set; }

        public DateTime? TeseTime { get; set; }

        public string TeseLeft { get; set; }

        public string TeseRight { get; set; }

        public string TeseResult { get; set; }

        public string Remarks { get; set; }

        public long? PatientId { get; set; }

        public Patient Patient { get; set; }

        public long? PatientClinicalRecordId { get; set; }

        public PatientClinicalRecord PatientClinicalRecord { get; set; }
    }
}
