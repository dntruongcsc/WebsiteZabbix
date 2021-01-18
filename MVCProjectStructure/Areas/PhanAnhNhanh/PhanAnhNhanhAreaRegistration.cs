using System.Web.Mvc;

namespace MVCProjectStructure.Areas.PhanAnhNhanh
{
    public class PhanAnhNhanhAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PhanAnhNhanh";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PhanAnhNhanh_default",
                "PhanAnhNhanh/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}