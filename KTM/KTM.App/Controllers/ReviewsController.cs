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

    public class ReviewsController : BaseController
    {
        public ReviewsController(IKTMData data)
            :base(data)
        {
        }

        [Authorize]
        public ActionResult Add(int id, ReviewBindingModel reviewModel)
        {
            var motorcycle = this.Data.Motorcycles.Find(id);
            if (motorcycle == null)
            {
                return this.HttpNotFound("The requested motorcycle was not found in the system.");
            }

            var currentUser = this.Data.Users.Find(this.User.Identity.GetUserId());
            var review = new Review() { Content = reviewModel.Content, Motorcycle = motorcycle, Author = currentUser, CreationTime = DateTime.Now };
            motorcycle.Reviews.Add(review);
            this.Data.SaveChanges();

            var model = Mapper.Map<ConciseReviewViewModel>(review);
            return this.PartialView("_Review", model);
        }
    }
}