using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DriverDTO : UserDTO
    {
        public int Id { get; set; }
        public int NumberOfSeats { get; set; }
        public string CarDescription { get; set; }
        
      
    }
}
