using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestMatik_V1.Addons
{
    public class SessionCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            if (session != null && session["UserId"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    // new RouteValueDictionary {{ "Controller", "Users" },{ "Action", "Login" }}
                    new RouteValueDictionary(new { controller = "Users", action = "Login", returnUrl = filterContext.HttpContext.Request.Path })
                    );
            }

            //base.OnActionExecuting(filterContext);



        }

    }
}