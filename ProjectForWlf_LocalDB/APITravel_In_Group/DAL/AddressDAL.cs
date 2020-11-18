using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
namespace DAL
{
    public class AddressDAL
    {
        //public static int AddAddress(Address address)
        //{
        //    try
        //    {
        //        using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
        //        {
        //            ctx.Addresses.Add(address);
        //            ctx.SaveChanges();
        //        }
        //        return address.Id;
        //    }
        //    catch (Exception e)
        //    {
        //        return 0;
        //    }

    }



    //public static List<Address> GetAddresses()
    //{
    //    try
    //    {
    //        using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
    //        {
    //            return db.Addresses.ToList();
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        throw new Exception("error");
    //    }
    //}

    //        public static Address GetAddress(int id)
    //        {

    //            try
    //            {
    //                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
    //                {
    //                    var q = ctx.Addresses.FirstOrDefault(w => w.Id == id);
    //                    if (q == null)
    //                        return null;
    //                    return q;
    //                }
    //            }
    //            catch { throw; }
    //        }

    //        public static bool UpdateAddress(Address address, int id)
    //        {
    //            try
    //            {
    //                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
    //                {
    //                    var q = ctx.Addresses.FirstOrDefault(w => w.Id == id);
    //                    if (q == null)
    //                        return false;

    //                    ctx.SaveChanges();
    //                    return true;
    //                }
    //            }
    //            catch { throw; }

    //        }
    //        public static bool DeleteAddress(int id)
    //        {
    //            try
    //            {
    //                using (Travel_In_GroupDBEntities ctx = new Travel_In_GroupDBEntities())
    //                {
    //                    var q = ctx.Addresses.FirstOrDefault(w => w.Id == id);
    //                    if (q == null)
    //                        return false;

    //                    ctx.SaveChanges();
    //                    return true;
    //                }
    //            }
    //            catch { throw; }
    //        }


    //    }
    //}
}