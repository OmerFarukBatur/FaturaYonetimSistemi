using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.User
{
    public class UserWriteRepository : WriteRepository<EntityLayer.Entities.User>, IUserWriteRepository
    {
        public UserWriteRepository(FAYonetimiDBContext context) : base(context)
        {
        }
    }
}
