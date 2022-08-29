using DataAccessLayer.Repositories.FA;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.FA.UpdateFA
{
    public class UpdateFACommandHandler : IRequestHandler<UpdateFACommandRequest, UpdateFACommandResponse>
    {
        private readonly IFAWriteRepository _fAWriteRepository;
        private readonly IFAReadRepository _fAReadRepository;

        public UpdateFACommandHandler(IFAWriteRepository fAWriteRepository, IFAReadRepository fAReadRepository)
        {
            _fAWriteRepository = fAWriteRepository;
            _fAReadRepository = fAReadRepository;
        }

        public async Task<UpdateFACommandResponse> Handle(UpdateFACommandRequest request, CancellationToken cancellationToken)
        {
            EntityLayer.Entities.FA fa =  await _fAReadRepository.GetByIdAsync(request.Id);

            fa.UserId = Guid.Parse(request.UserId);
            fa.FAType = request.FAType;
            fa.Amount = request.Amount;
            fa.DueDate = request.DueDate;
            fa.Status = request.Status;

            await _fAWriteRepository.SaveAsync();

            return new();
        }
    }
}
