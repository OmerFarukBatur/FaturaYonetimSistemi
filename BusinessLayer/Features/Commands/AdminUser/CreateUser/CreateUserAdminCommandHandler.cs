using BusinessLayer.Services.NotificationMessage;
using BusinessLayer.Services.PasswordEncrypt;
using DataAccessLayer.Repositories.User;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.AdminUser.CreateUser
{
    public class CreateUserAdminCommandHandler : IRequestHandler<CreateUserAdminCommandRequest, CreateUserAdminCommandResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IConfiguration _config;
        public CreateUserAdminCommandHandler(IUserWriteRepository userWriteRepository, IConfiguration config)
        {
            _userWriteRepository = userWriteRepository;
            _config = config;
        }

        public async Task<CreateUserAdminCommandResponse> Handle(CreateUserAdminCommandRequest request, CancellationToken cancellationToken)
        {

            string password = PasswordCreate();

            await _userWriteRepository.AddAsync(new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                TCNumber = request.TCNumber,
                PhoneNumber = request.PhoneNumber,
                HousingStatus = request.HousingStatus,
                UserRole = request.UserRole,
                Status = request.Status,
                PasswordHash = PasswordHash.PasswordHashCreate(password)
            });

            await _userWriteRepository.SaveAsync();
            request.PasswordHash = password;
            EmailSender emailSender = new EmailSender();
            emailSender.Sender(request,_config);
            return new();
        }

        public string PasswordCreate()
        {
            string password = "";

            char[] characterUpperCase = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '[', '{' };

            char[] characterLowerCase = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '}', '.' };

            char[] number = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '@', '#', '$', '%', '&', '*', '(', ')', '+', '=', '?', '-', '/', '<', '>', ',', ']' };

            Random rnd = new Random();

            password = Convert.ToString(characterUpperCase[rnd.Next(0, 28)].ToString());
            password += Convert.ToString(number[rnd.Next(0, 28)].ToString());
            password += Convert.ToString(characterLowerCase[rnd.Next(0, 28)].ToString());
            password += Convert.ToString(characterUpperCase[rnd.Next(0, 28)].ToString());
            password += Convert.ToString(number[rnd.Next(0, 28)].ToString());
            password += Convert.ToString(characterLowerCase[rnd.Next(0, 28)].ToString());

            return password;
        }
    }
}
