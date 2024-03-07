using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApplicationChart
{
    public static class LanguageHelper
    {
        public static MvcHtmlString LangSwitcher(this UrlHelper url, string name, RouteData routeData, string lang)
        {

            var aTagBuilder = new TagBuilder("a");
            aTagBuilder.AddCssClass("mr-1 waves-effect waves-light p-lg-l-3 p-lg-r-3 text-right");

            TagBuilder tag = new TagBuilder("img");
            if (lang == "vi")
            {
                tag.MergeAttribute("src", "/Content/LoginLayout/img/vn.png");
                tag.MergeAttribute("title", "Vietnamese");
                tag.MergeAttribute("alt", "Vietnamese");

            }
            else
            {
                tag.MergeAttribute("src", "/Content/LoginLayout/img/en.png");
                tag.MergeAttribute("title", "English");
                tag.MergeAttribute("atl", "English");
            }

            var routeValueDictionary = new RouteValueDictionary(routeData.Values);
            if (routeValueDictionary.ContainsKey("lang"))
            {
                if (routeData.Values["lang"] as string == lang)
                {
                    //liTagBuilder.AddCssClass("active");

                }
                else
                {
                    routeValueDictionary["lang"] = lang;
                }
            }

            aTagBuilder.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
            aTagBuilder.MergeAttribute("title", "Language");


            if (lang == "vi")
            {
                aTagBuilder.InnerHtml = tag.ToString() + "<b class='p-1' style='font-size:12px;'> Vietnamese</b>";
            }
            else
            {
                aTagBuilder.InnerHtml = tag.ToString() + "<b class='p-1' style='font-size:12px;'> English</b>";
            }
            return new MvcHtmlString(aTagBuilder.ToString());
        }
    }
}