using DataAccessLayer.Repositories.Housing;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.User.GetByIdHousing
{
    public class GetByIdHousingQueryHandler : IRequestHandler<GetByIdHousingQueryRequest, GetByIdHousingQueryResponse>
    {
        private readonly IHousingReadRepository _housingReadRepository;

        public GetByIdHousingQueryHandler(IHousingReadRepository housingReadRepository)
        {
            _housingReadRepository = housingReadRepository;
        }

        public async Task<GetByIdHousingQueryResponse> Handle(GetByIdHousingQueryRequest request, CancellationToken cancellationToken)
        {
            string userId = "f298c320-9695-4c9c-74d1-08da8cbcd57c"; // Buradaki userId Oturumu açma işlemi yapıldıktan sonra alınacak 
            var housing = await _housingReadRepository.GetWhere(h => h.UserId == Guid.Parse(userId)).ToListAsync();

            return new()
            {
                AllHousing = housing
            };
        }
    }
}
