using DataAccessLayer.Repositories.FA;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.FA.CreateFA
{
    public class CreateFACommandHandler : IRequestHandler<CreateFACommandRequest, CreateFACommandResponse>
    {
        private readonly IFAWriteRepository _fAWriteRepository;

        public CreateFACommandHandler(IFAWriteRepository fAWriteRepository)
        {
            _fAWriteRepository = fAWriteRepository;
        }

        public async Task<CreateFACommandResponse> Handle(CreateFACommandRequest request, CancellationToken cancellationToken)
        {
            await _fAWriteRepository.AddAsync(new()
            {
                UserId = Guid.Parse(request.UserId),
                FAType = request.FAType,
                Amount = request.Amount,
                DueDate = request.DueDate,
                Status = request.Status
            });

            await _fAWriteRepository.SaveAsync();

            return new();
        }
    }
}
