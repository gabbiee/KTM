namespace KTM.App.Controllers
{
    using System;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.EntityModels;
    using Models.ViewModels;
    using Services;

    public class ReviewsController : Controller
    {
        private ReviewService service;
       
        public ReviewsController(IKTMData data)
            :base(data)
        {
           this.service=new ReviewService();
        }
        
        [Authorize]
        public ActionResult Add(int id, ReviewBindingModel reviewModel)
        {
            //var motorcycle = this.service.GetMotorcycleById(id);
         //   var motorcycle = this.service.GetMotorcycle(id);
           var motorcycle = this.Data.Motorcycles.Find(id);
            //if (motorcycle == null)
            //{
            //    return this.HttpNotFound("The requested motorcycle was not found in the system.");
            //}

            var currentUser = this.Data.Users.Find(this.User.Identity.GetUserId());
           //  var review = this.service.AddReview(reviewModel.Content, motorcycle, currentUser);
            var review = new Review() { Content = reviewModel.Content, Motorcycle = motorcycle, Author = currentUser, CreationTime = DateTime.Now };
            motorcycle.Reviews.Add(review);
            this.Data.SaveChanges();

            var vm = this.service.GetConciseReviewViewModel(review);
         //  var model = Mapper.Map<ConciseReviewViewModel>(review);
            return this.PartialView("_Review", vm);
        }
    }
}