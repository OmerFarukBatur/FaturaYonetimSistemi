using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.FA.CreateFA
{
    public class CreateFACommandRequest : IRequest<CreateFACommandResponse>
    {
        public string UserId { get; set; }
        public string FAType { get; set; }
        public int Amount { get; set; }
        public DateTime DueDate { get; set; }
        public Boolean Status { get; set; }

    }
}
