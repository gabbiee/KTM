namespace KTM.Models.ViewModels
{
    using System.Collections.Generic;

    public class MotorcycleDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Engine { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public double Rating { get; set; }

        public IEnumerable<string> ImageUrls { get; set; }

        public IEnumerable<ConciseReviewViewModel> Reviews { get; set; }
    }
}