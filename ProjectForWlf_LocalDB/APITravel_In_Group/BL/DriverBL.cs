using BL.Converters;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DriverBL
    {
        /// <summary> return all the drivers
        /// </summary>
        public static List<DriverDTO> GetDrivers()
        {
            List<DAL.EF.Driver> d = DAL.DriverDal.GetDrivers();
            return DriverConverters.GetListDriverDTO(d);
        }

        /// <summary> find driver by identity
        /// </summary>
        public static UserDTO GetDriver(string id)
        {
            return Converters.DriverConverters.GetDriverDTO(DAL.DriverDal.GetDriver(id));
        }

        /// <summary> add a new driver in the db
        /// </summary>
        public static void Add(DriverDTO driver)
        {
            UserDTO u = UserBL.Add(driver);
            driver.Identity = u.Identity;
            DriverDal.AddDriver(Converters.DriverConverters.GetDriver(driver));
        }

        /// <summary> update details' driver in the db
        /// </summary>
        public static void UpdateDriver(string id, DriverDTO driver)
        {
            DriverDal.UpdateDriver(Converters.DriverConverters.GetDriver(driver), id);
        }
    }
}
