using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.Housing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.Housing
{
    public class HousingWriteRepository : WriteRepository<EntityLayer.Entities.Housing>, IHousingWriteRepository
    {
        public HousingWriteRepository(FAYonetimiDBContext context) : base(context)
        {
        }
    }
}
