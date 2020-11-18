using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
namespace DAL
{
    public class DriverDal
    {
        public static List<Driver> GetDrivers()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    return db.Drivers.Include("User").ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static Driver GetDriver(string id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Drivers.FirstOrDefault(w => w.Identity==id);
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }

        public static Driver GetDriverById(int id)
        {

            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Drivers.FirstOrDefault(w => w.Id == id);
                    var q1 = ctx.Users.FirstOrDefault(w => w.Identity == q.Identity);
                    q.User = q1;
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }
        public static bool UpdateDriver(Driver driver, string id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Drivers.FirstOrDefault(w => w.Identity.CompareTo(id) == 0);
                    if (q == null)
                        return false;
                    q.CarDescription = driver.CarDescription;
                    q.NumberOfSeats = driver.NumberOfSeats;
                    q.User.Name = driver.User.Name;
                    q.User.Mail = driver.User.Mail;
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch { throw; }

        }

        public static void AddDriver(Driver driver)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    User user = ctx.Users.FirstOrDefault(w => w.Identity.CompareTo(driver.Identity) == 0);
                    driver.User = user;
                    ctx.Drivers.Add(driver);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
 
