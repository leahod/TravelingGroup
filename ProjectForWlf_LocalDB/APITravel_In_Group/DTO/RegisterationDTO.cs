using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class RegisterationDTO
    {
        public int Id { get; set; }
        public int travelingIdDriver { get; set; }
        public int travelingIdPassenger { get; set; }
        public DateTime Date { get; set; }

    }
}
