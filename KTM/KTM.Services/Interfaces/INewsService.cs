namespace KTM.Services.Interfaces
{
    using System.Collections.Generic;
    using Models.EntityModels;
    using Models.ViewModels;

    public interface INewsService
    {
        IEnumerable<News> GetAllNews(int page, int count);
        IEnumerable<ConciseNewsViewModel> GetConciseNewsViewModels(IEnumerable<News> news);
        NewsDetailsViewModel GetNewsDetailsViewModel(News news);
        NewsDetailsViewModel GetDetails(int id);
    }
}
