using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    public class BiopsyType : BaseClass
    {
        public BiopsyType()
        {
            Biopsies = new HashSet<Biopsy>();
        }

        [Key]
        public long BiopsyTypeId { get; set; }
        public string Name { get; set; }

        public IEnumerable<Biopsy> Biopsies { get; set; }
    }
}
