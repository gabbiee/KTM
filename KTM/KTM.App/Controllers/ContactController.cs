namespace KTM.App.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using Services;

    public class ContactController : Controller
    {
        private ContactService service;

        public ContactController(IKTMData data)
            : base(data)
        {
            this.service = new ContactService();
        }

        public ActionResult Index()
        {

            ContactPageViewModel vm = this.service.GetContactPageVm();
            if (vm == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            Response.StatusCode = 200;
            return View(vm);
        }
    }
}