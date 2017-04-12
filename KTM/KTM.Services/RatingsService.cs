namespace KTM.Services
{
    using System.Linq;
    using AutoMapper;
    using Data.UnitOfWork;
    using Models.EntityModels;
    using Models.ViewModels;

    public class RatingsService:Service
    {
        protected IKTMData data;

        public RatingsService()
        {
            this.data = new KTMData();
        }


        public Motorcycle GetMotorcycleById(int id)
        {
            var motorcycle = this.data.Motorcycles.Find(id);

            return motorcycle;
        }

        //public object GetCurrentUser()
        //{
        //    var currentUser = this.data.Users.Find(this.User.Identity.GetUserId());
        //}

        public Rating GetExistingRatings(Motorcycle motorcycle, User currentUser)
        {
            var existingRating = this.data.Ratings.All().FirstOrDefault(r => r.Motorcycle.Id == motorcycle.Id && r.Author.Id == currentUser.Id);

            return existingRating;
        }


        public RatingViewModel GetRatingViewModel(Rating existingRating)
        {
            var model = Mapper.Map<RatingViewModel>(existingRating);
            return model;
        }
    }
}
