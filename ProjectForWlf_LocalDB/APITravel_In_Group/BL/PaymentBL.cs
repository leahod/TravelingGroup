using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BL.Converters;
using DAL;
using DAL.EF;

namespace BL
{
    public class PaymentBL
    {
        /// <summary> find payment by identity of Passenger
        /// </summary>
        public static List<PaymentDTO> GetPaymentsP(int id)
        {
            return PaymentConverters.GetListPaymentDTO(PaymentDal.GetPaymentsP(id));
        }

        /// <summary> find payment by identity of Driver
        /// </summary>
        public static List<PaymentDTO> GetPaymentsD(int id)
        {
            return PaymentConverters.GetListPaymentDTO(PaymentDal.GetPaymentsD(id));
        }

        /// <summary> pay to driver about cancle the traveling
        /// </summary>
        public static void PayToDriverCancel(int id, DateTime fromDate, DateTime toDate)
        {
            PaymentDal.AddPaymentCancelToD(id, fromDate, toDate);
        }

        /// <summary> pay to passenger about cancle the traveling
        /// </summary>
        public static void PayToPassengerCancel(RegisterationDTO reg, DateTime fromDate, DateTime toDate)
        {
            PaymentDal.AddPaymentCancelToP(RegisterationConverters.GetRegisteration(reg), fromDate, toDate);
        }
        /// <summary> pay to passenger about  the traveling
        /// </summary>
        public static void PayToDriver(object state)
        {
            List<Registeration> registerations = RegisterationDal.GetTravelingsToPay();
            PaymentDal.AddPayments(registerations);
        }
    }
}

