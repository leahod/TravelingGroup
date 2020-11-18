using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BL.Converters
{
   public class TravelReportingConverters
    {
        public static TravelReporting GetTravelReporting(TravelReportingDTO dtoTravelReporting)
        {
            TravelReporting travelReporting = new TravelReporting()
            {
                IdTravelingDriver = dtoTravelReporting.IdTravelingDriver,
                Date = dtoTravelReporting.Date,
                NumPassengers = dtoTravelReporting.NumPassengers,
                NumComplainants = dtoTravelReporting.NumComplainants,
                IsPay =dtoTravelReporting.IsPay
            };

            return travelReporting;
        }
        public static TravelReportingDTO GetTravelReportingDTO(TravelReporting travelReporting)
        {
            if (travelReporting == null)
                return null;
            TravelReportingDTO dtoTravelReporting = new TravelReportingDTO()
            {
                IdTravelingDriver = travelReporting.IdTravelingDriver,
                Date = travelReporting.Date,
                NumPassengers = travelReporting.NumPassengers,
                NumComplainants= travelReporting.NumComplainants,
                IsPay = travelReporting.IsPay

            };

            return dtoTravelReporting;
        }
        public static List<TravelReporting> GetTravelReportings(List<TravelReportingDTO>  lTravelReportingDTO )
        {
            List<TravelReporting> l = new List<TravelReporting>();
            lTravelReportingDTO.ForEach(u => l.Add(GetTravelReporting(u)));
            return l;

        }
        public static List<TravelReportingDTO> GetTravelReportingsDTO(List<TravelReporting> lTravelReportings)
        {
            List<TravelReportingDTO> l = new List<TravelReportingDTO>();
            lTravelReportings.ForEach(u => l.Add(GetTravelReportingDTO(u)));
            return l;

        }
    }




}
 