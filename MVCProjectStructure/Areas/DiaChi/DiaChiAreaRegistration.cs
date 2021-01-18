using System.Web.Mvc;

namespace MVCProjectStructure.Areas.DiaChi
{
    public class DiaChiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DiaChi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DiaChi_default",
                "DiaChi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}