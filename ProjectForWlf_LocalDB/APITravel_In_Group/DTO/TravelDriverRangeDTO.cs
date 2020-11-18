using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DTO
{
   public class TravelDriverRangeDTO
    {
        public int Identity { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumSeatsAvailable { get; set; }
        public bool IsActive { get; set; }

    }
}
