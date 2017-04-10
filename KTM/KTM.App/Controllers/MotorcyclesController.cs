namespace KTM.App.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.UI.WebControls;
    using AutoMapper;
    using Data.UnitOfWork;
    using Models.ViewModels;

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

        //public ActionResult Add()
        //{
        //    return View();
        //}
    }
}