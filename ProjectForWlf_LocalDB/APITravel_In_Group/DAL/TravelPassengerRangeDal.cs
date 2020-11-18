using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;


namespace DAL
{
  public  class TravelPassengerRangeDal
    {
        public static List<TravelPassengerRange> GetTravelRanges()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    return db.TravelPassengerRanges.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static void AddTravelRange(TravelingPassenger travelingPassenger)
        {
            int range;
            TimeSpan timeSpan;
            DateTime date = travelingPassenger.FromDate;


            try
            {

                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    Passenger passenger = ctx.Passengers.FirstOrDefault(w => w.Id == travelingPassenger.PassengerId);
                    travelingPassenger.Passenger = passenger;

                    timeSpan = travelingPassenger.ToDate.Date - travelingPassenger.FromDate.Date;
                    range = timeSpan.Days;

                    for (int i = 0; i < range; i++)
                    {
                        TravelPassengerRange travelDateRange = new TravelPassengerRange()
                        {
                            Id = travelingPassenger.TravelingIdPassenger,
                            Date = date,
                            IsActive = true
                        };
                        if (travelingPassenger.Weekday.Contains(((int)date.DayOfWeek + 1).ToString()))
                        {
                            travelDateRange.TravelingPassenger = ctx.TravelingPassengers.FirstOrDefault(w => w.TravelingIdPassenger == travelDateRange.Id);
                            ctx.TravelPassengerRanges.Add(travelDateRange);

                        }
                        ctx.SaveChanges();
                        date = date.Date.AddDays(1);

                    }


                }
            }
            catch { throw; }
        }

        public static TravelPassengerRange GetTravelRange(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelPassengerRanges.FirstOrDefault(w => w.Id == id);
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }


        public static bool UpdateTravelRange(TravelPassengerRange travelDateRange, int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelPassengerRanges.FirstOrDefault(w => w.Id == id);
                    if (q == null)
                        return false;
                    q.Id = travelDateRange.Id;
                    q.Date = travelDateRange.Date;
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch { throw; }

        }

        public static bool DeleteTravelRange(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelPassengerRanges.FirstOrDefault(w => w.Id == id);
                    if (q == null)
                        return false;
                    ctx.TravelPassengerRanges.Remove(q);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch { throw; }
        }
    }
}
 
