using DataAccessLayer.Repositories.User;
using EntityLayer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.AdminUser.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UpdateUserCommandHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _userReadRepository.GetByIdAsync(request.Id);
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.TCNumber = request.TCNumber;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.HousingStatus = request.HousingStatus;
            user.Status = request.Status;
            user.UserRole = request.UserRole;

            await _userWriteRepository.SaveAsync();

            return new();
        }
    }
}
