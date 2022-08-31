using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels.Vehicle
{
    public class VM_GetAllVehicle
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BlockNumber { get; set; }
        public int HousNumber { get; set; }
        public string id { get; set; }
        public String PlateNumber { get; set; }
        public String VehicleType { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
