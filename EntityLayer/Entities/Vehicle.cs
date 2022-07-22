using EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Vehicle : BaseEntity
    {
        public Guid UserId { get; set; }
        public String PlateNumber { get; set; }
        public String VehicleType { get; set; }

        public User User { get; set; }

    }
}
