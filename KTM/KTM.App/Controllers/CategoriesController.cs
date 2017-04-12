namespace KTM.App.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;
    using Services;

    public class CategoriesController : Controller
    {
        private CategoriesService service;

        public CategoriesController(IKTMData data)
            : base(data)
        {
            this.service=new CategoriesService();
        }

        public ActionResult All()
        {
            //var categories = this.Data.Categories.All()
            //    .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            var vm = this.service.GetAllCategories();

            return this.PartialView(vm);
        }

        public ActionResult Details(int id)
        {

          // var category = this.Data.Categories.Find(id);
          var category = this.service.GetCategoryById(id);
         //   if (category == null)
         //   {
         //       return this.HttpNotFound("The requested category was not found in the system.");
         //   }

         //   var motorcycles = this.service.GetMotorcyclesFromCategory(category);

         //   //var motorcycles = category.Motorcycles
         //   //    .OrderBy(g => g.Title);
         //   var model = this.service.ConciseMotorcycleViewModels(motorcycles);
         //   //var model = Mapper.Map<IEnumerable<ConciseMotorcycleViewModel>>(motorcycles);
         //   ViewBag.Category = category.Name;

            IEnumerable<ConciseMotorcycleViewModel> vm = this.service.GetDetails(id);
            ViewBag.Category = category.Name;
            return View(vm);
        }
    }
}