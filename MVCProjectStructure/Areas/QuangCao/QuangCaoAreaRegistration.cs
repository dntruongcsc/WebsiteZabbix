using System.Web.Mvc;

namespace MVCProjectStructure.Areas.QuangCao
{
    public class QuangCaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QuangCao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QuangCao_default",
                "QuangCao/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}