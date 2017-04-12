namespace KTM.Models.ViewModels
{
    using System.Collections.Generic;

    public class HomePageViewModel
    {
        public IEnumerable<ConciseMotorcycleViewModel> HighestRatedMotorcycles { get; set; }

        public IEnumerable<ReviewViewModel> LatestReviews { get; set; }
    }
}