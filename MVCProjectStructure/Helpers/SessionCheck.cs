using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectStructure.Helpers
{
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;

            if (session["UserInfo"] == null)
            {
                filterContext.Result = new PartialViewResult() { ViewName = "_ReturnLoginPage" };
            }
        }
    }
}