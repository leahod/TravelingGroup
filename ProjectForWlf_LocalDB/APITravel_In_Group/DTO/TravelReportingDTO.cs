using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TravelReportingDTO
    {
        public int IdTravelingDriver { get; set; }
        public DateTime Date { get; set; }
        public int NumPassengers { get; set; }
        public int NumComplainants { get; set; }
        public bool IsPay { get; set; }

    }
}
