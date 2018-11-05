using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities.HRSetup
{
    public class GazettedHolidays : BaseClass
    {
        [Key]
        public long GazettedHolidaysId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public DateTime? HolidayDate { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
