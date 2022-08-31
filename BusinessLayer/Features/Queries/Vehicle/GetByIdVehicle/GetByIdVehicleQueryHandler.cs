using DataAccessLayer.Repositories.User;
using DataAccessLayer.Repositories.Vehicle;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.Vehicle.GetByIdVehicle
{
    public class GetByIdVehicleQueryHandler : IRequestHandler<GetByIdVehicleQueryRequest, GetByIdVehicleQueryResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IVehicleReadRepository _vehicleReadRepository;

        public GetByIdVehicleQueryHandler(IUserReadRepository userReadRepository, IVehicleReadRepository vehicleReadRepository)
        {
            _userReadRepository = userReadRepository;
            _vehicleReadRepository = vehicleReadRepository;
        }

        public async Task<GetByIdVehicleQueryResponse> Handle(GetByIdVehicleQueryRequest request, CancellationToken cancellationToken)
        {
            var allUser = await _userReadRepository.GetAll(false).ToListAsync();
            EntityLayer.Entities.Vehicle vehicle = await _vehicleReadRepository.GetByIdAsync(request.Id);

            return new()
            {
                Users = allUser,
                Vehicle = vehicle,
            };
        }
    }
}
