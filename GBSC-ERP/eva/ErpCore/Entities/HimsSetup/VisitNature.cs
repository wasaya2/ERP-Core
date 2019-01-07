using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ErpCore.Entities.HimsSetup
{
   public class VisitNature : BaseClass
    {

    public VisitNature()
    {
      Appointments = new HashSet<Appointment>();
      Patients = new HashSet<Patient>();
    }

    [Key]
    public long VisitNatureId { get; set; }
    public string Nature { get; set; }

    public IEnumerable<Appointment> Appointments { get; set; }
    public IEnumerable<Patient> Patients { get; set; }



  }
}
