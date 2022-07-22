using EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class FA : BaseEntity
    {
        public Guid UserId { get; set; }
        public String FAType { get; set; }
        public int Amount { get; set; }
        public DateTime DueDate { get; set; }

        public User User { get; set; }
    }
}
