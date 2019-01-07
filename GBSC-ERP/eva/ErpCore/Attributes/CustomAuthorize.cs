using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Attributes
{
    public class CustomAuthorize
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
