using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    [Table("Protocol")]
    public class Protocol : BaseClass
    {
        public long ProtocolId { get; set; }

        public string Name { get; set; }

        public bool? IsActive { get; set; }
    }
}
