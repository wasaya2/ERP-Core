using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities.HRSetup
{
    public class UserLanguage
    {
        public long? UserId { get; set; }
        public User User { get; set; }

        public long? LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
