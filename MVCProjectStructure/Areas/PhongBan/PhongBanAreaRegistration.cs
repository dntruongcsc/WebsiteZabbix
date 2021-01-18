using System.Web.Mvc;

namespace MVCProjectStructure.Areas.PhongBan
{
    public class PhongBanAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PhongBan";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PhongBan_default",
                "PhongBan/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}