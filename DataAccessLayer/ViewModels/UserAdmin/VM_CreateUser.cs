using System;

namespace DataAccessLayer.ViewModels.UserAdmin
{
    public class VM_CreateUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Password { get; set; }
        public String TCNumber { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public Boolean HousingStatus { get; set; }
        public Boolean Status { get; set; }
        public bool UserRole { get; set; }
    }
}
