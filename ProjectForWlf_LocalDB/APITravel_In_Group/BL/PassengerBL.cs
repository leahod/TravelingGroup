using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BL.Converters;
using DAL;
namespace BL
{
    public class PassengerBL
    {
        /// <summary>  return all the passengers
        /// </summary>
        public static List<PassngerDTO> GetPassengers()
        {
            return PassengerConverters.GetListPassengerDTO(DAL.PassengerDal.GetPassengers());
        }

        /// <summary> find passenger by identity
        /// </summary>
        public static PassngerDTO GetPassenger(string id)
        {
            return Converters.PassengerConverters.GetPassengerDTO(DAL.PassengerDal.GetPassenger(id));
        }

        /// <summary> add a new passenger in the db
        /// </summary>
        public static void Add(PassngerDTO passenger)
        {
            UserDTO user = UserBL.Add(passenger);
            passenger.Identity = user.Identity;
            PassengerDal.AddPassenger(PassengerConverters.GetPassenger(passenger));
        }
    }
}
