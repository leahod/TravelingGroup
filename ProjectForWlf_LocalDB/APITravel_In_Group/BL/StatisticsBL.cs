using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class StatisticsBL
    {
        /// <summary> return statistics between male and female
        /// </summary>
        public static List<int> GetGender()
        {
            return DAL.StatisticsDal.GetGender();
        }

        /// <summary> find statistics travelings of days
        /// </summary>
        public static List<int> GetDays()
        {
            return DAL.StatisticsDal.GetDays();
        }

        /// <summary> find avg's price for traveling  
        /// </summary>
        public static int GetAvgPassengers()
        {
            return DAL.StatisticsDal.GetAvgPassengers();
        }
        /// <summary> find sum of price for traveling  
        /// </summary>
        public static object GetTravelCost()
        {
            return DAL.StatisticsDal.GetTravelCost();
        }
    }
}