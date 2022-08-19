﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Commands.AdminUser.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public string Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String TCNumber { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public Boolean HousingStatus { get; set; }
        public Boolean Status { get; set; }
        public Boolean UserRole { get; set; }
    }
}
