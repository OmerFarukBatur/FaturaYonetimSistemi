using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.Contact
{
    public class ContactReadRepository : ReadRepository<EntityLayer.Entities.Contact>, IContactReadRepository
    {
        public ContactReadRepository(FAYonetimiDBContext context) : base(context)
        {
        }
    }
}
