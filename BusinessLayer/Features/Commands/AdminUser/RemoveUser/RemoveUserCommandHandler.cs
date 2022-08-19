using DataAccessLayer.Repositories.User;
using EntityLayer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.AdminUser.RemoveUser
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommandRequest, RemoveUserCommandResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;

        public RemoveUserCommandHandler(IUserWriteRepository userWriteRepository)
        {
            _userWriteRepository = userWriteRepository;
        }

        public async Task<RemoveUserCommandResponse> Handle(RemoveUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userWriteRepository.RemoveAsync(request.Id);
            await _userWriteRepository.SaveAsync();
            return new();
        }
    }
}
