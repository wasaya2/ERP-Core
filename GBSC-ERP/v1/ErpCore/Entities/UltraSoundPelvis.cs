using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
  public class UltraSoundPelvis : BaseClass
  {
    [Key]
    public long UltraSoundPelvisId { get; set; }
    public DateTime LMP { get; set; }
    public DateTime EtOn { get; set; }
    public string TreatmentDay { get; set; }
    public DateTime UltrasoundDate { get; set; }
    public string CycleDay { get; set; }
    public string AreaScanned { get; set; }
    public string Findings { get; set; }
    public string LS { get; set; }
    public string AP { get; set; }
    public string TS { get; set; }
    public string Type { get; set; }
    public string Endometrium { get; set; }
    public string Description { get; set; }
    public string FocalMassesInUterus { get; set; }
    public string RightOvary { get; set; }
    public string RightOvaryGrading { get; set; }
    public string NoOfFolliciesRightOvary { get; set; }
    public string LargeSizeRightOvary { get; set; }
    public string LeftOvary { get; set; }
    public string LeftOvaryGrading { get; set; }
    public string NoOfFolliciesLeftOvary { get; set; }
    public string LargeSizeLeftOvary { get; set; }
    public string FluidPelvis { get; set; }
    public string FluidAbdomen { get; set; }
    public string Comments { get; set; }

    public long? PatientId { get; set; }
    public Patient Patient { get; set; }

    public long? ConsultantId { get; set; }
    public Consultant Consultant { get; set; }

    public long? TreatmentTypeId { get; set; }
    public TreatmentType TreatmentType { get; set; }

    public long? SonologistId { get; set; }
    public Sonologist Sonologist { get; set; }

  }
}
