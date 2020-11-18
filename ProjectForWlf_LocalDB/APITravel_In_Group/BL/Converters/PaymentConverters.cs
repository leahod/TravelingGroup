using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DTO;

namespace BL.Converters
{
   public class PaymentConverters
    {
        public static Payment GetPayment(PaymentDTO paymentDTO)
        {
            Payment payment = new Payment()
            {
                Id = paymentDTO.Id,
                IdRegisteration = paymentDTO.IdPaymentKind,
                IdPaymentKind = paymentDTO.IdPaymentKind,
                PaymentDate = paymentDTO.PaymentDate,
                SumPay = paymentDTO.SumPay 

            };
            return payment;
        }

        public static PaymentDTO GetPaymentDTO(Payment payment)
        {
            if (payment == null)
                return null;
            PaymentDTO paymentDTO = new PaymentDTO()
            {
                Id = payment.Id,
                IdRegisteration = payment.IdPaymentKind,
                IdPaymentKind = payment.IdPaymentKind,
                PaymentDate = payment.PaymentDate,
                SumPay = payment.SumPay
            };
            return paymentDTO;
        }
        public static List<PaymentDTO> GetListPaymentDTO(List<Payment> lpayment)
        {
            List<PaymentDTO> l = new List<PaymentDTO>();
            lpayment.ForEach(u => l.Add(GetPaymentDTO(u)));
            return l;

        }
        public static List<Payment> GetListPayment(List<PaymentDTO> lpayment)
        {
            List<Payment> l = new List<Payment>();
            lpayment.ForEach(u => l.Add(GetPayment(u)));
            return l;

        }
    }






}
 
