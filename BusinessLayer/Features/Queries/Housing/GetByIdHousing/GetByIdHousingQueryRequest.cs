using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.Housing.GetByIdHousing
{
    public class GetByIdHousingQueryRequest : IRequest<GetByIdHousingQueryResponse>
    {
        public string Id { get; set; }
    }
}
