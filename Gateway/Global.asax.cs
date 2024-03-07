using ApplicationChart.App_Start;
using ApplicationChart.Controllers;
using ApplicationChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace ApplicationChart
{
    public class MvcApplication : System.Web.HttpApplication
    {
        List<string> onlineList = new List<string>();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MvcHandler.DisableMvcResponseHeader = true;
            JobScheduler.Start();
            Application.Lock();
            Application["UserCount"] = 0;
        }
        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("Server");           //Remove Server Header  
            Response.Headers.Remove("X-AspNet-Version"); //Remove X-AspNet-Version Header
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            try
            {
                var TaikhoanCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (TaikhoanCookie != null)
                {
                    var authTicket = FormsAuthentication.Decrypt(TaikhoanCookie.Value);
                    var Quyen = authTicket.UserData.Split(new Char[] { ',' });
                    var userPrincipal = new GenericPrincipal(new GenericIdentity
                    (authTicket.Name), Quyen);
                    Context.User = userPrincipal;
                }
            }
            catch (CryptographicException cex)
            {
                FormsAuthentication.SignOut();
            }
        }
        protected void Session_Start(Object sender, EventArgs e) {
            Application.Lock();
            Application["UserCount"] = (int)Application["UserCount"] + 1;
            Application.UnLock();
        }
        protected void Session_End(Object sender, EventArgs e)
        {
            Application.Lock();
            Application["UserCount"] = (int)Application["UserCount"] - 1;
            Application.UnLock();
        }

    }
}
