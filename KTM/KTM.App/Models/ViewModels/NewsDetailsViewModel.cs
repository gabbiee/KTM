namespace KTM.App.Models.ViewModels
{
    using System.Collections.Generic;

    public class NewsDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<string> ImageUrls { get; set; }

        public IEnumerable<ConciseReviewViewModel> Comments { get; set; }
    }
}