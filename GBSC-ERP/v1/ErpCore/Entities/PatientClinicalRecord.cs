using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErpCore.Entities
{
    [Table("PatientClinicalRecord")]
    public class PatientClinicalRecord : BaseClass
    {
        public PatientClinicalRecord()
        {
            ClinicalRecordDrugs = new HashSet<ClinicalRecordDrugs>();
        }

        [Key]
        public long PatientClinicalRecordId { get; set; }

        public int CycleNumber { get; set; }

        public DateTime? Lmp1 { get; set; }

        public DateTime? Lmp2 { get; set; }

        public long TypewiseTreatmentNumber { get; set; }

        public string ActiveInactive { get; set; }

        public string Outcome { get; set; }

        public string Reason { get; set; }

        public DateTime? SupressionDate { get; set; }

        public DateTime? SimulationDate { get; set; }

        public DateTime? TriggerDate { get; set; }

        public DateTime? EtDate { get; set; }

        public long? PatientId { get; set; }

        public Patient Patient { get; set; }

        public long? TreatmentTypeId { get; set; }

        public TreatmentType TreatmentType { get; set; }

        public long? ConsultantId { get; set; }

        public Consultant Consultant { get; set; }

        public long? ProtocolId { get; set; }

        public Protocol Protocol { get; set; }

        public IEnumerable<ClinicalRecordDrugs> ClinicalRecordDrugs { get; set; }

        public Tvopu Tvopu { get; set; }

        public PatientInsemenation PatientInsemenation { get; set; }

        public InseminationPrep InseminationPrep { get; set; }

        public ThawAssessment ThawAssessment { get; set; }

        public Biopsy Biopsy { get; set; }

        public FreezePrepration FreezePrepration { get; set; }

        public BioChemistryTestOnTreatment BioChemistryTestOnTreatment { get; set; }

    }
}
