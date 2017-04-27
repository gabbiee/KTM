namespace KTM.App.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using Services;

    public class NewsController : Controller
    {
        private NewsService service;
        public NewsController(IKTMData data)
            : base(data)
        {
            this.service=new NewsService();
        }

        public HttpConfiguration Configuration { get; set; }

        public ActionResult Index(int page = 1, int count = 5)
        {
            
            var news = this.service.GetAllNews(page, count);
            ViewBag.MaxPages = (this.Data.News.All().Count() + count - 1) / count;
            ViewBag.CurrentPage = page;
            var vms = this.service.GetConciseNewsViewModels(news);
            if (vms == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            Response.StatusCode = 200;
            return this.View(vms);
        }

     public ActionResult Details(int id)
        {
           

            NewsDetailsViewModel vm = this.service.GetDetails(id);
            if (vm == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            Response.StatusCode = 200;
            return this.View(vm);
        }

    }
}