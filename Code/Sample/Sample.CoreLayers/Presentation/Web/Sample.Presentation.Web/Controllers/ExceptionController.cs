using System.Web.Mvc;

namespace Sample.Presentation.Web.Controllers
{
    public class ExceptionController: Controller
    {
        public ActionResult HandleError()
        {
            return View();
        }
    }
}