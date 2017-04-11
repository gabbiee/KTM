namespace KTM.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.UnitOfWork;
    using Models.ViewModels;

    [RequireHttps]
    public class HomeController : BaseController
    {
        public HomeController(IKTMData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            const int HomePageItems = 5;
            var highestRatedMotorcycles = this.Data.Motorcycles.All()
                .OrderByDescending(c => c.Ratings.Average(r => r.Value))
                .ThenBy(m => m.Title)
                .Take(HomePageItems);
            var latestReviews = this.Data.Reviews.All()
                .OrderByDescending(r => r.CreationTime)
                .Take(HomePageItems);
            var model = new HomePageViewModel()
            {
                HighestRatedMotorcycles = Mapper.Map<IEnumerable<ConciseMotorcycleViewModel>>(highestRatedMotorcycles),
                LatestReviews = Mapper.Map<IEnumerable<ReviewViewModel>>(latestReviews)
            };

            return View(model);
        }
    }
}