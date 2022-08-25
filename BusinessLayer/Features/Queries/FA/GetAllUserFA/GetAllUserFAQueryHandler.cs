using DataAccessLayer.Repositories.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.FA.GetAllUserFA
{
    public class GetAllUserFAQueryHandler : IRequestHandler<GetAllUserFAQueryRequest, GetAllUserFAQueryResponse>
    {
        private readonly IUserReadRepository _userReadRepository;

        public GetAllUserFAQueryHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task<GetAllUserFAQueryResponse> Handle(GetAllUserFAQueryRequest request, CancellationToken cancellationToken)
        {
            

            var users = await _userReadRepository.GetAll(false).ToListAsync();

            //.Select(u => new
            // {
            //     u.id,
            //     u.FirstName,
            //     u.LastName
            // })

            return new()
            {
                Users = users
            };
        }
    }
}
