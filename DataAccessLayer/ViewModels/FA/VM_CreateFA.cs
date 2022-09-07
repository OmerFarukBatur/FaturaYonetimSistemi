using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels.FA
{
    public class VM_CreateFA
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BlockNumber { get; set; }
        public int HousNumber { get; set; }
        public string id { get; set; }
        public string FAType { get; set; }
        public float Amount { get; set; }
        public Boolean Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
