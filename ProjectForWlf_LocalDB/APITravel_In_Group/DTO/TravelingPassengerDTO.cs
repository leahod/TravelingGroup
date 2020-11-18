using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TravelingPassengerDTO
    {
        public int TravelingIdPassenger { get; set; }
        public int PassengerId { get; set; }
        public string Weekday { get; set; }
        public string Places { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public double Price { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public double LatS { get; set; }
        public double LngS { get; set; }
        public double LatD { get; set; }
        public double LngD { get; set; }
        public bool IsEmbedded { get; set; }
        public bool IsActive { get; set; }
    }
}
