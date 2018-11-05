using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ErpCore.Entities.HimsSetup;
using System.ComponentModel.DataAnnotations.Schema;


namespace ErpCore.Entities
{
    public class PatientVital : BaseClass
    {
        [Key]
        public long PatientVitalId { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string CalculatedBMI { get; set; }
        public string Temperature { get; set; }
        public string Pulse { get; set; }
        public string RespiratoryRate { get; set; }
        public string BloodPressureUp { get; set; }
        public string BloodPressureDown { get; set; }

        public string BloodOxygenSaturation { get; set; }

        public long? VisitId { get; set; }
        public Visit Visit { get; set; }
    }
}
