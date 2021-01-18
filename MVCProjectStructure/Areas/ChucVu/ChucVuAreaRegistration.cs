using System.Web.Mvc;

namespace MVCProjectStructure.Areas.ChucVu
{
    public class ChucVuAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ChucVu";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ChucVu_default",
                "ChucVu/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}