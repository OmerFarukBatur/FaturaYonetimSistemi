using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.FA.GetByIdFA
{
    public class GetByIdFAQueryResponse 
    {
        public object Users { get; set; }
        public EntityLayer.Entities.FA FA { get; set; }

    }
}
