using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.FA.RemoveFA
{
    public class RemoveFACommandRequest : IRequest<RemoveFACommandResponse>
    {
        public string Id { get; set; }
    }
}
