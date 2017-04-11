namespace KTM.App.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using App.Controllers;
    using App.Models.ViewModels;
    using AutoMapper;
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
        public ActionResult Index(int page = 1, int count = 5)
        {
            var motorcycles = this.Data.Motorcycles.All()
                .OrderBy(g => g.Title)
                .Skip((page - 1) * count)
                .Take(count);
            ViewBag.MaxPages = (this.Data.Motorcycles.All().Count() + count - 1) / count;
            ViewBag.CurrentPage = page;
            var model = Mapper.Map<IEnumerable<ConciseMotorcycleViewModel>>(motorcycles);

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            var motorcycle = this.Data.Motorcycles.All()
                .Include(g => g.Category)
                .Include(g => g.Reviews)
                .Include(g => g.Ratings)
                .FirstOrDefault(g => g.Id == id);
            if (motorcycle == null)
            {
                return this.HttpNotFound("The requested motorcycle was not found in the system.");
            }

            var model = Mapper.Map<MotorcycleDetailsViewModel>(motorcycle);
            return this.View(model);
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
                Engine = motorcycleModel.Engine,
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