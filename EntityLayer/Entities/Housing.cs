using EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Housing : BaseEntity
    {
        public Guid UserId { get; set; }
        public String BlockNumber { get; set; }
        public int HousNumber { get; set; }
        public String HousType { get; set; }
        public int FloorNumber { get; set; }

        public User User { get; set; }

    }
}
