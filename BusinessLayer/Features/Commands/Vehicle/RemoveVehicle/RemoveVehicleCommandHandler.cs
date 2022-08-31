using DataAccessLayer.Repositories.Vehicle;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.Vehicle.RemoveVehicle
{
    public class RemoveVehicleCommandHandler : IRequestHandler<RemoveVehicleCommandRequest, RemoveVehicleCommandResponse>
    {
        private readonly IVehicleWriteRepository _vehicleWriteRepository;

        public RemoveVehicleCommandHandler(IVehicleWriteRepository vehicleWriteRepository)
        {
            _vehicleWriteRepository = vehicleWriteRepository;
        }

        public async Task<RemoveVehicleCommandResponse> Handle(RemoveVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            await _vehicleWriteRepository.RemoveAsync(request.Id);
            await _vehicleWriteRepository.SaveAsync();

            return new();
        }
    }
}
