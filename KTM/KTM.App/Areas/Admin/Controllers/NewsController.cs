namespace KTM.App.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.UnitOfWork;
    using Models.BindingModels;
    using KTM.Models.EntityModels;
    using KTM.Models.ViewModels;
    using Controller = App.Controllers.Controller;


    [Authorize(Roles = "Admin")]
    public class NewsController : Controller
    {
        public NewsController(IKTMData data)
            : base(data)
        {
        }
        public ActionResult Index(int page = 1, int count = 5)
        {
            var news = this.Data.News.All()
                .OrderBy(g => g.Title)
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
               .FirstOrDefault(n => n.Id == id);
            if (news == null)
            {
                return this.HttpNotFound("News not found in the system.");
            }

            var model = Mapper.Map<NewsDetailsViewModel>(news);
            return this.View(model);
        }

       
        [HttpGet]
        public ActionResult Add()
        {
            

            var categories = this.Data.Categories.All()
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            ViewBag.Categories = categories;
            return this.View(new NewsBindingModel());
        }

        public ActionResult AddImageUrl()
        {
            return this.PartialView("_AddImageUrl", new List<string>() { string.Empty });
        }

       
        [HttpPost]
        public ActionResult Add(NewsBindingModel newsModel)
        {
           


            var imageUrls = newsModel.ImageUrls.Select(url => new ImageUrl() { Url = url }).ToList();
            var news = new News()
            {
                Title = newsModel.Title,
                Content = newsModel.Content
            };

            this.Data.News.Add(news);
            this.Data.SaveChanges();
            news.ImageUrls = imageUrls;
            this.Data.SaveChanges();


            return this.RedirectToAction("Details", "News", new { area = "", id = news.Id });
        }
    }
}