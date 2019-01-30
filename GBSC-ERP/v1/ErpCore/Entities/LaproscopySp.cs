using ErpCore.Entities.HimsSetup;
using ErpCore.Entities.OtSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities
{
    public class LaproscopySp : BaseClass
    {
      public long LaproscopySpId { get; set; }
      public DateTime LaproscopySpDate { get; set; }
      public string Heading { get; set; }
      //public DateTime LMPDate { get; set; }
      //public string Anesthetic { get; set; }
      public string Diagnosis { get; set; }
      public string Indications { get; set; }
      public string Vulva { get; set; }
      public string Vagina { get; set; }
      public string Cervix { get; set; }
      public string Uterus { get; set; }
      public string RFallopianTube    { get; set; }
      public string RDyeSpill { get; set; }
      public string LFallopianTube    { get; set; }
      public string LDyeSpill { get; set; }
      public string RighOvary { get; set; }
      public string LeftOvary { get; set; }
      public string PouchofDouglas    { get; set; }
      public string UterovesicalPouch { get; set; }
      public string OtherFindings { get; set; }
      public string Comments { get; set; }

      public long? PatientId { get; set; }
      public Patient Patient { get; set; }

      public long? OtProcedureId { get; set; }
      public OtProcedure OtProcedure { get; set; }

      public long? SurgeonId { get; set; }
      public Consultant Surgeon { get; set; }
  }
}
