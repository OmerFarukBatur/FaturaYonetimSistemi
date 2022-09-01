using DataAccessLayer.Repositories.Housing;
using DataAccessLayer.Repositories.User;
using DataAccessLayer.ViewModels.Housing;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.Housing.GetAllHousing
{
    public class GetAllHousingQueryHandler : IRequestHandler<GetAllHousingQueryRequest, GetAllHousingQueryResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IHousingReadRepository _housingReadRepository;

        public GetAllHousingQueryHandler(IUserReadRepository userReadRepository, IHousingReadRepository housingReadRepository)
        {
            _userReadRepository = userReadRepository;
            _housingReadRepository = housingReadRepository;
        }

        public async Task<GetAllHousingQueryResponse> Handle(GetAllHousingQueryRequest request, CancellationToken cancellationToken)
        {
            var allHousing = await _userReadRepository.GetAll(false)
                .Join(_housingReadRepository.GetAll(false), u => u.id, h => h.UserId, (u, h) => new { u, h })
                .Select(s => new VM_CreateHousing
                {
                    FirstName = s.u.FirstName,
                    LastName = s.u.LastName,
                    id = s.h.id.ToString(),
                    BlockNumber = s.h.BlockNumber,
                    HousNumber = s.h.HousNumber,
                    HousType = s.h.HousType,
                    FloorNumber = s.h.FloorNumber,
                    Status = s.h.Status,
                    CreatedDate = s.h.CreatedDate,
                    UpdatedDate = s.h.UpdatedDate
                }).ToListAsync();


            return new()
            {
                AllHousing = allHousing
            };
        }
    }
}
