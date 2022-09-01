using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.Housing.CreateHousing
{
    public class CreateHousingCommandRequest : IRequest<CreateHousingCommandResponse>
    {
        public string UserId { get; set; }
        public string BlockNumber { get; set; }
        public int HousNumber { get; set; }
        public string HousType { get; set; }
        public int FloorNumber { get; set; }
        public bool Status { get; set; }
    }
}
