using DataAccessLayer.Repositories.Housing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.Housing.UpdateHousing
{
    public class UpdateHousingCommandHandler : IRequestHandler<UpdateHousingCommandRequest, UpdateHousingCommandResponse>
    {
        private readonly IHousingReadRepository _housingReadRepository;
        private readonly IHousingWriteRepository _housingWriteRepository;

        public UpdateHousingCommandHandler(IHousingReadRepository housingReadRepository, IHousingWriteRepository housingWriteRepository)
        {
            _housingReadRepository = housingReadRepository;
            _housingWriteRepository = housingWriteRepository;
        }

        public async Task<UpdateHousingCommandResponse> Handle(UpdateHousingCommandRequest request, CancellationToken cancellationToken)
        {
            EntityLayer.Entities.Housing housing = await _housingReadRepository.GetByIdAsync(request.Id);
            housing.UserId = Guid.Parse(request.UserId);
            housing.BlockNumber = request.BlockNumber;
            housing.HousNumber = request.HousNumber;
            housing.FloorNumber = request.FloorNumber;
            housing.HousType = request.HousType;
            housing.Status = request.Status;

            await _housingWriteRepository.SaveAsync();

            return new();
        }
    }
}
