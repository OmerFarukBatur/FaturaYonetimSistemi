using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.FA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.FA
{
    public class FAReadRepository : ReadRepository<EntityLayer.Entities.FA>, IFAReadRepository
    {
        public FAReadRepository(FAYonetimiDBContext context) : base(context)
        {
        }
    }
}
