using System.Web.Mvc;

namespace MVCProjectStructure.Areas.TinTuc
{
    public class TinTucAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TinTuc";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TinTuc_default",
                "TinTuc/{controller}/{action}/{id}",
                new { action = "NhomTin", id = UrlParameter.Optional },
                new[] { "MVCProjectStructure.Areas.TinTuc.Controllers" }
            );
        }
    }
}