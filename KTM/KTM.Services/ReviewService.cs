namespace KTM.Services
{
    using System;
    using AutoMapper;
    using Data;
    using Data.UnitOfWork;
    using Models.EntityModels;
    using Models.ViewModels;

    public class ReviewService:Service
    {
       protected IKTMData data;
       // protected KTMContext Context;

        public ReviewService()
        {
            this.data = new KTMData();
            //this.Context=new KTMContext();
            
        }

        public Motorcycle GetMotorcycleById(int id)
        {
            var motorcycle = this.Context.Motorcycles.Find(id);

            return motorcycle;
        }

        public ConciseReviewViewModel GetConciseReviewViewModel(Review review)
        {
            var model = Mapper.Map<ConciseReviewViewModel>(review);

            return model;
        }

        public Motorcycle GetMotorcycle(int id)
        {
            var motorcycle = this.data.Motorcycles.Find(id);

            if (motorcycle == null)
            {
                return null;
            }

            return motorcycle;
        }

        public Review AddReview(string content, Motorcycle motorcycle, User currentUser)
        {
            var review = new Review() { Content = content, Motorcycle = motorcycle, Author = currentUser, CreationTime = DateTime.Now };
            motorcycle.Reviews.Add(review);
            this.Context.SaveChanges();

            return review;

        }
    }
}
