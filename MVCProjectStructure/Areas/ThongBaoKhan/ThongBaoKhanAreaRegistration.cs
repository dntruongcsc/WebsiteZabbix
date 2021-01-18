using System.Web.Mvc;

namespace MVCProjectStructure.Areas.ThongBaoKhan
{
    public class ThongBaoKhanAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ThongBaoKhan";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ThongBaoKhan_default",
                "ThongBaoKhan/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}