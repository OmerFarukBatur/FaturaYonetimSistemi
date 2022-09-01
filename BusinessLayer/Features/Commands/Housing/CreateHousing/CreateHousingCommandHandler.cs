using DataAccessLayer.Repositories.Housing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.Housing.CreateHousing
{
    public class CreateHousingCommandHandler : IRequestHandler<CreateHousingCommandRequest, CreateHousingCommandResponse>
    {
        private readonly IHousingWriteRepository _housingWriteRepository;

        public CreateHousingCommandHandler(IHousingWriteRepository housingWriteRepository)
        {
            _housingWriteRepository = housingWriteRepository;
        }

        public async Task<CreateHousingCommandResponse> Handle(CreateHousingCommandRequest request, CancellationToken cancellationToken)
        {
            await _housingWriteRepository.AddAsync(new()
            {
                UserId = Guid.Parse(request.UserId),
                BlockNumber = request.BlockNumber,
                FloorNumber = request.FloorNumber,
                HousNumber = request.HousNumber,
                HousType = request.HousType,
                Status = request.Status
            });

            await _housingWriteRepository.SaveAsync();

            return new();
        }
    }
}
