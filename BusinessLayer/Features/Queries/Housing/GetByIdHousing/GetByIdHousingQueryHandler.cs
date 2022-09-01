using DataAccessLayer.Repositories.Housing;
using DataAccessLayer.Repositories.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.Housing.GetByIdHousing
{
    public class GetByIdHousingQueryHandler : IRequestHandler<GetByIdHousingQueryRequest, GetByIdHousingQueryResponse>
    {
        private readonly IHousingReadRepository _housingReadRepository;
        private readonly IUserReadRepository _userReadRepository;

        public GetByIdHousingQueryHandler(IHousingReadRepository housingReadRepository, IUserReadRepository userReadRepository)
        {
            _housingReadRepository = housingReadRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<GetByIdHousingQueryResponse> Handle(GetByIdHousingQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _userReadRepository.GetAll(false).ToListAsync();

            EntityLayer.Entities.Housing housing = await _housingReadRepository.GetByIdAsync(request.Id);

            return new()
            {
                Housing = housing,
                Users = users
            };
        }
    }
}
