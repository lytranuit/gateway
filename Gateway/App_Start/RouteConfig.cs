using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApplicationChart
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "CRMKEHOACH",
                url: "{lang}/cong-tac-trinh-duoc/{action}/{id}",
                defaults: new { controller = "Baocao", action = "Lich", id = UrlParameter.Optional },
                 constraints: new { lang = @"en|vi" }
            );
            routes.MapRoute(
                name: "CRMDATHANG",
                url: "{lang}/crm/{action}/{id}",
                defaults: new { controller = "Order", action = "Danhsachdonhang", id = UrlParameter.Optional },
                constraints: new { lang = @"en|vi" }
            );
            routes.MapRoute(
             name: "Ketoan",
             url: "{lang}/ke-toan/{action}/{id}",
             defaults: new { controller = "Ketoan", action = "thong-ke-tai-khoan", id = UrlParameter.Optional },
             constraints: new { lang = @"en|vi" }
         );
            routes.MapRoute(
                name: "Admin",
                url: "he-thong-quan-tri/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "Sanpham",
             url: "{lang}/san-pham/{action}/{id}",
             defaults: new { controller = "QLSP", action = "quan-ly-san-pham", id = UrlParameter.Optional },
             constraints: new { lang = @"en|vi" }
         );
            routes.MapRoute(
               name: "HeThong",
               url: "{lang}/he-thong/{action}/{id}",
               defaults: new { controller = "Home", action = "bao-cao-bsc", id = UrlParameter.Optional },
               constraints: new { lang = @"en|vi" }
           );
            routes.MapRoute(
             name: "Thau",
             url: "{lang}/quan-ly-thau/{action}/{id}",
             defaults: new { controller = "Thau", action = "theo-doi-hang-thau", id = UrlParameter.Optional },
             constraints: new { lang = @"en|vi" }
         );
            routes.MapRoute(
          name: "Duuoc",
          url: "{lang}/du-uoc/{action}/{id}",
          defaults: new { controller = "Duuoc", action = "nhap-du-lieu", id = UrlParameter.Optional },
          constraints: new { lang = @"en|vi" }
      );
            routes.MapRoute(
       name: "Account",
       url: "{lang}/Account/{action}/{id}",
       defaults: new { controller = "Account", action = "SignIn", id = UrlParameter.Optional },
       constraints: new { lang = @"en|vi" }
   );
            routes.MapRoute(
              name: "LoginEN",
              url: "{lang}/{action}/{id}",
              defaults: new { controller = "Login", action = "dang-nhap", id = UrlParameter.Optional},
                constraints: new { lang = @"en|vi" }
          );
         //   routes.MapRoute(
         //    name: "Default",
         //    url: "{controller}/{action}/{id}",
         //    defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
         //);
            routes.MapRoute(
                name: "Default",
                url: "{action}/{id}",
                defaults: new { controller = "Login", action = "dang-nhap", id = UrlParameter.Optional, lang = "vi" }
            );
        }
    }
}
