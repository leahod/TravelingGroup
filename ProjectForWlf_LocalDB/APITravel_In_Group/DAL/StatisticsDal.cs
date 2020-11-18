using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class StatisticsDal
    {
        public static List<int> GetGender()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    List<int> genderList = new List<int>();
                    int female = 0, male = 0;
                    foreach (var item in db.Users.ToList())
                    {
                        if (item.Gender == true)
                            male++;
                        else female++;
                    }
                    genderList.Add(female);
                    genderList.Add(male);
                    return genderList;
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static List<int> GetTravelCost()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    List<int> travelCost = new List<int>();
                    int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;
                    foreach (var item in db.TravelingDrivers.ToList())
                    {
                        if (item.Price <= 5)
                            sum1++;
                        else if (item.Price <= 10)
                            sum2++;
                        else
                            if (item.Price > 10 && item.Price <= 20)
                            sum3++;
                        else
                            sum4++;

                    }
                    travelCost.Add(sum1);
                    travelCost.Add(sum2);
                    travelCost.Add(sum3);
                    travelCost.Add(sum4);
                    return travelCost;
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        public static List<int> GetDays()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    List<int> DaysList = new List<int>();
                    for (int i = 0; i < 14; i++)
                        DaysList.Add(0);
                    foreach (var item in db.TravelingPassengers.ToList())
                    {
                        string[] days = item.Weekday.Split(',');
                        for (int i = 0; i < days.Length; i++)
                        {
                            if (days[i] != "" && days[i] != ",")
                            {
                                int day = int.Parse(days[i]);
                                var q = db.Users.FirstOrDefault(
                                    x => x.Identity ==
                                    db.Passengers.FirstOrDefault(p => p.Id == item.PassengerId).Identity);
                                if (q.Gender == true)
                                    DaysList[day - 1 + 7]++;
                                else DaysList[day - 1]++;
                            }

                        }
                    }
                    return DaysList;
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }

        
        public static int GetAvgPassengers()
        {
            try
            {
                using (Travel_In_GroupDBEntities db = new Travel_In_GroupDBEntities())
                {
                    if (db.RegistrationDateRanges.Count() == 0)
                        return 0;
                   int count = db.RegistrationDateRanges.Count(p => p.NumPassengers >= 0);
                    
                    int sum = db.RegistrationDateRanges.Where(x => x.NumPassengers >= 0).Sum(p => (int)p.NumPassengers);
                    return sum / count;
                }
            }
            catch (Exception e)
            {
                throw new Exception("error");
            }
        }
    }
}
