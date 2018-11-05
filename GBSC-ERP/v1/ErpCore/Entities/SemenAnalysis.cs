using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities
{
    public class SemenAnalysis : BaseClass
    {
        public long SemenAnalysisId { get; set; }

        public DateTime? CollectionDate { get; set; }

        public string CollectionNumber { get; set; }

        public long ProcedureNumber { get; set; }

        public long? Abstinence { get; set; }

        public string EjaculationTime { get; set; }

        public string Location { get; set; }

        public string AssayTime { get; set; }

        public string Volume { get; set; }

        public string Consistency { get; set; }

        public string Appearance { get; set; }

        public string Ph { get; set; }

        public string MotileCountRange { get; set; }

        public double? MotileCount { get; set; }

        public string ImmotileCountRange { get; set; }

        public double? ImmotileCount { get; set; }

        public string TotalCountRange { get; set; }

        public double TotalCount { get; set; }

        public double? SpermProgressionRapidLinear { get; set; }

        public double? SpermProgressionNonLinear { get; set; }

        public double? SpermProgressionNonProgressive { get; set; }

        public double? Immotile { get; set; }

        public string TestPreprationMethod { get; set; }

        public double? VolumeSemenUsed { get; set; }

        public string TestPreprationTotalCountRange { get; set; }

        public double? TestPreprationTotalCount { get; set; }

        public string TestPreprationMotileCountRange { get; set; }

        public double? TestPreprationMotileCount { get; set; }

        public double? TestPreprationRapidLinearProgression { get; set; }

        public double? TestPreprationRapidNonLinearProgression { get; set; }

        public string TimeCompleted { get; set; }

        public double? FinalVolume { get; set; }

        public double? NormalForms { get; set; }

        public double? HeadAbnormalities { get; set; }

        public double? MidpieceAbnormalities { get; set; }

        public double? TailAbnormalities { get; set; }

        public string OtherCells { get; set; }

        public string Comments { get; set; }

        public string LabComments { get; set; }

        public string Others { get; set; }

        public long? ConsultantId { get; set; }

        public Consultant Consultant { get; set; }

        public long? PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
