using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace BL.Converters
{
    public class RegistrationDateRangeConverters
    {
        public static RegistrationDateRange GetDateRange(RegistrationDateRangeDTO dtoRegDateRange)
        {
            RegistrationDateRange registeration = new RegistrationDateRange()
            {
                Id = dtoRegDateRange.Id,
                DateInRange = dtoRegDateRange.DateInRange,
                IsActive = dtoRegDateRange.IsActive,
                IsComplain = dtoRegDateRange.IsComplain,
                NumComplainants=dtoRegDateRange.NumComplainants,
                NumPassengers=dtoRegDateRange.NumPassengers


            };

            return registeration;
        }
        public static RegistrationDateRangeDTO GetDateRangeDTO(RegistrationDateRange registrationDateRange)
        {
            if (registrationDateRange == null)
                return null;
            RegistrationDateRangeDTO registrationDateRangeDTO = new RegistrationDateRangeDTO()
            {
                Id = registrationDateRange.Id,
                DateInRange = registrationDateRange.DateInRange,
                IsActive = registrationDateRange.IsActive,
                IsComplain = registrationDateRange.IsComplain,
                NumComplainants = registrationDateRange.NumComplainants,
                NumPassengers = registrationDateRange.NumPassengers
            };
            return registrationDateRangeDTO;
            ;
        }
        public static List<RegistrationDateRange> GetListDateRange(List<RegistrationDateRangeDTO> lRegistrationDateRangeDTO)
        {
            List<RegistrationDateRange> l = new List<RegistrationDateRange>();
            if (l.Count != 0)
                lRegistrationDateRangeDTO.ForEach(u => l.Add(GetDateRange(u)));
            return l;

        }
        public static List<RegistrationDateRangeDTO> GetListDateRangeDTO(List<RegistrationDateRange> lRegisteration)
        {
            List<RegistrationDateRangeDTO> l = new List<RegistrationDateRangeDTO>();
            if (lRegisteration.Count != 0)
                lRegisteration.ForEach(u => l.Add(GetDateRangeDTO(u)));
            return l;

        }
    }



}
