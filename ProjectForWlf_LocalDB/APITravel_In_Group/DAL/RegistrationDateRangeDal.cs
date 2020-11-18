using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL
{
    public class RegistrationDateRangeDal
    {
        public static List<RegistrationDateRange> GetRegisterationDates()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    return db.RegistrationDateRanges.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static bool isNow(RegistrationDateRange dateRange)
        {
            DateTime d = new DateTime();
            d = DateTime.Now;
            TimeSpan timeSpan = d.TimeOfDay - dateRange.DateInRange.TimeOfDay;
            if (dateRange.DateInRange.Date == d.Date && timeSpan.Minutes <= -30)
                return true;
            return false;


        }
        public static List<RegistrationDateRange> GetTravelingsNow()
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    List<RegistrationDateRange> registerations = ctx.RegistrationDateRanges.ToList().Where(w => isNow(w) == true).ToList();
                    if (registerations.Count == 0)
                        return null;
                    return registerations;
                }
            }
            catch { throw; }
        }

        public static List<RegistrationDateRange> GetRegisterationNow( TravelDriverRange travelDriver)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.RegistrationDateRanges.ToList().Where(w => w.Registeration.TravelingIdDriver == travelDriver.Id && w.DateInRange.Date == travelDriver.Date.Date).ToList();
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }

        public static List<RegistrationDateRange> GetDateByRegistrationId(int id)
        {

            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.RegistrationDateRanges.Where(w => w.Registeration.Id == id).ToList();
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }

        public static void StatusComplain(int id, DateTime dateInRange)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.RegistrationDateRanges.FirstOrDefault(w => w.Id == id && w.DateInRange == dateInRange);
                    if (q == null)
                        return  ;
                    q.IsComplain = true;
                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }
 

        public static RegistrationDateRange GetDate(int id , DateTime date)
        {

            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.RegistrationDateRanges.FirstOrDefault(w => w.Id == id && w.DateInRange.Date == date.Date);
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }

        public static bool isTravelToday(int id, DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (!(DateTime.Now >= fromDate.Date && DateTime.Now <= toDate.Date))
                    return false;

                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    Registeration registeration = ctx.Registerations.FirstOrDefault(r => r.Id == id);
                    if (registeration == null)
                        return false;
                    TravelingDriver traveling = ctx.TravelingDrivers.FirstOrDefault(d => d.TravelingIdDriver == registeration.TravelingIdDriver);
                    if (traveling == null)
                        return false;

                    var q = ctx.RegistrationDateRanges.ToList()
                     .FirstOrDefault(w => w.Id == id &&
                        w.DateInRange.Date == DateTime.Now.Date);
                    if (q == null)
                        return false;

                    TimeSpan time = traveling.Time - DateTime.Now.TimeOfDay;
                    if (time.TotalHours <= 1)
                        return true;
                    return false;
                }
            }
            catch
            {
                return false;
               
            }

        }

        public static int DeleteRangeDate(int id, DateTime fromDate, DateTime toDate)
        {
            int countDates = 0;
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {

                    var q = ctx.RegistrationDateRanges.Where(w => w.Id == id).ToList();
                    if (q == null)
                        return 0;
                    foreach (var date in q)
                    {
                        try
                        {
                            if (date.DateInRange.Date >= fromDate.Date && date.DateInRange.Date <= toDate)
                            {
                                date.IsActive = false;
                                ctx.SaveChanges();
                                countDates++;
                            }
                        }

                        catch
                        {
                            throw;
                        }
                    }

                    return countDates;
                }
            }
            catch { throw; }

        }

        
        public static bool DeleteRegisterationDate(int id)
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

       

    }

    }
 
