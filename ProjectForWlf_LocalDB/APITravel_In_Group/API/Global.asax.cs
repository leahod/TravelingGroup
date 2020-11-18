using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Threading;
using BL;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //Timer timer1 = null;
        //TimerCallback callback1 = new System.Threading.TimerCallback(Mail.sendMailReminderToP);

        //Timer timer2 = null;
        //TimerCallback callback2 = new System.Threading.TimerCallback(PaymentBL.PayToDriver);

        //Timer timer3 = null;
        //TimerCallback callback3 = new System.Threading.TimerCallback(RouteBL.SendRouteToDrivers);
        protected void Application_Start()
        {
             //timer1 = new System.Threading.Timer(callback1, null, 0, TimeSpan.FromHours(1).Hours);
             //timer2 = new System.Threading.Timer(callback2, null, 0, TimeSpan.FromHours(1).Hours);
             //timer3 = new System.Threading.Timer(callback3, null, 0, TimeSpan.FromHours(1).Hours);

            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
