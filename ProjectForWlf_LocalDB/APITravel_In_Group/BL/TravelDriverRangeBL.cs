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
  public  class TravelDriverRangeBL
    {
        public static List<TravelDriverRangeDTO> GetTravelings()
        {
            return TravelDriverRangeConverters.GetTravelRangesDTO(DAL.TravelDriverRangeDAL.GetTravelRanges());

        }
       
        
        //public static void Add(TravelDateRangeDTO travelDateRangeDTO)
        //{
        //    TravelDateRange t = TravelDateRangeConverters.GetTravelRange(travelDateRangeDTO);

        //    TravelDateRangeDAL.AddTravelRange(t);
        //}

        public static TravelDriverRangeDTO GetTravelRange(int id)
        {
            return TravelDriverRangeConverters.GetTravelRangeDTO(DAL.TravelDriverRangeDAL.GetTravelRange(id));
        }

        public static void DeleteTravelRange(int id)
        {
            TravelDriverRangeDAL.DeleteTravelRange(id);
        }

        public static void UpdateTravelRange(int id, TravelDriverRangeDTO travelings)
        {
            TravelDriverRangeDAL.UpdateTravelRange(Converters.TravelDriverRangeConverters.GetTravelRange(travelings), id);
        }

        public static List<TravelDriverRange> GetTravelingsNow()
        {
            return TravelDriverRangeDAL.GetTravelNow();
        }
        //public static int GetNumSpace(int travelingIdDriver)
        //{
        //  return  TravelingDriverDal.GetNumSpace(travelingIdDriver);
        //}


    }
}
 
