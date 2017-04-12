namespace KTM.App.Controllers
{
    using System.Linq;
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
        public ActionResult Index(int page = 1, int count = 5)
        {
            //var news = this.Data.News.All()
            //    .OrderBy(n => n.Title)
            //    .Skip((page - 1) * count)
            //    .Take(count);

            var news = this.service.GetAllNews(page, count);
            ViewBag.MaxPages = (this.Data.News.All().Count() + count - 1) / count;
            ViewBag.CurrentPage = page;
            //var model = Mapper.Map<IEnumerable<ConciseNewsViewModel>>(news);
            var vms = this.service.GetConciseNewsViewModels(news);

            return this.View(vms);
        }

     public ActionResult Details(int id)
        {
            //var news = this.Data.News.All()
            //    .FirstOrDefault(g => g.Id == id);

                 //var news = this.service.GetNewsById(id);
                 //   if (news == null)
                 //   {
                 //       return this.HttpNotFound("The requested news are not found in the system.");
                 //   }

            ////var model = Mapper.Map<NewsDetailsViewModel>(news);
            //      var model = this.service.GetNewsDetailsViewModel(news);

            NewsDetailsViewModel vm = this.service.GetDetails(id);

            return this.View(vm);
        }
    }
}