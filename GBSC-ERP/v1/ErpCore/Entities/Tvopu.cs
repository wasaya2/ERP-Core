using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class Tvopu
    {
        [Key]
        public long TvopuId { get; set; }

        public DateTime? TimeStart { get; set; }

        public DateTime? TimeFinish { get; set; }

        public string ActiveInactive { get; set; }

        public string Remarks { get; set; }

        public long? PickupCount { get; set; }

        public long? TotalPickupCount { get; set; }

        public DateTime? PickupDate { get; set; }

        public string FollicileAspiratedLeft { get; set; }

        public string FollicileAspiratedRight { get; set; }

        public string OociteCollectedLeft { get; set; }

        public string OociteCollectedRight { get; set; }

        public long? EmbryologistId { get; set; }

        public Embryologist Embryologist { get; set; }

        public long? PatientClinicalRecordId { get; set; }

        public PatientClinicalRecord PatientClinicalRecord { get; set; }
    }
}
