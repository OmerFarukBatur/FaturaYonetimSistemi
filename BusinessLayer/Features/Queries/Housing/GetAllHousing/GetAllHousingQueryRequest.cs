﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.Housing.GetAllHousing
{
    public class GetAllHousingQueryRequest : IRequest<GetAllHousingQueryResponse>
    {
    }
}
