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
    public class TravelingPassengerBL
    {
        /// <summary>return all the travelings by identity
        /// </summary>
        public static List<TravelingPassengerDTO> GetTravelings(int id)
        {
            return TravelingPassengerConverters.GetListTravelingsDTO(TravelingPassengerDal.GetTravelings(id));
        }

        /// <summary>find traveling by identity
        /// </summary>
        public static TravelingPassengerDTO GetTraveling(int id)
        {
            return TravelingPassengerConverters.GetTravelingDTO(DAL.TravelingPassengerDal.GetTraveling(id));
        }

        /// <summary> add a new traveling in the db
        /// </summary>
        public static int Add(TravelingPassengerDTO traveling)
        {
            TravelingPassenger t = TravelingPassengerConverters.GetTraveling(traveling);
            t.TravelingIdPassenger = TravelingPassengerDal.AddTraveling(t);
            TravelPassengerRangeDal.AddTravelRange(t);
            return t.TravelingIdPassenger;
        }

        /// <summary> find attached travelings by identity
        /// </summary>
        public static object GetTravelAttached(int id)
        {
            return TravelingPassengerConverters.GetListTravelingsDTO(DAL.TravelingPassengerDal.GetTravelAttached(id));
        }

        /// <summary> find unattached travelings by identity
        /// </summary>
        public static object GetTravelNotAttached(int id)
        {
            return TravelingPassengerConverters.GetListTravelingsDTO(DAL.TravelingPassengerDal.GetTravelNotAttached(id));
        }

        ///<summary>update details' traveling in the db
        ///</summary>
        public static void UpdateTraveling(TravelingPassengerDTO travelings)
        {
            TravelingPassengerDal.UpdateTraveling(TravelingPassengerConverters.GetTraveling(travelings));
        }

        /// <summary> delete a traveling from the db
        /// </summary>
        public static void DeleteTraveling(TravelingPassengerDTO traveling)
        {
            try
            {
                TravelingPassenger travelingP = TravelingPassengerDal.GetTraveling(traveling.TravelingIdPassenger);
                if (travelingP.FromDate.Date == traveling.FromDate.Date && travelingP.ToDate.Date == traveling.ToDate.Date)
                    TravelingPassengerDal.DeleteTraveling(travelingP.TravelingIdPassenger);
                else
                    TravelingPassengerDal.DeleteTravelingRange(TravelingPassengerConverters.GetTraveling(traveling));

            }
            catch
            {

            }
         
        }
    }
}
