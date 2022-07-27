using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.User
{
    public interface IUserReadRepository : IReadRepository<EntityLayer.Entities.User>
    {
    }
}
