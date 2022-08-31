using DataAccessLayer.Repositories.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.Vehicle.GetAllUserVehicle
{
    public class GetAllUserVehicleQueryHandler : IRequestHandler<GetAllUserVehicleQueryRequest, GetAllUserVehicleQueryResponse>
    {
        private readonly IUserReadRepository _userReadRepository;

        public GetAllUserVehicleQueryHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task<GetAllUserVehicleQueryResponse> Handle(GetAllUserVehicleQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _userReadRepository.GetAll(false).ToListAsync();

            return new()
            {
                Users = users
            };
        }
    }
}
