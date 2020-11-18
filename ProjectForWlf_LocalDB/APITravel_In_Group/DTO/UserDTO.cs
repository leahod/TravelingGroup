using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public  class UserDTO
    {
        public string Identity { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public   bool  Gender { get; set; }
        public string Cellphone { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime Validity { get; set; }
        public string Cvv { get; set; }
        public string IdCardOwner { get; set; }
     
    }
}
