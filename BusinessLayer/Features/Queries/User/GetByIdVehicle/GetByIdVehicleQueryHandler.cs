using DataAccessLayer.Repositories.Vehicle;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.User.GetByIdVehicle
{
    public class GetByIdVehicleQueryHandler : IRequestHandler<GetByIdVehicleQueryRequest, GetByIdVehicleQueryResponse>
    {
        private readonly IVehicleReadRepository _vehicleReadRepository;

        public GetByIdVehicleQueryHandler(IVehicleReadRepository vehicleReadRepository)
        {
            _vehicleReadRepository = vehicleReadRepository;
        }

        public async Task<GetByIdVehicleQueryResponse> Handle(GetByIdVehicleQueryRequest request, CancellationToken cancellationToken)
        {
            string userId = "f298c320-9695-4c9c-74d1-08da8cbcd57c"; // Buradaki userId Oturumu açma işlemi yapıldıktan sonra alınacak 
            var vehicle = await _vehicleReadRepository.GetWhere(v => v.UserId == Guid.Parse(userId)).ToListAsync();
            
            return new()
            {
                AllVehicle = vehicle
            };
        }
    }
}
