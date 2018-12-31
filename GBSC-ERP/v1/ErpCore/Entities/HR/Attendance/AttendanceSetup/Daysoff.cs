using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceSetup
{
  public class Daysoff : BaseClass
  {
    [Key]
    public long DaysoffId  { get; set; }
    public  DateTime Dayoff { get; set; }
    public string  Remarks { get; set; }


    public long? AssignRosterId { get; set; }
    public AssignRoster AssignRoster { get; set; }
  }
}
