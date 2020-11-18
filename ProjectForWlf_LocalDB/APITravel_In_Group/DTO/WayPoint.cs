using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WayPoint
    {
        public double LatSource { get; set; }
        public double LatDestination { get; set; }
        public double LngSource { get; set; }
        public double LngDestination { get; set; }
        public Point[] ListPoint { get; set; }


    }
}
