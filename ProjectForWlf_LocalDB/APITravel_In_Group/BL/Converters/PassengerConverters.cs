using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BL.Converters
{
   public class PassengerConverters
    {
        public static Passenger GetPassenger(DTO.PassngerDTO dtoPassenger)
        {
             
            Passenger passenger = new Passenger()
            {
                Identity = dtoPassenger.Identity,
                
            };
            //passenger.User.Name = dtoPassenger.Name;
            //passenger.User.Mail = dtoPassenger.Mail;
            //passenger.User.Gender = dtoPassenger.Gender;

            return passenger;
        }
        public static PassngerDTO GetPassengerDTO(Passenger passenger)
        {
            if (passenger == null)
                return null;
            User user = UserConverters.GetUser(UserBL.GetUser(passenger.Identity));
            passenger.User = user;
            PassngerDTO passengerDTO = new PassngerDTO()
            {
                Id=passenger.Id,
                Identity = passenger.Identity,
                Name = passenger.User.Name,
                Mail = passenger.User.Mail,
                Gender = passenger.User.Gender,
                Cellphone =passenger.User.Cellphone
               
            };
            return passengerDTO;
        }
        public static List<Passenger> GetListPassenger(List<PassngerDTO> lpassenger)
        {
            List<Passenger> l = new List<Passenger>();
            lpassenger.ForEach(u => l.Add(GetPassenger(u)));
            return l;

        }
        public static List<PassngerDTO> GetListPassengerDTO(List<Passenger> lpassenger)
        {
            List<PassngerDTO> l = new List<PassngerDTO>();
            lpassenger.ForEach(u => l.Add(GetPassengerDTO(u)));
            return l;

        }
    }
}
