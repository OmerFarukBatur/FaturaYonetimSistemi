using EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class User : BaseEntity
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PasswordHash { get; set; }
        public String TCNumber { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public Boolean HousingStatus { get; set; }
        //public Boolean UserState { get; set; }
        public Boolean UserRole { get; set; }

        public ICollection<FA> FAs { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Housing> Housings { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
