using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.Housing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.Housing
{
    public class HousingReadRepository : ReadRepository<EntityLayer.Entities.Housing>, IHousingReadRepository
    {
        public HousingReadRepository(FAYonetimiDBContext context) : base(context)
        {
        }
    }
}
