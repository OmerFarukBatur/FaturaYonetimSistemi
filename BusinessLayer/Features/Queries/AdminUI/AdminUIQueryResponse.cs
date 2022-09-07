using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Features.Queries.AdminUI
{
    public class AdminUIQueryResponse
    {
        public float AllAmountSum { get; set; }
        public float AmountTrueSum { get; set; }
        public float OneWeekSum { get; set; }
        public int OneDayMessage { get; set; }
    }
}
