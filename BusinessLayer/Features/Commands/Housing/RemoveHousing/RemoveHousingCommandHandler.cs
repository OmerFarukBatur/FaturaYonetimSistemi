using DataAccessLayer.Repositories.Housing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.Housing.RemoveHousing
{
    public class RemoveHousingCommandHandler : IRequestHandler<RemoveHousingCommandRequest, RemoveHousingCommandResponse>
    {
        private readonly IHousingWriteRepository _housingWriteRepository;

        public RemoveHousingCommandHandler(IHousingWriteRepository housingWriteRepository)
        {
            _housingWriteRepository = housingWriteRepository;
        }

        public async Task<RemoveHousingCommandResponse> Handle(RemoveHousingCommandRequest request, CancellationToken cancellationToken)
        {
            await _housingWriteRepository.RemoveAsync(request.Id);
            await _housingWriteRepository.SaveAsync();

            return new();
        }
    }
}
