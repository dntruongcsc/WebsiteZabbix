using System.Web.Mvc;

namespace MVCProjectStructure.Areas.QuanLyHost
{
    public class QuanLyHostAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QuanLyHost";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QuanLyHost_default",
                "QuanLyHost/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}