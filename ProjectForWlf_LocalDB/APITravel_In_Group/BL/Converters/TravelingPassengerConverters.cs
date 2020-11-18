using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using DAL.EF;


namespace BL.Converters
{
    public class TravelingPassengerConverters
    {
        public static TravelingPassenger GetTraveling(TravelingPassengerDTO dtoTraveling)
        {
            TravelingPassenger traveling = new TravelingPassenger()
            {
                PassengerId = dtoTraveling.PassengerId,
                Weekday = dtoTraveling.Weekday,
                Places = dtoTraveling.Places,
                FromTime = dtoTraveling.FromTime,
                ToTime = dtoTraveling.ToTime,
                FromDate = dtoTraveling.FromDate,
                ToDate = dtoTraveling.ToDate,
                Price = dtoTraveling.Price,
                Source = dtoTraveling.Source,
                Destination = dtoTraveling.Destination,
                LatS = dtoTraveling.LatS,
                LngS = dtoTraveling.LngS,
                LatD = dtoTraveling.LatD,
                LngD = dtoTraveling.LngD,
                IsEmbedded = dtoTraveling.IsEmbedded,
                TravelingIdPassenger = dtoTraveling.TravelingIdPassenger,
                IsActive =dtoTraveling.IsActive
            };
            return traveling;
        }
        public static TravelingPassengerDTO GetTravelingDTO(TravelingPassenger traveling)
        {
            if (traveling == null)
                return null;
            TravelingPassengerDTO travelingsDTO = new TravelingPassengerDTO()
            {
                TravelingIdPassenger = traveling.TravelingIdPassenger,
                PassengerId = traveling.PassengerId,
                Weekday = traveling.Weekday,
                Places = traveling.Places,
                FromTime = traveling.FromTime,
                ToTime = traveling.ToTime,
                FromDate = traveling.FromDate,
                ToDate = traveling.ToDate,
                Price = traveling.Price,
                Source = traveling.Source,
                Destination = traveling.Destination,
                LatS = traveling.LatS,
                LngS = traveling.LngS,
                LatD = traveling.LatD,
                LngD = traveling.LngD,
                IsEmbedded = traveling.IsEmbedded,
                IsActive = traveling.IsActive
            };


            return travelingsDTO;
        }
        public static List<TravelingPassenger> GetListTravelings(List<TravelingPassengerDTO> lTravelings)
        {
            List<TravelingPassenger> l = new List<TravelingPassenger>();
            lTravelings.ForEach(u => l.Add(GetTraveling(u)));
            return l;

        }
        public static List<TravelingPassengerDTO> GetListTravelingsDTO(List<TravelingPassenger> lTravelings)
        {
            List<TravelingPassengerDTO> l = new List<TravelingPassengerDTO>();
            lTravelings.ForEach(u => l.Add(GetTravelingDTO(u)));
            return l;

        }
    }
}

