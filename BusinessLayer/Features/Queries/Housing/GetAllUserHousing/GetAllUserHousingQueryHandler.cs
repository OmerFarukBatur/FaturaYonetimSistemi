using DataAccessLayer.Repositories.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.Housing.GetAllUserHousing
{
    public class GetAllUserHousingQueryHandler : IRequestHandler<GetAllUserHousingQueryRequest, GetAllUserHousingQueryResponse>
    {
        private readonly IUserReadRepository _userReadRepository;

        public GetAllUserHousingQueryHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task<GetAllUserHousingQueryResponse> Handle(GetAllUserHousingQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _userReadRepository.GetAll(false).ToListAsync();

            return new()
            {
                Users = users
            };
        }
    }
}
