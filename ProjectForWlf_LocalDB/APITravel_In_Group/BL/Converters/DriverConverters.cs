using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DTO;


namespace BL.Converters
{
    public class DriverConverters
    {
        public static Driver GetDriver(DTO.DriverDTO dtoDriver)
        {
            Driver driver = new Driver()
            {
                Identity = dtoDriver.Identity,
                NumberOfSeats = dtoDriver.NumberOfSeats,
                CarDescription = dtoDriver.CarDescription,
             

    };
            //driver.User.Name = dtoDriver.Name;
            //driver.User.Mail = dtoDriver.Mail;
            //driver.User.Gender = dtoDriver.Gender;

            return driver;
        }
        public static DriverDTO GetDriverDTO(Driver driver)
        {
            if (driver == null)
                return null;
            User user=UserConverters.GetUser(UserBL.GetUser(driver.Identity));
            driver.User = user;
            DriverDTO driverDto = new DriverDTO()
            {
                Id=driver.Id,
                 Identity = driver.Identity,
                Name = driver.User.Name,
                Mail = driver.User.Mail,
                Gender = driver.User.Gender,
                Cellphone=driver.User.Cellphone,
                NumberOfSeats = driver.NumberOfSeats,
                CarDescription = driver.CarDescription 
            };
            
            return driverDto;
        }
        public static List<Driver> GetListDriver(List<DriverDTO> ldriver)
        {
            List<Driver> l = new List<Driver>();
            ldriver.ForEach(u => l.Add(GetDriver(u)));
            return l;

        }
        public static List<DriverDTO> GetListDriverDTO(List<Driver> ldriver)
        {
            List<DriverDTO> l = new List<DriverDTO>();
            ldriver.ForEach(u => l.Add(GetDriverDTO(u)));
            return l;

        }
        

    }
}
