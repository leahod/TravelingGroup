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
    public class TravelingDriverConverters
    {
        public static TravelingDriver GetTraveling(TravelingDriverDTO dtoTraveling)
        {
            TravelingDriver traveling = new TravelingDriver()
            {
                DriverId = dtoTraveling.DriverId,
                Weekday = dtoTraveling.Weekday,
                Places = dtoTraveling.Places,
                Time = dtoTraveling.Time,
                FromDate = dtoTraveling.FromDate,
                ToDate = dtoTraveling.ToDate,
                Price = dtoTraveling.Price,
                Source = dtoTraveling.Source,
                Destination = dtoTraveling.Destination,
                LatS = dtoTraveling.LatS,
                LngS = dtoTraveling.LngS,
                LatD = dtoTraveling.LatD,
                LngD = dtoTraveling.LngD,
                NumSeats = dtoTraveling.NumSeats,
                IsActive = dtoTraveling.IsActive
                
               
            };

            return traveling;
        }
        public static TravelingDriverDTO GetTravelingDTO(TravelingDriver traveling)
        {
            if (traveling == null)
                return null;
            TravelingDriverDTO travelingsDTO = new TravelingDriverDTO()
            {
                TravelingIdDriver=traveling.TravelingIdDriver,
                DriverId = traveling.DriverId,
                Weekday = traveling.Weekday,
                Places = traveling.Places,
                Time = traveling.Time,
                FromDate = traveling.FromDate,
                ToDate = traveling.ToDate,
                Price = traveling.Price,
                Source=traveling.Source,
                Destination=traveling.Destination,
                LatS = traveling.LatS,
                LngS = traveling.LngS,
                LatD = traveling.LatD,
                LngD = traveling.LngD,
                NumSeats =traveling.NumSeats,
                IsActive = traveling.IsActive
                
            };
           
            //travelingsDTO.Source= AddressBL.GetAddress(traveling.Source);
            //travelingsDTO.Destination = AddressBL.GetAddress(traveling.Destination);
            return travelingsDTO;
        }
        public static List<TravelingDriver> GetListTravelings(List<TravelingDriverDTO> lTravelings)
        {
            List<TravelingDriver> l = new List<TravelingDriver>();
            lTravelings.ForEach(u => l.Add(GetTraveling(u)));
            return l;

        }
        public static List<TravelingDriverDTO> GetListTravelingsDTO(List<TravelingDriver> lTravelings)
        {
            List<TravelingDriverDTO> l = new List<TravelingDriverDTO>();
            lTravelings.ForEach(u => l.Add(GetTravelingDTO(u)));
            return l;

        }
    }
}
 