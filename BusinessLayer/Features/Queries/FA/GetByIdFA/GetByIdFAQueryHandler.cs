using BusinessLayer.ValidationRules.FA;
using DataAccessLayer.Repositories.FA;
using DataAccessLayer.Repositories.User;
using EntityLayer.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.FA.GetByIdFA
{
    public class GetByIdFAQueryHandler : IRequestHandler<GetByIdFAQueryRequest, GetByIdFAQueryResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IFAReadRepository _faReadRepository;

        public GetByIdFAQueryHandler(IUserReadRepository userReadRepository, IFAReadRepository faReadRepository)
        {
            _userReadRepository = userReadRepository;
            _faReadRepository = faReadRepository;
        }

        public async Task<GetByIdFAQueryResponse> Handle(GetByIdFAQueryRequest request, CancellationToken cancellationToken)
        {
            EntityLayer.Entities.FA byFA = await _faReadRepository.GetByIdAsync(request.Id);
            var allUser = await _userReadRepository.GetAll(false).ToListAsync();

            return new()
            {
                Users = allUser,
                FA = byFA
            };
        }
    }
}
