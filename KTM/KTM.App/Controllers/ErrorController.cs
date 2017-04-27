namespace KTM.App.Controllers
{
    using System;
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult Index(int statusCode, Exception exception)
        {
            Response.StatusCode = statusCode;
            return View();
        }
    }
}