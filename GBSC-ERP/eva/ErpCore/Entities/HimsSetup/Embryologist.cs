using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    public class Embryologist
    {
        public Embryologist()
        {
            Tvopus = new HashSet<Tvopu>();
        }

        [Key]
        public long EmbryologistId { get; set; }

        public string Description { get; set; }

        public IEnumerable<Tvopu> Tvopus { get; set; }
    }
}
