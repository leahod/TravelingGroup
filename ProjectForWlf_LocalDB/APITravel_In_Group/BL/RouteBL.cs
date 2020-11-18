using DAL;
using DAL.EF;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RouteBL
    {
        public static void SendRouteToDrivers(object state)
        {
            List<RegistrationDateRange> listReg = new List<RegistrationDateRange>();
            List<TravelDriverRange> travels = TravelDriverRangeBL.GetTravelingsNow();
            foreach (var travel in travels)
            {
                listReg = RegistrationDateRangeDal.GetRegisterationNow(travel);
                if (listReg != null)
                    Mail.sendRouteToDriver(listReg, travel);
            }
  
        }


        public static WayPoint GetListWayPointsByTravelD(int id)
        {
            WayPoint wayPoint = new WayPoint();
            
            TravelDriverRange travel = TravelDriverRangeDAL.GetTravelRangeByIdentity(id);
            List<RegistrationDateRange> listReg = RegistrationDateRangeDal.GetRegisterationNow(travel);
            if (listReg == null)
                return null;
            TravelingPassenger traveling;
            List<TravelingPassenger> travelings = new List<TravelingPassenger>();
            Registeration registeration;
            Route route = new Route();
            TravelingDriver travelingDriver = TravelingDriverDal.GetTraveling(travel.Id);
            //   Driver driver = DriverDal.GetDriverById(travelingDriver.DriverId);
            wayPoint.LatSource = travelingDriver.LatS;
            wayPoint.LatDestination = travelingDriver.LatD;
            wayPoint.LngSource = travelingDriver.LngS;
            wayPoint.LngDestination = travelingDriver.LngD;
            wayPoint.ListPoint = new  Point [listReg.Count*2];
            int i = 0;
          
            foreach (var t in listReg)
            {
                registeration = RegisterationDal.GetRegisterationById(t.Id);
                traveling = TravelingPassengerDal.GetTraveling(registeration.TravelingIdPassenger);
                if (traveling != null)
                {
                    wayPoint.ListPoint[i] = new Point() { Lat = traveling.LatS, Lng = traveling.LngS };
                    i++;
                    wayPoint.ListPoint[i] = new Point() { Lat = traveling.LatD, Lng = traveling.LngD };
                    i++;
                }
            }
            return wayPoint;
        }

        
    }
}
