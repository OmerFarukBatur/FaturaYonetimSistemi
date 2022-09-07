using DataAccessLayer.Repositories.FA;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.User.GetByIdFA
{
    public class GetByIdFAQueryHandler : IRequestHandler<GetByIdFAQueryRequest, GetByIdFAQueryResponse>
    {
        private readonly IFAReadRepository _faReadRepository;

        public GetByIdFAQueryHandler(IFAReadRepository faReadRepository)
        {
            _faReadRepository = faReadRepository;
        }

        public async Task<GetByIdFAQueryResponse> Handle(GetByIdFAQueryRequest request, CancellationToken cancellationToken)
        {
            string userId = "f298c320-9695-4c9c-74d1-08da8cbcd57c"; // Buradaki userId Oturumu açma işlemi yapıldıktan sonra alınacak 
            var allFA = await _faReadRepository.GetWhere(fa => fa.UserId == Guid.Parse(userId)).ToListAsync();

            return new()
            {
                AllFA = allFA
            };
        }
    }
}
