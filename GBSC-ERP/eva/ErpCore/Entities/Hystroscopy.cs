using ErpCore.Entities.HimsSetup;
using ErpCore.Entities.OtSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
  public  class Hystroscopy : BaseClass
    {
      [Key]
      public long  HystroscopyId { get; set; }
      public DateTime HystroscopyDate { get; set; }
      public string Type { get; set; }
      public DateTime LmpDate { get; set; }
      public string Anesthetic { get; set; }
      public string Indications { get; set; }
      public string OperationsNote1 { get; set; }
      public string OperationsNote2 { get; set; }
      public string OperationsNote3 { get; set; }
      public string OperationsNote4 { get; set; }
      public string OperationsNote5 { get; set; }
      public string OperationsNote6 { get; set; }
      public string Findings { get; set; }
      public string Comments { get; set; }

      public long ? PatientId { get; set; }
      public Patient Patient { get; set; }

      public long? OtProcedureId { get; set; }
      public OtProcedure OtProcedure { get; set; }

      public long? ConsultantId { get; set; }
      public Consultant Consultant { get; set; }

  }
}
