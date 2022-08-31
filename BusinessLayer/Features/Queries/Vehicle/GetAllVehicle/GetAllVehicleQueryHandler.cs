using DataAccessLayer.Repositories.Housing;
using DataAccessLayer.Repositories.User;
using DataAccessLayer.Repositories.Vehicle;
using DataAccessLayer.ViewModels.Vehicle;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.Vehicle.GetAllVehicle
{
    public class GetAllVehicleQueryHandler : IRequestHandler<GetAllVehicleQueryRequest, GetAllVehicleQueryResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IHousingReadRepository _housingReadRepository;
        private readonly IVehicleReadRepository _vehicleReadRepository;

        public GetAllVehicleQueryHandler(IUserReadRepository userReadRepository, IHousingReadRepository housingReadRepository, IVehicleReadRepository vehicleReadRepository)
        {
            _userReadRepository = userReadRepository;
            _housingReadRepository = housingReadRepository;
            _vehicleReadRepository = vehicleReadRepository;
        }

        public async Task<GetAllVehicleQueryResponse> Handle(GetAllVehicleQueryRequest request, CancellationToken cancellationToken)
        {
            var allVehicle = await _userReadRepository.GetAll(false)
                .Join(_vehicleReadRepository.GetAll(false), user => user.id, vehicle => vehicle.UserId, (user, vehicle) => new { user, vehicle })
                .Join(_housingReadRepository.GetAll(false), us => us.user.id, hous => hous.UserId, (us, hous) => new { us, hous })
                .Select(s => new VM_GetAllVehicle
                {
                    UserId = s.us.user.id.ToString(),
                    FirstName = s.us.user.FirstName,
                    LastName = s.us.user.LastName,
                    BlockNumber = s.hous.BlockNumber,
                    HousNumber = s.hous.HousNumber,
                    id = s.us.vehicle.id.ToString(),
                    PlateNumber = s.us.vehicle.PlateNumber,
                    VehicleType = s.us.vehicle.VehicleType,
                    Status = s.us.vehicle.Status,
                    CreatedDate = s.us.vehicle.CreatedDate,
                    UpdatedDate = s.us.vehicle.UpdatedDate
                }).ToListAsync();

            return new()
            {
                Vehicles = allVehicle
            };
        }
    }
}
