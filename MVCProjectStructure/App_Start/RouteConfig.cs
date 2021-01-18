using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCProjectStructure
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            ////routes.MapMvcAttributeRoutes();//Thêm vào cấu hình route
            //routes.MapRoute(
            //    name: "Menu",
            //    url: "san-pham",
            //    defaults: new { area = "Admin", controller = "NhatKy", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "MVCProjectStructure.Areas.Admin.Controllers" }
            //);
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MVCProjectStructure.Controllers" }
            );
        }
    }
}
