using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;


namespace DAL
{
    public class TravelDriverRangeDAL
    {
        public static List<TravelDriverRange> GetTravelRanges()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    return db.TravelDriverRanges.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static void AddTravelRange(TravelingDriver travelingDriver)
        {
            int range;
            TimeSpan timeSpan;
            DateTime date= travelingDriver.FromDate;
           
           
            try
            {
              
            using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    Driver driver = ctx.Drivers.FirstOrDefault(w => w.Id == travelingDriver.DriverId);
                    travelingDriver.Driver = driver;
                    
                    timeSpan =travelingDriver.ToDate.Date - travelingDriver.FromDate.Date;
                    range = timeSpan.Days;

                    for (int i = 0; i < range; i++)
                    {
                        TravelDriverRange travelDateRange = new TravelDriverRange()
                        {
                            Id = travelingDriver.TravelingIdDriver,
                            NumSeatsAvailable = travelingDriver.Driver.NumberOfSeats,
                            Date = date,
                            IsActive = true
                        };
                        if (travelingDriver.Weekday.Contains(((int)date.DayOfWeek + 1).ToString()))
                        {
                            travelDateRange.TravelingDriver = ctx.TravelingDrivers.FirstOrDefault(w => w.TravelingIdDriver == travelDateRange.Id);
                            ctx.TravelDriverRanges.Add(travelDateRange);
                          
                        }
                        ctx.SaveChanges();
                       date= date.Date.AddDays(1);
                       
                    }
                    

                }
            }
            catch { throw; }
        }

        public static List<TravelDriverRange> GetTravelNow()
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelDriverRanges.ToList().Where
                        (w => w.Date.Date== DateTime.Now.Date &&
                          (w.TravelingDriver.Time -DateTime.Now.TimeOfDay).TotalHours<=2 && w.IsActive==true)
                          .ToList();
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }

        public static TravelDriverRange GetTravelRange(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelDriverRanges.FirstOrDefault(w => w.Identity == id);
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }
        public static TravelDriverRange GetTravelRangeByIdentity(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelDriverRanges.FirstOrDefault(w => w.Identity == id);
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }


        public static bool UpdateTravelRange(TravelDriverRange travelDateRange, int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelDriverRanges.FirstOrDefault(w => w.Id == id);
                    if (q == null)
                        return false;
                    q.Id = travelDateRange.Id;
                    q.Date = travelDateRange.Date;
                    q.NumSeatsAvailable = travelDateRange.NumSeatsAvailable;
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
                    var q = ctx.TravelDriverRanges.FirstOrDefault(w => w.Id == id);
                    if (q == null)
                        return false;
                    ctx.TravelDriverRanges.Remove(q);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch { throw; }
        }
    }
}