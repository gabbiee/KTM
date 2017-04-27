namespace KTM.Services
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.UnitOfWork;
    using Interfaces;
    using Models.EntityModels;
    using Models.ViewModels;

    public class RatingsService:Service, IRatingService
    {
        protected IKTMData data;

        public RatingsService()
        {
            this.data = new KTMData();
        }


        [HandleError(ExceptionType = typeof(ArgumentException), View = "CustomError")]
        public Motorcycle GetMotorcycleById(int id)
        {
            var motorcycle = this.data.Motorcycles.Find(id);

            if (motorcycle == null)
            {
                throw new ArgumentException("Motorcycle not found");
            }

            return motorcycle;
        }

        //public object GetCurrentUser()
        //{
        //    var currentUser = this.data.Users.Find(this.User.Identity.GetUserId());
        //}

        public Rating GetExistingRatings(Motorcycle motorcycle, User currentUser)
        {
            var existingRating = this.data.Ratings.All()
                .FirstOrDefault(r => r.Motorcycle.Id == motorcycle.Id && r.Author.Id == currentUser.Id);

            return existingRating;
        }


        public RatingViewModel GetRatingViewModel(Rating existingRating)
        {
            var model = Mapper.Map<RatingViewModel>(existingRating);
            return model;
        }
    }
}
