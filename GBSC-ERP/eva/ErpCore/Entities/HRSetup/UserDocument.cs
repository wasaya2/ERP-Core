using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HRSetup
{
    public class UserDocument : BaseClass
    {
        [Key]
        public long UserDocumentId { get; set; }

        public string DocumentName { get; set; }
        public string FilePath { get; set; }
        public string Remarks { get; set; }
        
        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
