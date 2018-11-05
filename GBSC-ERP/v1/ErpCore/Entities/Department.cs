using ErpCore.Entities.HR.Leave;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class Department : BaseClass
    {
        public Department()
        {
            Roles = new HashSet<Role>();
            LeaveClosings = new HashSet<LeaveClosing>();
        }

        [Key]
        public long DepartmentId { get; set; }
        public string Name { get; set; }

        public long? BranchId { get; set; }
        public Branch Branch { get; set; }

        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<LeaveClosing> LeaveClosings { get; set; }
    }
}
