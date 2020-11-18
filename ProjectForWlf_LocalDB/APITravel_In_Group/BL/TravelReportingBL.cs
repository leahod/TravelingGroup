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
    public class TravelReportingBL
    {
        /// <summary> add report traveling to the db
        /// </summary>
        public static void AddComplaint(RegistrationDateRangeDTO traveling)
        {
            int idRegDate;
            RegisterationDTO registeration = RegisterationBL.GetRegisterationByPassengerId(traveling.Id);
            if (registeration == null)
                return;
            traveling.Id = registeration.Id;
            idRegDate = IsExistInReg(traveling);
            if (idRegDate == -1)
                return;
            if (isComplain(traveling))
                return;

            RegistrationDateRangeDal.StatusComplain(registeration.Id, traveling.DateInRange);

            if (IsExistInReport(registeration.travelingIdDriver, traveling.DateInRange))
                AddComplaint(registeration, traveling.DateInRange, idRegDate);
            else
                AddReport(registeration.travelingIdDriver, traveling.DateInRange, idRegDate);

        }

        private static bool isComplain(RegistrationDateRangeDTO traveling)
        {
            RegistrationDateRange regDate = RegistrationDateRangeDal.GetDate(traveling.Id, traveling.DateInRange);
            return regDate.IsComplain;

        }

        private static void AddReport(int travelingIdDriver, DateTime dateInRange, int idRegDate)
        {
            TravelReportingDal.AddTravelReport(travelingIdDriver, dateInRange);
        }

        private static void AddComplaint(RegisterationDTO registeration, DateTime dateInRange, int idRegDate)
        {
            TravelReportingDTO travelReporting = TravelReportingConverters.GetTravelReportingDTO(TravelReportingDal.AddComplaint(registeration.travelingIdDriver, dateInRange));

            if (travelReporting.NumComplainants >= travelReporting.NumPassengers / 2)
            {
                List<RegisterationDTO> allReg = GetAllRegOfTravel(registeration.travelingIdDriver, dateInRange);

                foreach (var reg in allReg)
                {
                    PaymentBL.PayToPassengerCancel(reg, dateInRange, dateInRange);

                }
                TravelReportingDal.UpdatePay(travelReporting.IdTravelingDriver, travelReporting.Date);
            }
        }

        private static List<RegisterationDTO> GetAllRegOfTravel(int travelingIdDriver, DateTime dateInRange)
        {
            List<RegisterationDTO> allReg = RegisterationConverters.GetListRegisterationDTO(RegisterationDal.GetRegByIdInDate(travelingIdDriver, dateInRange));
            return allReg;
        }

        private static bool IsExistInReport(int travelingIdDriver, DateTime dateInRange)
        {
            TravelReportingDTO travelReporting = TravelReportingConverters.GetTravelReportingDTO(TravelReportingDal.GetTravelReport(travelingIdDriver, dateInRange));
            if (travelReporting == null)
                return false;
            return true;
        }


        private static int IsExistInReg(RegistrationDateRangeDTO traveling)
        {
            List<RegistrationDateRangeDTO> listRegDates = RegistrationDateRangeConverters.GetListDateRangeDTO(RegistrationDateRangeDal.GetDateByRegistrationId(traveling.Id));
            var dateInRange = listRegDates.Where(r => r.DateInRange == traveling.DateInRange);
            if (dateInRange.Count() == 0)
                return -1;
            return dateInRange.First().Id;
        }




    }
}
