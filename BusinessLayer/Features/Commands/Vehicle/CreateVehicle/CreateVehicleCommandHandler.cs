using DataAccessLayer.Repositories.Vehicle;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.Vehicle.CreateVehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommandRequest, CreateVehicleCommandResponse>
    {
        private readonly IVehicleWriteRepository _vehicleWriteRepository;

        public CreateVehicleCommandHandler(IVehicleWriteRepository vehicleWriteRepository)
        {
            _vehicleWriteRepository = vehicleWriteRepository;
        }

        public async Task<CreateVehicleCommandResponse> Handle(CreateVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            await _vehicleWriteRepository.AddAsync(new()
            {
                UserId = Guid.Parse(request.UserId),
                VehicleType = request.VehicleType,
                PlateNumber = request.PlateNumber,
                Status = request.Status,
            });

            await _vehicleWriteRepository.SaveAsync();
            return new();
        }
    }
}
