using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BL.Converters
{
  public  class TravelPassengerRangeCoverters
    {
        public static TravelPassengerRange GetTravelRange(TravelPassengerRangeDTO dtoTravelDateRange)
        {
            TravelPassengerRange travelDateRange = new TravelPassengerRange()
            {
                Id = dtoTravelDateRange.Id,
                Date = dtoTravelDateRange.Date,
                IsActive = dtoTravelDateRange.IsActive
            };

            return travelDateRange;
        }
        public static TravelPassengerRangeDTO GetTravelRangeDTO(TravelPassengerRange  travelDateRange)
        {
            if (travelDateRange == null)
                return null;
            TravelPassengerRangeDTO travelDateRangeDTO = new TravelPassengerRangeDTO()
            {
                Id = travelDateRange.Id,
                Date = travelDateRange.Date,
                IsActive = travelDateRange.IsActive

            };

            return travelDateRangeDTO;
        }
        public static List<TravelPassengerRange> GetTravelRanges(List<TravelPassengerRangeDTO> lTravelDateRangesDTO)
        {
            List<TravelPassengerRange> l = new List<TravelPassengerRange>();
            lTravelDateRangesDTO.ForEach(u => l.Add(GetTravelRange(u)));
            return l;

        }
        public static List<TravelPassengerRangeDTO> GetTravelRangesDTO(List<TravelPassengerRange> lTravelDateRanges)
        {
            List<TravelPassengerRangeDTO> l = new List<TravelPassengerRangeDTO>();
            lTravelDateRanges.ForEach(u => l.Add(GetTravelRangeDTO(u)));
            return l;

        }
    }
}
 
