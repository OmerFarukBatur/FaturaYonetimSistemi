using DataAccessLayer.Repositories.FA;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.FA.RemoveFA
{
    public class RemoveFACommandHandler : IRequestHandler<RemoveFACommandRequest, RemoveFACommandResponse>
    {
        private readonly IFAWriteRepository _fAWriteRepository;
        private readonly IFAReadRepository _fAReadRepository;

        public RemoveFACommandHandler(IFAWriteRepository fAWriteRepository, IFAReadRepository fAReadRepository)
        {
            _fAWriteRepository = fAWriteRepository;
            _fAReadRepository = fAReadRepository;
        }

        public async Task<RemoveFACommandResponse> Handle(RemoveFACommandRequest request, CancellationToken cancellationToken)
        {
            await _fAWriteRepository.RemoveAsync(request.Id);
            await _fAWriteRepository.SaveAsync();
            return new();
        }
    }
}
