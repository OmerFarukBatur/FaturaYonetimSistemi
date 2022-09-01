using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.Housing.GetByIdHousing
{
    public class GetByIdHousingQueryResponse
    {
        public object Users { get; set; }
        public EntityLayer.Entities.Housing Housing { get; set; }
    }
}
