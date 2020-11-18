using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL
{
    public class RegisterationDal
    {
        public static List<Registeration> GetRegisterations()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    return db.Registerations.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static Registeration GetRegisterationById(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Registerations.FirstOrDefault(w => w.Id == id);
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }

        public static Registeration GetRegisterationByPassengerId(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Registerations.FirstOrDefault(w => w.TravelingIdPassenger == id);
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }

        public static List<Registeration> GetRegisterationByDriverId(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Registerations.Where(w => w.TravelingIdDriver == id).ToList();
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }

        public static List<Registeration> GetRegByIdDInRange(int id, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Registerations.Where(w => w.TravelingIdDriver == id).ToList();
                    List<Registeration> registerations = new List<Registeration>();
                    foreach (var r in q)
                    {
                        if (isInRange(r.TravelingPassenger, fromDate, toDate))
                            registerations.Add(r);
                    }
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }

        public static List<Registeration> GetRegByIdInDate(int id, DateTime date)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Registerations.Where(w => w.TravelingIdDriver == id).ToList();
                    List<Registeration> registerations = new List<Registeration>();
                    foreach (var r in q)
                    {
                        if (isInDate(r.Id, date))
                            registerations.Add(r);
                    }
                    if (registerations.Count() == 0)
                        return null;
                    return registerations;
                }
            }
            catch { throw; }
        }

        private static bool isInDate(int id, DateTime date)
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    var q = db.RegistrationDateRanges.FirstOrDefault(w => w.Id == id && w.DateInRange == date);
                    if (q == null)
                        return false;
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static bool isInRange(TravelingPassenger travelingPassenger, DateTime fromDate, DateTime toDate)
        {
            if (travelingPassenger.FromDate.Date >= fromDate.Date && travelingPassenger.ToDate.Date <= toDate.Date)
                return true;
            return false;
        }

        public static List<Registeration> GetTravelingsToPay()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    List<Registeration> registerations = db.Registerations.ToList().Where(w => isToPayNow(w) == true).ToList();
                    if (registerations == null)
                        return null;
                    return registerations;
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        private static bool isToPayNow(Registeration registeration)
        {
            DateTime d = new DateTime();
            d = DateTime.Now;
            int p = Convert.ToInt32(d.DayOfWeek);
            TimeSpan timeSpan = d.TimeOfDay - registeration.TravelingDriver.Time;
            if (d >= registeration.TravelingPassenger.FromDate)
                if (d <= registeration.TravelingPassenger.ToDate)
                    if (registeration.TravelingPassenger.Weekday.Contains(Convert.ToString(p)))
                        if (timeSpan.TotalMinutes <= 30)
                            return true;
            return false;
        }

        public static bool DeleteRegisteration(int id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Registerations.FirstOrDefault(w => w.Id == id);
                    if (q == null)
                        return false;
                    ctx.Registerations.Remove(q);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch { throw; }
        }

        public static void AddRegisteration(Registeration registeration)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    TravelingDriver travelingDriver = ctx.TravelingDrivers.FirstOrDefault(w => w.TravelingIdDriver == registeration.TravelingIdDriver);
                    TravelingPassenger travelingPassenger = ctx.TravelingPassengers.FirstOrDefault(w => w.TravelingIdPassenger == registeration.TravelingIdPassenger);
                    registeration.TravelingDriver = travelingDriver;
                    registeration.TravelingPassenger = travelingPassenger;
                    travelingPassenger.IsEmbedded = true;

                    TimeSpan timeSpan = registeration.TravelingPassenger.ToDate - registeration.TravelingPassenger.FromDate;
                    int range = timeSpan.Days;
                    DateTime date = registeration.TravelingPassenger.FromDate;
                    TimeSpan ts = new TimeSpan(registeration.TravelingDriver.Time.Hours, registeration.TravelingDriver.Time.Minutes, registeration.TravelingDriver.Time.Seconds);
                    date = date + ts;

                    Registeration newRegisteration = new Registeration()
                    {
                        TravelingIdDriver = registeration.TravelingIdDriver,
                        TravelingIdPassenger = registeration.TravelingIdPassenger,
                        Date = DateTime.Now,
                        TravelingDriver = travelingDriver,
                        TravelingPassenger = travelingPassenger
                    };
                    ctx.Registerations.Add(newRegisteration);
                    ctx.SaveChanges();

                    //לולאה על כל טווח הנסיעה
                    for (int i = 0; i < range; i++)
                    {
                        if (registeration.TravelingPassenger.Weekday.Contains(((int)date.DayOfWeek + 1).ToString()))
                        {
                            var q = ctx.TravelDriverRanges.FirstOrDefault(t => t.Id == travelingDriver.TravelingIdDriver && t.Date == date.Date);
                            q.NumSeatsAvailable = q.NumSeatsAvailable - 1;

                            RegistrationDateRange registrationDateRange = new RegistrationDateRange()
                            {
                                Id = newRegisteration.Id,
                                DateInRange = date,
                                IsActive = true,
                                IsComplain = false,
                                NumComplainants = 0,
                                NumPassengers = 1

                            };
                             registrationDateRange.Registeration = newRegisteration;
                            ctx.RegistrationDateRanges.Add(registrationDateRange);
                            ctx.SaveChanges();
                        }
                        date = date.AddDays(1);
                    }
                }
            }
            catch { throw; }
        }

        public static List<Registeration> GetTravelingsNow()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    List<Registeration> registerations = db.Registerations.ToList().Where(w => isNow(w) == true).ToList();
                    if (registerations == null)
                        return null;
                    return registerations;
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static bool isNow(Registeration registation)
        {
            DateTime d = new DateTime();
            d = DateTime.Now;
            int p = Convert.ToInt32(d.DayOfWeek);
            TimeSpan timeSpan = d.TimeOfDay - registation.TravelingDriver.Time;
            if (d >= registation.TravelingPassenger.FromDate)
                if (d <= registation.TravelingPassenger.ToDate)
                    if (registation.TravelingPassenger.Weekday.Contains(Convert.ToString(p)))
                        if (timeSpan.Minutes <= -30)
                            return true;
            return false;
        }
    }
}
