using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.Vehicle.GetByIdVehicle
{
    public class GetByIdVehicleQueryResponse
    {
        public EntityLayer.Entities.Vehicle Vehicle { get; set; }
        public object Users { get; set; }
    }
}
