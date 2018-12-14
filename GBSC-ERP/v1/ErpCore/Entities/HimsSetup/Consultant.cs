using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ErpCore.Entities.HimsSetup
{
    public  class Consultant : BaseClass
    {
        public Consultant()
        {
            Appointments = new HashSet<Appointment>();
            AssignedDailyProcedures = new HashSet<DailyProcedure>();
            PerformedDailyProcedures = new HashSet<DailyProcedure>();
        }
        
        [Key]
        public long ConsultantId { get; set; }
        public string Name { get; set; }
        public double? Charges { get; set; }
        public string Title { get; set; }
        public string Specialization { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<DailyProcedure> AssignedDailyProcedures { get; set; }
        public IEnumerable<DailyProcedure> PerformedDailyProcedures { get; set; }
    }
}
