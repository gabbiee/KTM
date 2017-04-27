namespace KTM.App.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using Services;

    [RequireHttps]
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController(IKTMData data)
            : base(data)
        {
            this.service = new HomeService();
        }

        public ActionResult Index()
        {

            HomePageViewModel vm = this.service.GetHomePageVm();
            if (vm == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            Response.StatusCode = 200;
            return View(vm);
        }



    }
}