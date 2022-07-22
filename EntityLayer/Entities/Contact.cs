using EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Contact : BaseEntity
    {
        public Guid UserId { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }

        public User User { get; set; }
    }
}
