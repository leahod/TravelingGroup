using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BL.Converters;
using DAL;
using DTO;
using System.Net.Mime;

namespace BL
{
    public static class Mail
    {
        ///<summary> send reminder on mail to the passengers
        ///</summary>
        public static void sendMailReminderToP(Object state)
        {
            List<RegistrationDateRangeDTO> registrationNow = RegistrationDateRangeConverters.GetListDateRangeDTO(RegistrationDateRangeDal.GetTravelingsNow());
            foreach (var r in registrationNow)
            {
                sendMailReminder(RegisterationConverters.GetRegisterationDTO(RegisterationDal.GetRegisterationById(r.Id)));
            }
        }

        ///<summary> send reminder on mail
        ///</summary>
        public static void sendMailReminder(RegisterationDTO registeration)
        {
            TravelingDriver travelingDriver = TravelingDriverDal.GetTraveling(registeration.travelingIdDriver);
            TravelingPassenger travelingPassenger = TravelingPassengerDal.GetTraveling(registeration.travelingIdPassenger);
            Driver driver = DriverDal.GetDriverById(travelingDriver.DriverId);
            Passenger passenger = PassengerDal.GetPassengerById(travelingPassenger.PassengerId);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("traveligroup11@gmail.com");
                mail.To.Add(passenger.User.Mail);
                mail.Subject = "תזכורת נסיעה";
                string urlDetails = "http://localhost:4200/details-traveling-p/" + Uri.EscapeDataString(travelingPassenger.TravelingIdPassenger.ToString());
               
                mail.Body = "" +
                "<div style='margin-bottom: 1%; padding-top: 2px'>" +
                   "<h1 style='margin-bottom: 0%;font-size:19px; color: #bb3209; text-align: center;'>תזכורת אודות נסיעתך היום</h1>" +
                   "<h2 style='text-align: center; font-size:14px; color: rgb(0,39,58);'>בשעה : " + travelingDriver.Time.ToString() + "</h2>" +
                   "<h2 style='text-align: center;font-size:15px; color: rgb(0,39,58);'> נסיעה טובה !</h2>" +
                   "<a href='"+ urlDetails+"'>" +
                      "<h2 style='text-align: center; color: #bb3209; text-decoration: underline;'>לפרטי הנסיעה</h2>" +
                   "</a>" +
                "</div>";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("travelingroup11@gmail.com", "group1111@");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary> send mail to suitable driver
        /// </summary>
        public static void sendMailSuitableDriver(TravelingPassenger travelingPassenger, TravelingDriverDTO travelingDriver)
        {
            string gender = "";
            Driver driver = DriverDal.GetDriverById(travelingDriver.DriverId);
            Passenger passenger = PassengerDal.GetPassengerById(travelingPassenger.PassengerId);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                if (driver.User.Gender == true)
                    gender = "זכר";
                else
                    gender = "נקבה";
                mail.From = new MailAddress("traveligroup11@gmail.com");
                mail.To.Add(driver.User.Mail);
                mail.Subject = "מציאת נסיעת נהג תואמת לנסיעתך ";
                string urlDetails = "http://localhost:4200/details-traveling-p/" + Uri.EscapeDataString(travelingPassenger.TravelingIdPassenger.ToString());
                string sURL = "http://localhost:4200/suitable-drivers/" + Uri.EscapeDataString(travelingPassenger.TravelingIdPassenger.ToString());
                mail.Body = "" +
                "<div style='margin-bottom: 1%; padding-top: 2px'>" +
                   "<h1 style='margin-bottom: 0%; color: #bb3209;font-size:19px; text-align: center;'>נמצא נהג תואם לנסיעתך</h1>" +
                    "<a href='" + urlDetails + "'>" +
                        "<h2 style='text-align: center; font-size:14px; color: rgb(0,39,58); text-decoration: underline;'>לפרטי הנסיעה</h2>" +
                    "</a>" +
                   " <a href='" + sURL + "'>" +
                       " <h2 style='text-align: center; font-size:15px;color: #bb3209; text-decoration: underline;'> אשר כאן !?</h2>" +
                    "</a>" +
                "</div>";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("travelingroup11@gmail.com", "group1111@");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary> send mail to the driver to confirm the joining
        /// </summary>
        public static bool MailDriverToConfirm(int idTravelingDriver, int idTravelingPassenger, string body, string subject)
        {
            string gender;
            TravelingDriver travelingDriver = TravelingDriverDal.GetTraveling(idTravelingDriver);
            TravelingPassenger travelingPassenger = TravelingPassengerDal.GetTraveling(idTravelingPassenger);
            Driver driver = DriverDal.GetDriverById(travelingDriver.DriverId);
            Passenger passenger = PassengerDal.GetPassengerById(travelingPassenger.PassengerId);
          
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                if (passenger.User.Gender == true)
                    gender = "זכר";
                else
                    gender = "נקבה";
                mail.From = new MailAddress("traveligroup11@gmail.com");
                mail.To.Add(driver.User.Mail);
                string path = "C:/Users/user1/Desktop/project/src/assets/images/car.png";
                LinkedResource Img = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
                Img.ContentId = "MyImage";
                string str = @" <img src=cid:MyImage  id='img' alt='' width='180px' height='140px'/> ";
                mail.Subject = "אישור הצטרפות נוסע";
                string urlDetails = "http://localhost:4200/details-traveling-p/" + Uri.EscapeDataString(travelingPassenger.TravelingIdPassenger.ToString());
                string urlConfirm = "http://localhost:4200/confirm-driver?idTravelingD=" + Uri.EscapeDataString(travelingDriver.TravelingIdDriver.ToString()) + "&idTravelingP=" + Uri.EscapeDataString(travelingPassenger.TravelingIdPassenger.ToString());
                mail.Body = "" +
                "<div style='margin-bottom: 1%; padding-top: 4px'>" +
                    "<h1 style='margin-bottom: 0%; color: #bb3209;font-size:19px; text-align: center;'>אישור הצטרפות נוסע לנסיעתך</h1>" +
                    "<div style='border-color: rgb(0,39,58) ;border: double 3px;border-radius: 3px; width: 40%; color: rgb(0,39,58); margin-bottom: 2%; margin-right: 280px; margin-top: 4%; direction: rtl;'>" +
                        "<div style='text-align: right; margin-right: 20px; float:right;'>" +
                            "<h3 style='width: 95%; color: #bb3209; margin-bottom: 2%; margin-left: 2%; margin-top: 4%; direction: rtl;'>פרטי הנוסע</h3>" +
                            "<p style='width: 95%; font-size:14px; color: rgb(0,39,58); margin-bottom: 2%; margin-left: 2%; margin-top: 4%; direction: rtl; text-align: right;'>" +
                                "<span style='font-weight: 600;'>שם : </span>" + passenger.User.Name+
                            "</p>" +
                            "<p style='width: 95%; font-size:14px; color: rgb(0,39,58); margin-bottom: 2%; margin-left: 2%; margin-top: 4%; direction: rtl; text-align: right;'>" +
                                "<span style='font-weight: 600;font-size:14px;'>מין : </span>" + gender+
                            "</p>" +
                            "<p style='width: 125%; font-size:14px; color: rgb(0,39,58); margin-bottom: 2%; margin-left: 2%; margin-top: 4%; direction: rtl;text-align: right;'>" +
                                "<span style='font-weight: 600;font-size:14px;'>טל/פלאפון : </span>" + passenger.User.Cellphone +
                            "</p>" +
                       " </div>" +
                        "<div style='z-index: 1;'>" +
                            "<div style='text-align: center;'>" + str+
                            "</div>" +
                        "</div>" +
                    "</div>" +
                    "<a href='"+urlDetails+"'>" +
                        "<h2 style='text-align: center; color: rgb(0,39,58);font-size:15px; text-decoration: underline;'>לפרטי הנסיעה</h2>" +
                    "</a>" +
                   " <a href='"+urlConfirm+"'>" +
                       " <h2 style='text-align: center; color: #bb3209; font-size:15px;text-decoration: underline;'>אשר כאן!?</h2>" +
                    "</a>" +
                "</div>";
                AlternateView AV = AlternateView.CreateAlternateViewFromString(mail.Body, null, MediaTypeNames.Text.Html);
                AV.LinkedResources.Add(Img);
                mail.AlternateViews.Add(AV);
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("travelingroup11@gmail.com", "group1111@");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary> send mail to the passenger to confirm the joining
        /// </summary>
        public static bool MailPassengerToConfirm(int idTravelingDriver, int idTravelingPassenger, string body, string subject)
        {
          

            string gender;

            TravelingDriver travelingDriver = TravelingDriverDal.GetTraveling(idTravelingDriver);
            TravelingPassenger travelingPassenger = TravelingPassengerDal.GetTraveling(idTravelingPassenger);
            Driver driver = DriverDal.GetDriverById(travelingDriver.DriverId);
            Passenger passenger = PassengerDal.GetPassengerById(travelingPassenger.PassengerId);
             
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                if (driver.User.Gender == true)
                    gender = "זכר";
                else
                    gender = "נקבה";
                mail.From = new MailAddress("traveligroup11@gmail.com");
                mail.To.Add(driver.User.Mail);
                string path = "C:/Users/user1/Desktop/project/src/assets/images/car.png";
                LinkedResource Img = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
                Img.ContentId = "MyImage";
                string str = @" <img src=cid:MyImage  id='img' alt='' width='180px' height='140px''/> ";
              
                mail.Subject = "אישור הצטרפותך לנסיעה ";
                string urlDetails = "http://localhost:4200/details-traveling-p/" + Uri.EscapeDataString(travelingPassenger.TravelingIdPassenger.ToString());
                string sURL = "http://localhost:4200/confirm-passenger?idTravelingD=" + Uri.EscapeDataString(travelingDriver.TravelingIdDriver.ToString()) + "&idTravelingP=" + Uri.EscapeDataString(travelingPassenger.TravelingIdPassenger.ToString());
                mail.Body = "" +
                "<div style='margin-bottom: 1%; padding-top: 10%;'>" +
                "<h1 style='margin-bottom: 0%; color: #bb3209;font-size:19px; text-align: center;'>אישור הצטרפותך לנסיעה</h1>" +
                "<div style='border-color: rgb(0,39,58) ;border: double 3px ; border-radius: 3px; width: 40%; color: rgb(0,39,58); margin-bottom: 2%; margin-left: 20%; margin-right: 280px; margin-top: 4%; direction: rtl;'>" +
                "<div style='text-align: right;  margin-right: 20px; float:right;'>" +
                    "<h2 style='width: 95%; color: #bb3209;font-size:16px; margin-bottom: 2%; margin-left: 2%; margin-top: 4%; direction: rtl;'>פרטי הנהג</h2>" +
                    "<p style='width: 95%;font-size:14px; color: rgb(0,39,58); margin-bottom: 2%; margin-left: 2%; margin-top: 4%; direction: rtl; text-align: right;'>" +
                        "<span style='font-weight: 600;'>שם : </span>" + driver.User.Name+
                    "</p>" +
                    "<p style='width: 95%;font-size:14px; color: rgb(0,39,58); margin-bottom: 2%; margin-left: 2%; margin-top: 4%; direction: rtl; text-align: right;'>" +
                        "<span style='font-weight: 600;font-size:14px;'>מין : </span>" + gender+
                    "</p>" +
                    "<p style='width: 120%; font-size:14px;color: rgb(0,39,58); margin-bottom: 2%; margin-left: 2%; margin-top: 4%; direction: rtl;text-align: right;'>" +
                        "<span style='font-weight: 600;font-size:14px;'>טל/פלאפון : </span>" + driver.User.Cellphone +
                    "</p>" +
                " </div>" +
                "<div style='z-index: 1;'>" +
                    "<div style='text-align: center;'>" + str+
                    "</div>" +
                "</div>" +
                "</div>" +
                "<a href='"+urlDetails+"'>" +
                   "<h2 style='text-align: center; color: rgb(0,39,58);font-size:15px; text-decoration: underline;'>לפרטי הנסיעה</h2>" +
                "</a>" +
                " <a href='"+sURL+"'>" +
                   "<h2 style='text-align: center; color: #bb3209;font-size:15px; text-decoration: underline;'>אשר כאן !?</h2>" +
                "</a>" +
                "</div>";
                AlternateView AV = AlternateView.CreateAlternateViewFromString(mail.Body, null, MediaTypeNames.Text.Html);
                AV.LinkedResources.Add(Img);
                mail.AlternateViews.Add(AV);
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("travelingroup11@gmail.com", "group1111@");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static AlternateView MailLogo()
        {
            string path = "C:/Users/user1/Desktop/project/src/assets/images/car.jpg";
            LinkedResource Img = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            Img.ContentId = "MyImage";
            string str = @"  
          
                      <img src=cid:MyImage  id='img' alt='' width='100px' height='140px'/>   
               
            ";
            AlternateView AV =
            AlternateView.CreateAlternateViewFromString(str, null, MediaTypeNames.Text.Html);
            AV.LinkedResources.Add(Img);
            return AV;
        }

        
        /// <summary> send mail to the passenger about the cancle
        /// </summary>
        public static void sendMailCancelToP(RegisterationDTO reg, DateTime fromDate, DateTime toDate)
        {
            TravelingDriver travelingDriver = TravelingDriverDal.GetTraveling(reg.travelingIdDriver);
            TravelingPassenger travelingPassenger = TravelingPassengerDal.GetTraveling(reg.travelingIdPassenger);
            Driver driver = DriverDal.GetDriverById(travelingDriver.DriverId);
            Passenger passenger = PassengerDal.GetPassengerById(travelingPassenger.PassengerId);
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("traveligroup11@gmail.com");
                mail.To.Add(passenger.User.Mail);
                mail.Subject = "הודעה על ביטול נסיעה";
                string urlDetails = "http://localhost:4200/details-traveling-p/" + Uri.EscapeDataString(travelingPassenger.TravelingIdPassenger.ToString());
                mail.Body = "" +
                "<div style='height: 90vh; margin-bottom: 1%; padding-top: 2px'>"+
                    "<h2 style='margin-bottom: 0%;font-size:19px; color: #bb3209; text-align: center;'>ביטול נסיעה מנהג</h2>" +
                    "<h3 style='text-align: center;font-size:14px; color: rgb(0,39,58);'>מתאריך : " + fromDate.ToShortDateString()+"</h3>"+
                    "<h3 style='text-align: center;font-size:14px; color: rgb(0,39,58);'>עד תאריך : " + toDate.ToShortDateString()+"</h3>"+
                    "<h1 style='text-align: center;font-size:12px;color:rgb(0,39,58);'>במידה ונגבה תשלום עבור נסיעות אלו , ישולם החזר כספי .</h1>" +
                    "<a href='"+urlDetails+"'>"+
                        "<h3 style='text-align: center;font-size:14px; color: #bb3209; text-decoration: underline;'>לפרטי הנסיעה</h3>" +
                    "</a>"+
                "</div>";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("travelingroup11@gmail.com", "group1111@");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary> send the rout to the driver on mail
        /// </summary>
        public static void sendRouteToDriver(List<RegistrationDateRange> listReg, TravelDriverRange travel)
        {
            TravelingPassenger traveling;
            List<TravelingPassenger> travelings = new List<TravelingPassenger>();
            Registeration registeration;
            Route route = new Route();
            TravelingDriver travelingDriver = TravelingDriverDal.GetTraveling(travel.Id);
            Driver driver = DriverDal.GetDriverById(travelingDriver.DriverId);
            string source, destination, routeDetails;


            source = travelingDriver.Source;
            destination = travelingDriver.Destination;

            foreach (var t in listReg)
            {
                registeration = RegisterationDal.GetRegisterationById(t.Id);
                traveling = TravelingPassengerDal.GetTraveling(registeration.TravelingIdPassenger);
                if (traveling != null)
                {
                    travelings.Add(traveling);

                }
            }
            route = GetRoute(travelings, source, destination);
            routeDetails = GetRouteDetails(route);

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("traveligroup11@gmail.com");
                mail.To.Add(driver.User.Mail);
                mail.Subject = "מסלול נסיעתך ופרטי הנוסעים";
                string urlDetails = "http://localhost:4200/route/" + Uri.EscapeDataString(travel.Identity.ToString());
                mail.Body = "" +
                "<div style='margin-bottom: 1%; padding-top: 2px'>" +
                "<h2 style='margin-bottom: 0%;font-size:19px; color: #bb3209; text-align: center;'>   מסלול לנסיעה היום בשעה  "+ travelingDriver.Time.ToString()+" </h2>" +
                "<h3 style='text-align: center;font-size:17px;color:rgb(0,39,58);'>תחנות האיסוף והפיזור בנסיעתך</h3>" +
                 routeDetails +
                "<a href='"+urlDetails+"'>" +
                "<h3 style='text-align: center;font-size:17px; color: #bb3209; text-decoration: underline;'>לצפיה במסלול</h3>" +
                "</a>" +
                "</div>";
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("travelingroup11@gmail.com", "group1111@");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary> return the rout to the driver
        /// </summary>
        public static Route GetRoute(List<TravelingPassenger> travelingsP, string source, string destination)
        {
            Passenger passenger;
            Route route = new Route();
            route.listStation = new List<Station>();
            Station station = new Station();

            foreach (var travel1 in travelingsP)
            {
                station = new Station();
                station.Distance = GoogelMaps.GetDistanceSource(travel1, source);
                passenger = PassengerDal.GetPassengerById(travel1.PassengerId);
                station.Cellphone = passenger.User.Cellphone;
                station.Adderss = travel1.Source;
                station.IsCollectionStation = true;
                route.listStation.Add(station);
            }
            foreach (var travel2 in travelingsP)
            {
                station = new Station();
                station.Distance = GoogelMaps.GetDistanceDestination(travel2, source);
                passenger = PassengerDal.GetPassengerById(travel2.PassengerId);
                station.Cellphone = passenger.User.Cellphone;
                station.Adderss = travel2.Destination;
                station.IsCollectionStation = false;
                route.listStation.Add(station);
            }
            route.Source = source;
            route.Destination = destination;
            route.listStation = route.listStation.OrderBy(t => t.Distance).ToList();

            return route;
        }

        /// <summary> return the rout to the driver in string
        /// </summary>
        public static string GetRouteDetails(Route route)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("<TABLE style='border: 1px solid black; font-size:17px;  margin-right: 300px;'>\n");
            sb.Append("<TR style='border: 1px solid black'>\n");
            sb.Append("<TH style='border: 1px solid black;color: #bb3209'>" + "כתובת" + "</TH>");
            sb.Append("<TH style='border: 1px solid black ;color: #bb3209'>" + "סוג תחנה" + "</TH>");
            sb.Append("<TH style='border: 1px solid black;  color: #bb3209'>" + "פלאפון" + "</TH>");
            sb.Append("</TR>\n");

            sb.Append("<TR style='border: 1px solid black'>\n");
            sb.Append("<TD style='border: 1px solid black; color:rgb(0,39,58);'>" + route.Source + "</TD>");
            sb.Append("<TD style='border: 1px solid black ; color:rgb(0,39,58);'>" + "מוצא" + "</TD>");
            sb.Append("</TR>\n");

            foreach (var station in route.listStation)
            {
                sb.Append("<TR style='border: 1px solid black'>\n");

                sb.Append("<TD style='border: 1px solid black; color:rgb(0,39,58);'>");
                sb.Append(station.Adderss);
                sb.Append("</TD>");

                if (station.IsCollectionStation)
                {
                    sb.Append("<TD style='border: 1px solid black; color:rgb(0,39,58);'>");
                    sb.Append("איסוף");
                    sb.Append("</TD>");

                    sb.Append("<TD style='border: 1px solid black ; color:rgb(0,39,58);'>");
                    sb.Append(station.Cellphone);
                    sb.Append("</TD>");
                }
                else
                {
                    sb.Append("<TD style='border: 1px solid black ; color:rgb(0,39,58);'>");
                    sb.Append("פיזור");
                    sb.Append("</TD>");
                }


                sb.Append("</TR>\n");
            }
            sb.Append("<TR style='border: 1px solid black'>\n");
            sb.Append("<TD style='border: 1px solid black ; color:rgb(0,39,58);'>" + route.Destination + "</TD>");
            sb.Append("<TD style='border: 1px solid black ; color:rgb(0,39,58);'>" + "יעד" + "</TD>");
            sb.Append("</TR>\n");

            sb.Append("</TABLE>");

            return sb.ToString();
        }
    }
 
}
