using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BL.Converters
{
    public class RegisterationConverters
    {
        public static Registeration GetRegisteration(DTO.RegisterationDTO dtoRegisteration)
        {
            Registeration registeration = new Registeration()
            {
                Id = dtoRegisteration.Id,
                TravelingIdDriver = dtoRegisteration.travelingIdDriver,
                TravelingIdPassenger = dtoRegisteration.travelingIdPassenger,
                Date=dtoRegisteration.Date
                
            };

            return registeration;
        }
        public static RegisterationDTO GetRegisterationDTO(Registeration registeration)
        {
            if (registeration == null)
                return null;
            RegisterationDTO registerationDTO = new RegisterationDTO()
            {
                Id = registeration.Id,
                travelingIdDriver = registeration.TravelingIdDriver,
                travelingIdPassenger = registeration.TravelingIdPassenger,
                Date = registeration.Date
            };
            return registerationDTO;
        }
        public static List<Registeration> GetListRegisteration(List<RegisterationDTO> lRegisteration)
        {
            List<Registeration> l = new List<Registeration>();
            lRegisteration.ForEach(u => l.Add(GetRegisteration(u)));
            return l;

        }
        public static List<RegisterationDTO> GetListRegisterationDTO(List<Registeration> lRegisteration)
        {
            List<RegisterationDTO> l = new List<RegisterationDTO>();
            lRegisteration.ForEach(u => l.Add(GetRegisterationDTO(u)));
            return l;

        }
    }
}
   