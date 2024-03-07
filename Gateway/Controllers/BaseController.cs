using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApplicationChart.Controllers
{
    public abstract class BaseController : Controller
    {
        private string CurrentLanguageCode { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.RouteData.Values["lang"] != null && requestContext.RouteData.Values["lang"] as string != "null")
            {
                CurrentLanguageCode = (string)requestContext.RouteData.Values["lang"];
                if (CurrentLanguageCode != null)
                {
                    try
                    {
                        Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo(CurrentLanguageCode);
                        //NumberFormatInfo nfi = new NumberFormatInfo { CurrencySymbol = "£" };
                        //Thread.CurrentThread.CurrentUICulture.NumberFormat = Thread.CurrentThread.CurrentCulture.NumberFormat = nfi;
                    }
                    catch (Exception)
                    {
                        throw new NotSupportedException($"Invalid language code '{CurrentLanguageCode}'.");
                    }
                }
            }
            base.Initialize(requestContext);
        }
        protected void Flash(string message, string debug = null)
        {
            var alerts = TempData.ContainsKey(Alert.AlertKey) ?
                (List<Alert>)TempData[Alert.AlertKey] :
                new List<Alert>();

            alerts.Add(new Alert
            {
                Message = message,
                Debug = debug
            });

            TempData[Alert.AlertKey] = alerts;
        }
        public class Alert
        {
            public const string AlertKey = "TempDataAlerts";
            public string Message { get; set; }
            public string Debug { get; set; }
        }
    }

}