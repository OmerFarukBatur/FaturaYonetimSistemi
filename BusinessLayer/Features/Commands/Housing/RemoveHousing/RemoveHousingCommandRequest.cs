using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.Housing.RemoveHousing
{
    public class RemoveHousingCommandRequest : IRequest<RemoveHousingCommandResponse>
    {
        public string Id { get; set; }
    }
}
