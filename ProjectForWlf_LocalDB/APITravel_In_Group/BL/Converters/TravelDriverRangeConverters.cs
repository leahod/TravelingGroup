using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BL.Converters
{
   public class TravelDriverRangeConverters
    {
        public static TravelDriverRange GetTravelRange (TravelDriverRangeDTO dtoTravelDateRange)
        {
            TravelDriverRange travelDateRange = new TravelDriverRange()
            {
               
                Id = dtoTravelDateRange.Id,
                Date=dtoTravelDateRange.Date,
                NumSeatsAvailable=dtoTravelDateRange.NumSeatsAvailable,
                IsActive =dtoTravelDateRange.IsActive
            };

            return travelDateRange;
        }
        public static TravelDriverRangeDTO GetTravelRangeDTO(TravelDriverRange travelDateRange)
        {
            if (travelDateRange == null)
                return null;
            TravelDriverRangeDTO travelDateRangeDTO = new TravelDriverRangeDTO()
            {
                Identity = travelDateRange.Identity,
                Id =travelDateRange.Id,
                 Date=travelDateRange.Date,
                 NumSeatsAvailable=travelDateRange.NumSeatsAvailable,
                 IsActive = travelDateRange.IsActive

            };

            return travelDateRangeDTO;
        }
        public static List<TravelDriverRange> GetTravelRanges(List<TravelDriverRangeDTO> lTravelDateRangesDTO)
        {
            List<TravelDriverRange> l = new List<TravelDriverRange>();
            lTravelDateRangesDTO.ForEach(u => l.Add(GetTravelRange(u)));
            return l;

        }
        public static List<TravelDriverRangeDTO> GetTravelRangesDTO(List<TravelDriverRange> lTravelDateRanges)
        {
            List<TravelDriverRangeDTO> l = new List<TravelDriverRangeDTO>();
            lTravelDateRanges.ForEach(u => l.Add(GetTravelRangeDTO(u)));
            return l;

        }
    }
}
