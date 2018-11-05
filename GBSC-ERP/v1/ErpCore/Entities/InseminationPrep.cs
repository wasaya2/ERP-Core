using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class InseminationPrep : BaseClass
    {

        [Key]
        public long InseminationPrepId { get; set; }

        public string PrepFor { get; set; }

        public long? CollectionNumber { get; set; }

        public DateTime? CollectionDate { get; set; }

        public string SampleType { get; set; }

        public string ProcedureNumber { get; set; }

        public DateTime? InsemenationDate { get; set; }

        public string Method { get; set; }

        public double? Volume { get; set; }

        public string TotalCountRange { get; set; }

        public double? TotalCount { get; set; }

        public string MotileCountRange { get; set; }

        public double? MotileCount { get; set; }

        public long? RapidLinearProgression { get; set; }

        public long? NonLinearProgression { get; set; }

        public string TimeCompleted { get; set; }

        public double? FinalVolume { get; set; }

        public string Comments { get; set; }

        public string SpecialComment { get; set; }

        public long? PatientClinicalRecordId { get; set; }

        public PatientClinicalRecord PatientClinicalRecord { get; set; }

    }
}
