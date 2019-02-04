using ErpCore.Entities.HimsSetup;
using ErpCore.Entities.OtSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
   public class LaproscopyFS : BaseClass
    {
    [Key]
    public long LaproscopyFSId { get; set; }
    public DateTime LaproscopyFsDate { get; set; }
    public string Type{ get; set; }
    public  DateTime LMPDate{ get; set; }
    public string Anesthetic { get; set; }
    public string Diagnosis { get; set; }
    public string Indications { get; set; }
    public string Heading1 { get; set; }
    public string OperationsNote1 { get; set; }
    public string Heading2 { get; set; }
    public string OperationsNote2 { get; set; }
    public string Heading3 { get; set; }
    public string OperationsNote3 { get; set; }
    public string OperationsNote4 { get; set; }
    public string Comments { get; set; }

    public long? PatientId { get; set; }
    public Patient Patient { get; set; }

    public long? OtProcedureId { get; set; }
    public OtProcedure OtProcedure { get; set; }

    public long? SurgeonId { get; set; }
    public Consultant Surgeon{ get; set; }


    public long? Surgeon2Id { get; set; }
    public Consultant Surgeon2 { get; set; }
  }
}
