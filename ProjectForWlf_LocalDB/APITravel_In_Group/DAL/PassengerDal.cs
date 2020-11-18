using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class PassengerDal
    {

        public static List<Passenger> GetPassengers()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    return db.Passengers.Include("Users").ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static Passenger GetPassenger(string id)
        {

            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Passengers.FirstOrDefault(w => w.Identity==id) ;
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }
        public static Passenger GetPassengerById(int id)
        {

            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Passengers.FirstOrDefault(w => w.Id == id);
                    var q2 = ctx.Users.FirstOrDefault(w => w.Identity == q.Identity);
                    q.User = q2;
                    if (q == null)
                        return null;
                    return q;
                }
            }
            catch { throw; }
        }

        public static void AddPassenger(Passenger passenger)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    ctx.Passengers.Add(passenger);
                    ctx.SaveChanges();
                }
            }
            catch { throw; }
        }


    }
}
