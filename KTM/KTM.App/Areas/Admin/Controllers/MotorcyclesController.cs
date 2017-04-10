namespace KTM.App.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using App.Controllers;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using KTM.Models;


    [Authorize(Roles = "Admin")]
    public class MotorcyclesController : BaseController
    {
        public MotorcyclesController(IKTMData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Add()
        {
            var categories = this.Data.Categories.All()
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            ViewBag.Categories = categories;
            return this.View(new MotorcycleBindingModel());
        }

        public ActionResult AddImageUrl()
        {
            return this.PartialView("_AddImageUrl", new List<string>() { string.Empty });
        }

        [HttpPost]
        public ActionResult Add(MotorcycleBindingModel motorcycleModel)
        {
            var currentUser = this.Data.Users.Find(this.User.Identity.GetUserId());
            var category = this.Data.Categories.Find(motorcycleModel.CategoryId);
            var imageUrls = motorcycleModel.ImageUrls.Select(url => new ImageUrl() { Url = url }).ToList();
            var motorcycle = new Motorcycle()
            {
                Title = motorcycleModel.Title,
                Description = motorcycleModel.Description,
                Engine = motorcycleModel.SystemRequirements,
                Category = category,
                Author = currentUser
            };

            this.Data.Motorcycles.Add(motorcycle);
            this.Data.SaveChanges();
            motorcycle.ImageUrls = imageUrls;
            this.Data.SaveChanges();

            return this.RedirectToAction("Details", "Motorcycles", new { area = "", id = motorcycle.Id });
        }
    }
}