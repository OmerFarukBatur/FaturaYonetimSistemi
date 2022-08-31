using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.Vehicle.CreateVehicle
{
    public class CreateVehicleCommandRequest : IRequest<CreateVehicleCommandResponse>
    {
        public string UserId { get; set; }
        public String PlateNumber { get; set; }
        public String VehicleType { get; set; }
        public bool Status { get; set; }
    }
}
