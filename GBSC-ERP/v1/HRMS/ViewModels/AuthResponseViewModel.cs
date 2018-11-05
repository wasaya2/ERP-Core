using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.ViewModels
{
    public class AuthResponseViewModel
    {
        public long? userid { get; set; }

        //public long? territoryid { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }
    }
}
