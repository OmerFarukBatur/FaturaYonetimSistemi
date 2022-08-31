using DataAccessLayer.Repositories.Vehicle;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.Vehicle.UpdateVehicle
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommandRequest, UpdateVehicleCommandResponse>
    {
        private readonly IVehicleWriteRepository _vehicleWriteRepository;
        private readonly IVehicleReadRepository _vehicleReadRepository;

        public UpdateVehicleCommandHandler(IVehicleWriteRepository vehicleWriteRepository, IVehicleReadRepository vehicleReadRepository)
        {
            _vehicleWriteRepository = vehicleWriteRepository;
            _vehicleReadRepository = vehicleReadRepository;
        }

        public async Task<UpdateVehicleCommandResponse> Handle(UpdateVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            EntityLayer.Entities.Vehicle vehicle = await _vehicleReadRepository.GetByIdAsync(request.Id);

            vehicle.UserId = Guid.Parse(request.UserId);
            vehicle.PlateNumber = request.PlateNumber;
            vehicle.VehicleType = request.VehicleType;
            vehicle.Status = request.Status;

            await _vehicleWriteRepository.SaveAsync();

            return new();
        }
    }
}
