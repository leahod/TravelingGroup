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
    public class TravelingDriverBL
    {
        /// <summary> find traveling by identity
        /// </summary>
        public static List<TravelingDriverDTO> GetTravelings()
        {
            return TravelingDriverConverters.GetListTravelingsDTO(DAL.TravelingDriverDal.GetTravelings());
        }

        /// <summary> return all the travelings by identity
        /// </summary>
        public static List<TravelingDriverDTO> GetTravelings(int id)
        {
            return TravelingDriverConverters.GetListTravelingsDTO(TravelingDriverDal.GetTravelings(id));
        }

        /// <summary> find traveling by identity
        /// </summary>
        public static TravelingDriverDTO GetTraveling(int id)
        {
            return TravelingDriverConverters.GetTravelingDTO(DAL.TravelingDriverDal.GetTraveling(id));
        }

        /// <summary> return all the match travelings to travelingPassenger
        /// </summary>
        public static List<TravelingDriverDTO> GetTravelingsToPassenger(int id)
        {
            TravelingPassenger t = TravelingPassengerDal.GetTraveling(id);
            return TravelingDriverConverters.GetListTravelingsDTO(DAL.TravelingDriverDal.GetTravelingsToPassenger(t));
        }

        /// <summary> add a new traveling in the db
        /// </summary>
        public static void Add(TravelingDriverDTO travelingD)
        {
            TravelingDriver t = TravelingDriverConverters.GetTraveling(travelingD);
            t.TravelingIdDriver = TravelingDriverDal.AddTraveling(t);
            travelingD.TravelingIdDriver = t.TravelingIdDriver;
            TravelDriverRangeDAL.AddTravelRange(t);
            List<TravelingPassenger> travelPassengersSuitable = TravelingPassengerDal.GetTravelSuitableP(t);
            foreach (var travelP in travelPassengersSuitable)
            {
                Mail.sendMailSuitableDriver(travelP, travelingD);
            }
        }

        /// <summary> delete traveling from the db
        /// </summary>
        public static void DeleteTraveling(TravelingDriverDTO traveling)
        {
            TravelingDriver travelingD = TravelingDriverDal.GetTraveling(traveling.TravelingIdDriver);
            if (travelingD.FromDate.Date == traveling.FromDate.Date && travelingD.ToDate.Date == traveling.ToDate.Date)
                TravelingDriverDal.DeleteTraveling(travelingD.TravelingIdDriver);
            else TravelingDriverDal.DeleteTravelingRange(TravelingDriverConverters.GetTraveling(traveling));
        }

        /// <summary> find attached travelings by identity
        /// </summary>
        public static object GetTravelAttached(int id)
        {
            return TravelingDriverConverters.GetListTravelingsDTO(DAL.TravelingDriverDal.GetTravelAttached(id));
        }

        /// <summary> find unattached travelings by identity
        /// </summary>
        public static object GetTravelUnAttached(int id)
        {
            return TravelingDriverConverters.GetListTravelingsDTO(DAL.TravelingDriverDal.GetTravelNotAttached(id));
        }
    }
}
