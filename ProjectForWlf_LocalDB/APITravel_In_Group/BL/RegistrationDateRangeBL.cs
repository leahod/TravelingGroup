using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DAL.EF;

namespace BL
{
    public class RegistrationDateRangeBL
    {
        /// <summary> find registerationDates by identity's registeration 
        /// </summary>
        public static List<RegistrationDateRangeDTO> GetRegistrationDates(int id)
        {
            return Converters.RegistrationDateRangeConverters.GetListDateRangeDTO(DAL.RegistrationDateRangeDal.GetDateByRegistrationId(id));
        }

        /// <summary> delete range of dates by identity's registeration 
        /// </summary>
        public static int DeleteRangeP(int id, DateTime fromDate, DateTime toDate)
        {
            return RegistrationDateRangeDal.DeleteRangeDate(id, fromDate, toDate);
        }

        /// <summary> delete range of dates by identity's registeration 
        /// </summary>
        public static int DeleteRangeD(int id, DateTime fromDate, DateTime toDate)
        {

            return RegistrationDateRangeDal.DeleteRangeDate(id, fromDate, toDate);
        }

        /// <summary> check if this travelig is today
        /// </summary>
        public static bool isTravelToday(int id, DateTime fromDate, DateTime toDate)
        {
            return RegistrationDateRangeDal.isTravelToday(id, fromDate, toDate);
        }

       
    }
}
