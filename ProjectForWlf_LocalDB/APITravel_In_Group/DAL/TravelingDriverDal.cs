using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL;


namespace DAL
{
    public class TravelingDriverDal
    {
        public static int AddTraveling(TravelingDriver traveling)
        {
            int key;
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    Driver driver = ctx.Drivers.FirstOrDefault(w => w.Id == traveling.DriverId);
                    traveling.Driver = driver;
                    traveling.NumSeats = driver.NumberOfSeats;
                    ctx.TravelingDrivers.Add(traveling);
                    ctx.SaveChanges();
                }
                return traveling.TravelingIdDriver;
            }
            catch { throw; }
        }
        


        public static List<TravelingDriver> GetTravelings()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    return db.TravelingDrivers.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }
        public static List<TravelingDriver> GetTravelAttached(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    var q = db.Registerations.Where(w => w.TravelingDriver.Driver.Id == id ).Select(t=>t.TravelingDriver).ToList();
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

       

       

        public static List<TravelingDriver> GetTravelNotAttached(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    var travelingsD = db.TravelingDrivers.Where(t => t.DriverId == id).ToList();
                    List<TravelingDriver> travelingDNotReg = new List<TravelingDriver>();
                    var q = db.Registerations.Where(w => w.TravelingDriver.Driver.Id == id).Select(t => t.TravelingDriver).ToList();
                    foreach (var t in travelingsD)
                    {
                        var travelInReg = q.Where(r => r.TravelingIdDriver == t.TravelingIdDriver).FirstOrDefault();
                        if (travelInReg == null)
                            travelingDNotReg.Add(t);
                    }
                 
                    if (travelingDNotReg == null)
                        return null;
                    return travelingDNotReg;
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }
      

        public static TravelingDriver GetTraveling(int id)
        {

            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelingDrivers.FirstOrDefault(w => w.TravelingIdDriver == id);
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }

      

        public static List<TravelingDriver> GetTravelings(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    var q = db.TravelingDrivers.Where(w => w.DriverId == id).ToList();
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }



        public static bool UpdateTraveling(TravelingDriver traveling, int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelingDrivers.FirstOrDefault(w => w.TravelingIdDriver == id);
                    if (q == null)
                        return false;
                    q.DriverId = traveling.DriverId;
                    q.Weekday = traveling.Weekday;
                    q.Places = traveling.Places;
                    q.Time = traveling.Time;
                    q.FromDate = traveling.FromDate;
                    q.ToDate = traveling.ToDate;
                    q.Price = traveling.Price;
                    q.Source = traveling.Source;
                    q.Destination = traveling.Destination;
                    q.LatS = traveling.LatS;
                    q.LngS = traveling.LngS;
                    q.LatD = traveling.LatD;
                    q.LngD = traveling.LngD;
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch { throw; }

        }
        public static void DeleteAllTravelingRange(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    var travelRanges = db.TravelDriverRanges.Where(t => t.Id == id).ToList();

                    foreach (var t in travelRanges)
                    {
                        t.IsActive = false;
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }

        }
        public static void DeleteTravelingRange(TravelingDriver traveling)
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    var travelRanges = db.TravelDriverRanges
                        .Where(t => t.Id == traveling.TravelingIdDriver && t.Date.Date >= traveling.FromDate.Date && t.Date <= traveling.ToDate.Date).ToList();

                    foreach (var t in travelRanges)
                    {
                        t.IsActive = false;
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }
        public static bool DeleteTraveling(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelingDrivers.FirstOrDefault(w => w.TravelingIdDriver == id);
                    if (q == null)
                        return false;
                    q.IsActive = false;
                    DeleteAllTravelingRange(id);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch { throw; }
        }

       

        public static List<TravelingDriver> GetTravelingsToPassenger(TravelingPassenger travelingPassenger)
        {

            try
            {

                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    List<TravelingDriver> matchDrivers = db.TravelingDrivers.ToList()
                        .Where(w => w.IsActive ==true && isSuitibale(travelingPassenger, w) == true).ToList();
                    return matchDrivers;
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }
        public static bool isSuitibale(TravelingPassenger travelingPassenger, TravelingDriver travelingDriver)
        {
            if (IsSuitableDistance(travelingPassenger, travelingDriver))
                if (travelingDriver.Price <= travelingPassenger.Price)
                        if (travelingDriver.FromDate <= travelingPassenger.FromDate)
                            if (travelingDriver.ToDate >= travelingPassenger.ToDate)
                                if (travelingDriver.Time >= travelingPassenger.FromTime)
                                    if (travelingDriver.Time <= travelingPassenger.ToTime)
                                        if (travelingDriver.Weekday.Contains(travelingPassenger.Weekday))
                                            if (IsRangAvailable(travelingDriver, travelingPassenger))

                                                return true;
            return false;
        }

        private static bool IsSuitableDistance(TravelingPassenger travelingPassenger, TravelingDriver travelingDriver)
        {
            double distanceDriver, distancePassenger1, distancePassenger2;
            if (GoogelMaps.GooglePlaces(travelingPassenger.Destination, travelingDriver.Destination, false) >= 6.0)
                return false;
            if (GoogelMaps.GooglePlaces(travelingPassenger.Source, travelingDriver.Source, false) <= 6.0)
                return true;
            distanceDriver = GoogelMaps.GooglePlacesTime(travelingDriver.Source, travelingDriver.Destination, true);
            distancePassenger1 = GoogelMaps.GooglePlacesTime(travelingDriver.Source, travelingPassenger.Source, true);
            distancePassenger2 = GoogelMaps.GooglePlacesTime(travelingPassenger.Source, travelingDriver.Destination, true);

            if (distancePassenger1 + distancePassenger2 <= distanceDriver + 5)
                return true;
            return false;

        }

        private static bool IsRangAvailable(TravelingDriver travelingDriver, TravelingPassenger travelingPassenger)
        {
            TimeSpan timeSpan = travelingPassenger.ToDate.Date - travelingPassenger.FromDate.Date;
            int range = timeSpan.Days;
            bool isAvailable = true;
            DateTime date = travelingPassenger.FromDate;
            try
            {

                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    for (int i = 0; i < range; i++)
                    {
                        if (travelingPassenger.Weekday.Contains(((int)date.DayOfWeek + 1).ToString()))
                        {
                            var q = db.TravelDriverRanges.ToList().Where(w => w.Id == travelingDriver.TravelingIdDriver && w.Date.Date == date.Date).ToList();
                            if (q.Count != 0)
                                if (q.First().NumSeatsAvailable <= 0 || q.First().IsActive==false)
                                    return false;

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
            return isAvailable;
        }
    }
}