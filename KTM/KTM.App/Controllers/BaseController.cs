namespace KTM.App.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;

    public abstract class BaseController : Controller
    {
        private IKTMData data;

        protected BaseController(IKTMData data)
        {
            this.Data = data;
        }

        protected IKTMData Data { get; private set; }
    }
}