using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mantici.MVCWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            
        }

   
        void Session_Start(object sender, EventArgs e)
        {
            if (Application["visitor"] == null)
            {
                int online=1;
                Application["visitor"] =online;
            }
            else
            {
                int online = (int) Application["visitor"];
                online++;

                Application["visitor"] = online;
            }
           
        }

        void Session_End(object sender, EventArgs e)
        {
            int online = (int)Application["visitor"];
            online--;
            Application["visitor"]=online;
        }
    }
}
