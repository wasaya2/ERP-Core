using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public  class FwbInitial : BaseClass
    {
      [Key]
      public long FwbInitialId { get; set; }
      public DateTime FwbInitialDate { get; set; }
      public long  TreatmentNo { get; set; }
      public long CycleNo{ get; set; }
      public DateTime ETDate { get; set; }
      public string GestAge { get; set; }
      public DateTime LMPDate { get; set; }
      public string CFacts { get; set; }
      public string NoofFoetus { get; set; }
      public string FoetalHeartBeat { get; set; }
      public string FoetalMovement { get; set; }
      public string AmnioticFluid { get; set; }
      public string CRL { get; set; }
      public string PlacnetalLocallisation { get; set; }
      public string GSac    { get; set; }
      public string Comments { get; set; }

      public long? PatientId { get; set; }
      public Patient Patient { get; set; }

      public long? ConsultantId { get; set; }
      public Consultant Consultant { get; set; }

      public long? SonologistId { get; set; }
      public Sonologist Sonologist { get; set; }

      public long? TreatmentTypeId { get; set; }
      public TreatmentType TreatmentType { get; set; }

  }
}
