using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PaymentDal
    {

        public static List<Payment> GetPayments()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    return db.Payments.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static Payment GetPayment(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Payments.FirstOrDefault(w => w.Id == id);
                    if (q == null)
                    {
                        Payment payment = new Payment() { Id = id };
                        return payment;
                    }
                    return q;
                }
            }
            catch { throw; }
        }

        public static List<Payment> GetPaymentsP(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    return db.Payments.Where(p => p.Registeration.TravelingPassenger.PassengerId == id).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
                throw new Exception("error");
            }
        }

        public static List<Payment> GetPaymentsD(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    return db.Payments.Where(p => p.Registeration.TravelingDriver.DriverId == id).ToList();
                }
            }
            catch (Exception e)
            {
                return null;
                throw new Exception("error");
            }
        }

        public static void AddPaymentCancelToP(Registeration registeration, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    if (registeration == null)
                        return;
                    TravelingPassenger traveling = ctx.TravelingPassengers.FirstOrDefault(d => d.TravelingIdPassenger == registeration.TravelingIdPassenger);
                    if (traveling == null)
                        return;
                    Payment payment = new Payment() { IdPaymentKind = 3, PaymentDate = DateTime.Now, SumPay = traveling.Price };
                    payment.Registeration = registeration;
                    payment.IdRegisteration = registeration.Id;
                    ctx.Payments.Add(payment);
                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }

        public static void AddPaymentCancelToD(int id, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    Registeration registeration = ctx.Registerations.FirstOrDefault(r => r.Id == id);
                    if (registeration == null)
                        return;
                    TravelingDriver traveling = ctx.TravelingDrivers.FirstOrDefault(d => d.TravelingIdDriver == registeration.TravelingIdDriver);
                    if (traveling == null)
                        return;
                    Payment payment = new Payment() { IdPaymentKind = 2, PaymentDate = DateTime.Now, SumPay = traveling.Price / 2 };
                    payment.Registeration = registeration;
                    payment.IdRegisteration = registeration.Id;
                    ctx.Payments.Add(payment);
                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }

        public static void AddPayments(List<Registeration> lTravelingsToPay)
        {
            lTravelingsToPay.ForEach(t => AddPayment
            (new Payment() { Id = 0, IdPaymentKind = 1, IdRegisteration = t.Id, PaymentDate = DateTime.Now, SumPay = t.TravelingDriver.Price }));
        }

        public static Payment AddPayment(Payment payment)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    ctx.Payments.Add(payment);
                    ctx.SaveChanges();
                }
                return payment;
            }
            catch (Exception e)
            {
                return new Payment();
            }
        }
    }
}

