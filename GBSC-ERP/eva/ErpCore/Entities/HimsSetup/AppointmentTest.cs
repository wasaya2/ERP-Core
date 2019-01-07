using System;
using System.Collections.Generic;
using System.Text;

using ErpCore.Entities.HimsSetup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ErpCore.Entities.HimsSetup
{
   public class AppointmentTest 
    {

    public long? AppointmentId { get; set; }
    public Appointment Appointment { get; set; }

    public long? TestId { get; set; }
    public Test Test { get; set; }

    }


}
