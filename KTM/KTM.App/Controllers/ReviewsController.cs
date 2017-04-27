namespace KTM.App.Controllers
{
    using System;
    using System.Net;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.EntityModels;
    using Services;

    public class ReviewsController : Controller
    {
        private ReviewService service;

        public ReviewsController(IKTMData data)
            : base(data)
        {
            this.service = new ReviewService();
        }

        [Authorize]
        public ActionResult Add(int id, ReviewBindingModel reviewModel)
        {
            var motorcycle = this.Data.Motorcycles.Find(id);
        

            var currentUser = this.Data.Users.Find(this.User.Identity.GetUserId());
            var review = new Review() { Content = reviewModel.Content, Motorcycle = motorcycle, Author = currentUser, CreationTime = DateTime.Now };
            motorcycle.Reviews.Add(review);
            this.Data.SaveChanges();

            var vm = this.service.GetConciseReviewViewModel(review);
            if (vm == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            Response.StatusCode = 200;
            return this.PartialView("_Review", vm);
        }
    }
}