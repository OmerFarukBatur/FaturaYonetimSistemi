using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.FA.UpdateFA
{
    public class UpdateFACommandRequest : IRequest<UpdateFACommandResponse>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FAType { get; set; }
        public float Amount { get; set; }
        public DateTime DueDate { get; set; }
        public Boolean Status { get; set; }
    }
}
