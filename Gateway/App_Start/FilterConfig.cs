using System.Web;
using System.Web.Mvc;

namespace ApplicationChart
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute("vn"), 0);
        }
    }
}
