using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErpCore.Entities
{
    public class PatientEmbryology : BaseClass
    {
        public PatientEmbryology()
        {
            this.PatientEmbryologyDetails = new HashSet<PatientEmbryologyDetails>();
        }

        [Key]
        public long PatientEmbryologyId { get; set; }

        public string EggNumber { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? EmbryoDate { get; set; }

        public DateTime? FreshEmbryoTransferDate { get; set; }

        public string FreshEmbryoTransferTime { get; set; }

        public string Time { get; set; }

        public string Staff { get; set; }

        public string Verify { get; set; }

        public string Status { get; set; }

        public long? TvopuId { get; set; }

        public Tvopu Tvopu { get; set; }

        public IEnumerable<PatientEmbryologyDetails> PatientEmbryologyDetails { get; set; }
    }
}
