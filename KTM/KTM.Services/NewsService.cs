namespace KTM.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.UnitOfWork;
    using Models.EntityModels;
    using Models.ViewModels;

    public class NewsService:Service
    {
        protected IKTMData data;

        public NewsService()
        {
            this.data = new KTMData();
        }


        public IEnumerable<News> GetAllNews(int page, int count)
        {
            var news = this.data.News.All()
                .OrderBy(n => n.Title)
                .Skip((page - 1) * count)
                .Take(count);

            return news;

        }

        public IEnumerable<ConciseNewsViewModel> GetConciseNewsViewModels(IEnumerable<News> news)
        {
            var models = Mapper.Map<IEnumerable<ConciseNewsViewModel>>(news);
            return models;
        }

        public News GetNewsById(int id)
        {
            var news = this.data.News.All()
                .FirstOrDefault(g => g.Id == id);

            return news;
        }

        public NewsDetailsViewModel GetNewsDetailsViewModel(News news)
        {
            var model = Mapper.Map<NewsDetailsViewModel>(news);
            return model;
        }

        public NewsDetailsViewModel GetDetails(int id)
        {
            var news = this.data.News.All()
                .FirstOrDefault(n => n.Id == id);

            if (news == null)
            {
                return null;
            }

            var model = Mapper.Map<NewsDetailsViewModel>(news);
            return model;

        }
    }
}
