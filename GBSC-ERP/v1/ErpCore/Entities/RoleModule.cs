using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities
{
    public class RoleModule
    {
        public long RoleId { get; set; }
        public Role Role { get; set; }

        public long ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
