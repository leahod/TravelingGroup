using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Route
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public List<Station> listStation { get; set; }
    }
}
