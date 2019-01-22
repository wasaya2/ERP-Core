using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class UltraSoundMaster : BaseClass
    {
      [Key]
      public long UltraSoundMasterId { get; set; }
      public DateTime UltraSoundMasterDate { get; set; }
      public string CFacts { get; set; }
      public DateTime LMP { get; set; }
      public string GeatAge {get; set;}
      public DateTime EtDate { get; set; }
      public string NoofFoetus { get; set; }
      public string FoetalHeartBeat { get; set; }
      public string FoetalMovement { get; set; }
      public string LieOfFoetus { get; set; }
      public string AmnioticFluid { get; set; }
      public string PlacnetalLocallisation { get; set; }
      public string Presentation { get; set; }
      public string PlacentalGrade { get; set; }
      public string Bpd { get; set; }
      public string Hc { get; set; }
      public string Ac { get; set; }
      public string Fl { get; set; }
      public string Afi { get; set; }
      public string Gs { get; set; }
      public string Crl { get; set; }
      public string Ebw { get; set; }
      public string Comments { get; set; }

      public long? PatientId { get; set; }
      public Patient Patient { get; set; }

      public long? ConsultantId { get; set; }
      public Consultant Consultant { get; set; }

      public long? SonologistId { get; set; }
      public Sonologist Sonologist { get; set; }
  }
}
