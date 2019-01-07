using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErpCore.Entities;
using ErpCore.Entities.InventorySetup;

namespace ErpCore.Entities.InventorySetup
{
    public class Section : BaseClass
    {
        public Section()
        {
            Subsections = new HashSet<Subsection>();
        }
        [Key]
        public long SectionId { get; set; }

        [Required]
        public string Name { get; set; }

        public long TerritoryId { get; set; }

        public Territory Territory { get; set; }

        public long? UserId { get; set; }

        public User User { get; set; }

        public IEnumerable<Subsection> Subsections { get; set; }

    }
}
