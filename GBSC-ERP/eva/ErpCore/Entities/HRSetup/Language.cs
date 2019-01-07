using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities.HRSetup
{
    public class Language : BaseClass
    {
        public Language()
        {
            UserLanguages = new HashSet<UserLanguage>();
        }

        [Key]
        public long LanguageId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<UserLanguage> UserLanguages { get; set; }
    }
}
