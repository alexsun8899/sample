using System.Web.Mvc;
using System.Web.Routing;

namespace Sample.Presentation.Web.Controllers
{
    public class BaseController: Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            //Let the request know what went wrong
            filterContext.Controller.TempData["Exception"] = filterContext.Exception;

            //redirect to error handler
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                new { controller = "Exception", action = "HandleError" }));

            // Stop any other exception handlers from running
            filterContext.ExceptionHandled = true;

            // CLear out anything already in the response
            filterContext.HttpContext.Response.Clear();
        }
    }
}