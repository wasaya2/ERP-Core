using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities
{
    public class FreezePrepration : BaseClass
    {
        public long FreezePreprationId { get; set; }

        public DateTime? FreezeDate { get; set; }

        public long? SemenRefNumber { get; set; }

        public long? CollectionNumber { get; set; }

        public string Other { get; set; }

        public string Type { get; set; }

        public string PesaTese { get; set; }

        public DateTime? CollectionDate { get; set; }

        public long? ProcedureNumber { get; set; }

        public long? NoOfStrawFrozen { get; set; }

        public long? DrawerNumber { get; set; }

        public long? CannisterNumber { get; set; }

        public string Position { get; set; }

        public long? StrawIdFrom { get; set; }

        public long? StrawIdTo { get; set; }

        public long? Suffix { get; set; }

        public string StrawColor { get; set; }

        public string PlugColor { get; set; }

        public string SurvivalRange { get; set; }

        public double? Survival { get; set; }

        public string Remarks { get; set; }

        public long? PatientClinicalRecordId { get; set; }

        public PatientClinicalRecord PatientClinicalRecord { get; set; }


        public long? BiopsyId { get; set; }

        public Biopsy Biopsy { get; set; }

  }
}
