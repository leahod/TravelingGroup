using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BL.Converters;
using DAL;

namespace BL
{
    public class RegisterationBL
    {
        /// <summary> find registeration by identity's passenger
        /// </summary>
        public static RegisterationDTO GetRegisterationByPassengerId(int id)
        {
            return RegisterationConverters.GetRegisterationDTO(DAL.RegisterationDal.GetRegisterationByPassengerId(id));
        }

        /// <summary> find registeration by identity's driver
        /// </summary>
        public static List<RegisterationDTO> GetRegisterationByDriverId(int id)
        {
            return RegisterationConverters.GetListRegisterationDTO(DAL.RegisterationDal.GetRegisterationByDriverId(id));
        }

        /// <summary> add a new registeration in the db
        /// </summary>
        public static void Add(RegisterationDTO registeration)
        {
            RegisterationDal.AddRegisteration(RegisterationConverters.GetRegisteration(registeration));
        }

        /// <summary> delete range registeration of passenger from the db
        /// </summary>
        public static int DeleteRangeRegPassenger(int id, DateTime fromDate, DateTime toDate)
        {
            ///delete from TravelingPassenger
            RegisterationDTO registeration = RegisterationConverters.GetRegisterationDTO(RegisterationDal.GetRegisterationById(id));
            TravelingPassengerDTO travelingPassenger = TravelingPassengerConverters.GetTravelingDTO(TravelingPassengerDal.GetTraveling(registeration.travelingIdPassenger));
            travelingPassenger.FromDate = fromDate;
            travelingPassenger.ToDate = toDate;
            TravelingPassengerBL.DeleteTraveling(travelingPassenger);

            bool isPay = BL.RegistrationDateRangeBL.isTravelToday(id, fromDate, toDate);
            ///delete from Registeration
            int datesDelete = BL.RegistrationDateRangeBL.DeleteRangeP(id, fromDate, toDate);
            if (datesDelete > 0 && isPay)
                PaymentBL.PayToDriverCancel(id, fromDate, toDate);
            return datesDelete;
        }

        /// <summary> delete range registeration of driver from the db
        /// </summary>
        public static int DeleteRangeRegDriver(List<RegisterationDTO> registerations, DateTime fromDate, DateTime toDate)
        {
            foreach (var r in registerations)
            {
                RegistrationDateRangeBL.DeleteRangeD(r.Id, fromDate, toDate);
            }
            return 0;

        }

        /// <summary> delete registeration of driver from the db
        /// </summary>
        public static void DeleteRegisterationDriver(TravelingDriverDTO traveling)
        {
            ///delete from TravelingDriver
            TravelingDriverDTO travelingDriver = TravelingDriverConverters.GetTravelingDTO(TravelingDriverDal.GetTraveling(traveling.TravelingIdDriver));
            travelingDriver.FromDate = traveling.FromDate;
            travelingDriver.ToDate = traveling.FromDate;
            TravelingDriverBL.DeleteTraveling(travelingDriver);
            ///delete from Registeration
            List<RegisterationDTO> registerationInRange = RegisterationConverters.GetListRegisterationDTO(RegisterationDal.GetRegByIdDInRange(traveling.TravelingIdDriver, traveling.FromDate, traveling.ToDate));
            foreach (var reg in registerationInRange)
            {
                try
                {
                    Mail. sendMailCancelToP(reg, traveling.FromDate, traveling.ToDate);
                }
                catch
                {
                    throw;
                }
                try
                {
                    PaymentBL.PayToPassengerCancel(reg, traveling.FromDate, traveling.ToDate);
                }
                catch
                {
                    throw;
                }
            }

            List<RegisterationDTO> registerations = GetRegisterationByDriverId(traveling.TravelingIdDriver);
            DeleteRangeRegDriver(registerations, traveling.FromDate.Date, traveling.ToDate);
        }
    }
}

