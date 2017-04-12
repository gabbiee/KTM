namespace KTM.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.UnitOfWork;
    using Models.ViewModels;

    public class NewsController : BaseController
    {
        public NewsController(IKTMData data)
            : base(data)
        {
        }
        public ActionResult Index(int page = 1, int count = 5)
        {
            var news = this.Data.News.All()
                .OrderBy(n => n.Title)
                .Skip((page - 1) * count)
                .Take(count);
            ViewBag.MaxPages = (this.Data.News.All().Count() + count - 1) / count;
            ViewBag.CurrentPage = page;
            var model = Mapper.Map<IEnumerable<ConciseNewsViewModel>>(news);

            return this.View(model);
        }

     public ActionResult Details(int id)
        {
            var news = this.Data.News.All()
      
                .FirstOrDefault(g => g.Id == id);
            if (news == null)
            {
                return this.HttpNotFound("The requested news are not found in the system.");
            }

            var model = Mapper.Map<NewsDetailsViewModel>(news);
            return this.View(model);
        }
    }
}