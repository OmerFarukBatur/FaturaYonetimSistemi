using DataAccessLayer.Repositories.FA;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.FA.RemoveFA
{
    public class RemoveFACommandHandler : IRequestHandler<RemoveFACommandRequest, RemoveFACommandResponse>
    {
        private readonly IFAWriteRepository _fAWriteRepository;

        public RemoveFACommandHandler(IFAWriteRepository fAWriteRepository)
        {
            _fAWriteRepository = fAWriteRepository;
        }

        public async Task<RemoveFACommandResponse> Handle(RemoveFACommandRequest request, CancellationToken cancellationToken)
        {
            await _fAWriteRepository.RemoveAsync(request.Id);
            await _fAWriteRepository.SaveAsync();
            return new();
        }
    }
}
