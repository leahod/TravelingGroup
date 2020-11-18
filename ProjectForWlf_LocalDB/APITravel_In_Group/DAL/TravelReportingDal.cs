using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL
{
    public class TravelReportingDal
    {

        public static TravelReporting GetTravelReport(int travelingIdDriver, DateTime dateInRange)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelReportings.FirstOrDefault(w => w.IdTravelingDriver == travelingIdDriver && w.Date.Date == dateInRange.Date);
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }

        }



        public static void AddTravelReport(int travelingId, DateTime date)
        {

            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var travelDate = ctx.TravelDriverRanges.FirstOrDefault(t => t.Id == travelingId && t.Date.Date == date.Date);
                    var travel = ctx.TravelingDrivers.FirstOrDefault(t => t.TravelingIdDriver == travelingId  );
                    int numPassenger = travel.NumSeats - travelDate.NumSeatsAvailable;
                    TravelReporting travelReporting = new TravelReporting()
                    {
                        IdTravelingDriver = travelingId,
                        Date = date,
                        NumPassengers =numPassenger ,
                        NumComplainants = 0,
                        IsPay = false

                    };
                    ctx.TravelReportings.Add(travelReporting);
                    ctx.SaveChanges();

                }

            }
            catch { throw; }
        }

        public static TravelReporting AddComplaint(int travelingIdDriver, DateTime dateInRange)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelReportings.FirstOrDefault(w => w.IdTravelingDriver == travelingIdDriver && w.Date.Date == dateInRange.Date);
                    if (q == null)
                        return null;
                    q.NumComplainants = q.NumComplainants + 1;
                    ctx.SaveChanges();
                    return q;
                }
            }
            catch { throw; }
        }

        public static void UpdatePay(int idTravelingDriver, DateTime date)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelReportings.FirstOrDefault(w => w.IdTravelingDriver == idTravelingDriver && w.Date.Date == date.Date);
                    if (q == null)
                        return  ;
                    q.IsPay = true;
                    ctx.SaveChanges();
                }
            }
            catch { throw; }

        }
    }
}

