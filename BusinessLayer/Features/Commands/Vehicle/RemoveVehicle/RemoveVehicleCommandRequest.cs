using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.Vehicle.RemoveVehicle
{
    public class RemoveVehicleCommandRequest : IRequest<RemoveVehicleCommandResponse>
    {
        public string Id { get; set; }
    }
}
