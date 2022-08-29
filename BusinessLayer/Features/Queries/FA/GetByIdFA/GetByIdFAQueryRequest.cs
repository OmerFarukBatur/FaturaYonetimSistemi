using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.FA.GetByIdFA
{
    public class GetByIdFAQueryRequest : IRequest<GetByIdFAQueryResponse>
    {
        public string Id { get; set; }
    }
}
