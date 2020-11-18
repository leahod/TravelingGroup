using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL;

namespace DAL
{
    public class TravelingPassengerDal
    {
        private static bool IsSuitableDistance(TravelingPassenger travelingPassenger, TravelingDriver travelingDriver)
        {
            double distanceDriver, distancePassenger1, distancePassenger2;

            if (GoogelMaps.GooglePlaces(travelingPassenger.Source, travelingDriver.Source, false) <= 6.0
                   && GoogelMaps.GooglePlaces(travelingPassenger.Destination, travelingDriver.Destination, false) <= 6.0)
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
                                if (q.First().NumSeatsAvailable <= 0)
                                    isAvailable = false;
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

        public static int AddTraveling(TravelingPassenger traveling)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {

                    Passenger passenger = ctx.Passengers.FirstOrDefault(w => w.Id == traveling.PassengerId);
                    traveling.Passenger = passenger;
                    ctx.TravelingPassengers.Add(traveling);
                    ctx.SaveChanges();
                    return traveling.TravelingIdPassenger;
                }
            }
            catch { throw; }
        }
        public static List<TravelingPassenger> GetTravelings()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    return db.TravelingPassengers.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static List<TravelingPassenger> GetTravelings(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    var q = db.TravelingPassengers.Where(w => w.PassengerId == id).ToList();
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

        public static List<TravelingPassenger> GetTravelSuitableP(TravelingDriver travelingDriver)
        {
            try
            {

                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    List<TravelingPassenger> matchPassengers = db.TravelingPassengers.ToList()
                        .Where(w => w.IsEmbedded == false && w.IsActive == true && isSuitibale(w, travelingDriver) == true).ToList();
                    return matchPassengers;
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
                                if (travelingDriver.Time <= travelingPassenger.FromTime)
                                    if (travelingDriver.Time >= travelingPassenger.ToTime)
                                        if (travelingDriver.Weekday.Contains(travelingPassenger.Weekday))
                                            if (IsRangAvailable(travelingDriver, travelingPassenger))

                                                return true;
            return false;

        }


        public static List<TravelingPassenger> GetTravelAttached(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    var q = db.TravelingPassengers.Where(w => w.PassengerId == id && w.IsEmbedded == true).ToList();
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
        public static List<TravelingPassenger> GetTravelNotAttached(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    var q = db.TravelingPassengers.Where(w => w.PassengerId == id && w.IsEmbedded == false).ToList();
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

        public static TravelingPassenger GetTraveling(int id)
        {

            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelingPassengers.FirstOrDefault(w => w.TravelingIdPassenger == id);
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }

        public static bool UpdateTraveling(TravelingPassenger traveling)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.TravelingPassengers.FirstOrDefault(w => w.TravelingIdPassenger == traveling.TravelingIdPassenger);
                    if (q == null)
                        return false;
                    q.PassengerId = traveling.PassengerId;
                    q.Weekday = traveling.Weekday;
                    q.Places = traveling.Places;
                    q.FromTime = traveling.FromTime;
                    q.ToTime = traveling.ToTime;
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
                    var travelRanges = db.TravelPassengerRanges.Where(t => t.Id == id).ToList();

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
        public static void DeleteTravelingRange(TravelingPassenger traveling)
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    var travelRanges = db.TravelPassengerRanges.ToList()
                        .Where(t => t.Id == traveling.TravelingIdPassenger && t.Date.Date >= traveling.FromDate.Date && t.Date <= traveling.ToDate.Date).ToList();

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
                    var q = ctx.TravelingPassengers.FirstOrDefault(w => w.TravelingIdPassenger == id);
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
    }
}