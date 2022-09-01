using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels.Housing
{
    public class VM_CreateHousing
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string id { get; set; }
        public string BlockNumber { get; set; }
        public int HousNumber { get; set; }        
        public string HousType { get; set; }
        public int FloorNumber { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
