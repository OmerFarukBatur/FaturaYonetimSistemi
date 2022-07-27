using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.FA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.FA
{
    public class FAWriteRepository : WriteRepository<EntityLayer.Entities.FA>, IFAWriteRepository
    {
        public FAWriteRepository(FAYonetimiDBContext context) : base(context)
        {
        }
    }
}
