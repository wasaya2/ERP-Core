using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities
{
    public class ClinicalRecordDrugs : BaseClass
    {
        public long ClinicalRecordDrugsId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string Days { get; set; }

        public int Quanitity { get; set; }

        public string TotalDosage { get; set; }

        public long? MedicineId { get; set; }

        public Medicine Medicine { get; set; }
    }
}
