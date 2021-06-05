using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebAppOnlineShop.Commons;

namespace WebAppOnlineShop.Areas.Administrator.Controllers
{
    public class BaseController : Controller
    {
        // GET: Administrator/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.CUSTOMER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Administrator" }));
            }
            base.OnActionExecuting(filterContext);
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertMessage"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertMessage"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertMessage"] = "alert-danger";
            }
        }
    }
}