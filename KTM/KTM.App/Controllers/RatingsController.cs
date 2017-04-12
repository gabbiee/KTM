namespace KTM.App.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.EntityModels;
    using Services;

    public class RatingsController : Controller
    {
       private RatingsService service;

        public RatingsController(IKTMData data)
            : base(data)
        {
          this.service=new RatingsService();
        }

        [Authorize]
        public ActionResult RatingDetails(int id)
        {
           // var motorcycle = this.service.GetMotorcycleById(id);
            var motorcycle = this.Data.Motorcycles.Find(id);
            if (motorcycle == null)
            {
                return this.HttpNotFound("The requested motorcycle was not found in the system.");
            }

           // var currentUser = this.service.GetCurrentUser();
           var currentUser = this.Data.Users.Find(this.User.Identity.GetUserId());

          //  var existingRating = this.service.GetExistingRatings(motorcycle, currentUser);
           var existingRating = this.Data.Ratings.All().FirstOrDefault(r => r.Motorcycle.Id == motorcycle.Id && r.Author.Id == currentUser.Id);
            if (existingRating != null)
            {
              //  var model = Mapper.Map<RatingViewModel>(existingRating);
               var model = this.service.GetRatingViewModel(existingRating);
                return this.PartialView("_Rating", model);
            }
            else
            {
                return this.PartialView("_AddRating", new RatingBindingModel() { MotorcycleId = id });
            }
        }

        [Authorize]
        public ActionResult Add(int id, RatingBindingModel ratingModel)
        {
           var motorcycle = this.Data.Motorcycles.Find(id);
           // var motorcycle = this.service.GetMotorcycleById(id);
            if (motorcycle == null)
            {
                return this.HttpNotFound("The requested motorcycle was not found in the system.");
            }

            var currentUser = this.Data.Users.Find(this.User.Identity.GetUserId());

          var existingRating = this.Data.Ratings.All().FirstOrDefault(r => r.Motorcycle.Id == motorcycle.Id && r.Author.Id == currentUser.Id);
             // var existingRating = this.service.GetExistingRatings(motorcycle, currentUser);
            if (existingRating != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You have already rated this motorcycle");
            }

            var rating = new Rating() { Value = ratingModel.Value, Motorcycle = motorcycle, Author = currentUser };
            motorcycle.Ratings.Add(rating);
            this.Data.SaveChanges();

          var model =this.service.GetRatingViewModel(rating);
           // var model = Mapper.Map<RatingViewModel>(rating);
            return this.PartialView("_Rating", model);
        }
    }
}