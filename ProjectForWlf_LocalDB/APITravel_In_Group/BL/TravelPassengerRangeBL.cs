using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using DAL.EF;
using BL.Converters;

namespace BL
{
   public class TravelPassengerRangeBL
    {
        public static List<TravelPassengerRangeDTO> GetTravelings()
        {
            return TravelPassengerRangeCoverters.GetTravelRangesDTO(DAL.TravelPassengerRangeDal.GetTravelRanges());

        }

        public static TravelPassengerRangeDTO GetTravelRange(int id)
        {
            return TravelPassengerRangeCoverters.GetTravelRangeDTO(DAL.TravelPassengerRangeDal.GetTravelRange(id));
        }

        public static void DeleteTravelRange(int id)
        {
            TravelPassengerRangeDal.DeleteTravelRange(id);
        }

        public static void UpdateTravelRange(int id, TravelPassengerRangeDTO travelings)
        {
            TravelPassengerRangeDal.UpdateTravelRange(Converters.TravelPassengerRangeCoverters.GetTravelRange(travelings), id);
        }
    
    }
}
 
