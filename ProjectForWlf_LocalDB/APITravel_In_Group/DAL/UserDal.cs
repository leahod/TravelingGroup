using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDal
    {
        public static List<User> GetUsers()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    return db.Users.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static User GetUser(string id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Users.FirstOrDefault(w => w.Identity == id);
                    if (q == null)
                    {
                        User user = new User() { Identity = id };
                        return user;
                    }
                    return q;
                }
            }
            catch { throw; }
        }

        public static User AddUser(User user)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    User isUserExist = ctx.Users.Find(user.Identity);
                    if (isUserExist == null)
                    {
                        ctx.Users.Add(user);
                        ctx.SaveChanges();
                    }
                    else user = isUserExist;
                }
                return user;
            }
            catch (Exception e)
            {
                return new User();
            }
        }

        public static bool UpdateUser(User user, string id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Users.FirstOrDefault(w => w.Identity.CompareTo(id) == 0);
                    if (q == null)
                        return false;
                    q.Name = user.Name;
                    q.Mail = user.Mail;
                    q.Gender = user.Gender;
                    q.Cellphone = user.Cellphone;
                    q.CreditCardNumber = user.CreditCardNumber;
                    q.Validity = user.Validity;
                    q.Cvv = user.Cvv;
                    q.IdCardOwner = user.IdCardOwner;

                    ctx.SaveChanges();
                    return true;
                }
            }
            catch { throw; }

        }
        public static bool DeleteUser(string id)
        {
            try
            {
                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
                {
                    var q = ctx.Users.FirstOrDefault(w => w.Identity.CompareTo(id) == 0);
                    if (q == null)
                        return false;
                    ctx.Users.Remove(q);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch { throw; }
        }
    }
}
