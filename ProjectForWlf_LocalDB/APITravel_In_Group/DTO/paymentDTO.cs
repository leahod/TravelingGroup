using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class PaymentDTO
    {
        public int Id { get; set; }
        public int IdRegisteration { get; set; }
        public int IdPaymentKind { get; set; }
        public DateTime PaymentDate { get; set; }
        public double SumPay { get; set; }
        
    }
}
