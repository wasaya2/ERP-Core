using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities.HRSetup
{
    public class Relation : BaseClass
    {
        [Key]
        public long RelationId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string PermanentAddress { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }

        public long? DependantsRelationId { get; set; }
        public DependantsRelation DependantsRelation { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
