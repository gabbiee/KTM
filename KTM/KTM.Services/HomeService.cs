namespace KTM.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.UnitOfWork;
    using Models.ViewModels;
    public class HomeService : Service
    {
        protected IKTMData data;

        public HomeService()
        {
            this.data = new KTMData();
        }

        public HomePageViewModel GetHomePageVm()
        {
            const int HomePageItems = 5;
            var highestRatedMotorcycles = this.data.Motorcycles.All()
                .OrderByDescending(c => c.Ratings.Average(r => r.Value))
                .ThenBy(m => m.Title)
                .Take(HomePageItems);
            var latestReviews = this.data.Reviews.All()
                .OrderByDescending(r => r.CreationTime)
                .Take(HomePageItems);

            var model = new HomePageViewModel()
            {
                HighestRatedMotorcycles = Mapper.Map<IEnumerable<ConciseMotorcycleViewModel>>(highestRatedMotorcycles),
                LatestReviews = Mapper.Map<IEnumerable<ReviewViewModel>>(latestReviews)
            };

            return model;
        }
    }
}
