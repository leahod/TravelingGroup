using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class RegistrationDateRangeDTO
    {
        public int Id { get; set; }
       
        public DateTime DateInRange  { get; set; }

        public bool IsActive { get; set; }
        public int NumPassengers { get; set; }
        public int NumComplainants { get; set; }
        public bool IsComplain  { get; set; }
    }
}
